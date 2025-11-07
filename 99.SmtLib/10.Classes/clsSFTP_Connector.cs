using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmtLib
{
    public class SFTP_Connector
    {
        public string HOST{ get { return _host; } set { _host = value; } }
        public string USERNAME { get { return _username; } set { _username = value; } }
        public string PASSWORD { get { return _password; } set { _password = value; } }
        private string _host = "";
        private string _username = "";
        private string _password = "";
        private int _port = 22; //SFTPのポートは２２で固定
        public bool isConnected { get { return sftp != null ? sftp.IsConnected : false; } }
        SftpClient sftp;
        public delegate void ProgressEvent(string filename, ushort percent);
        public event ProgressEvent onDownloadProgress;
        public event ProgressEvent onUploadProgress;
        private void OnDownloadProcessing(string filename, ushort percent)
        {
            if(onDownloadProgress != null)
            {
                onDownloadProgress.Invoke(filename, percent);
            }
        }
        private void OnUploadProcessing(string filename, ushort percent)
        {
            if (onUploadProgress != null)
            {
                onUploadProgress.Invoke(filename, percent);
            }
        }
        public SFTP_Connector()
        {
        }
        public SFTP_Connector(string _host, string _username, string _password)
        {
            HOST = _host;
            USERNAME = _username;
            PASSWORD = _password;
        }

        public ResponseBody<bool> Connect()
        {
            ResponseBody<bool> result = new ResponseBody<bool>();
            try
            {
                if (isConnected)
                {
                    Disconnect();
                }
                sftp = new SftpClient(HOST, _port, USERNAME, PASSWORD);
                sftp.KeepAliveInterval = new TimeSpan(-1); //自動切断しないように
                sftp.Connect();
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseBody<bool> Disconnect()
        {
            ResponseBody<bool> result = new ResponseBody<bool>();

            try
            {
                if (sftp.IsConnected)
                {
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseBody<List<string>> listFiles(string remoteFolder, string ext = "")
        {
            var result = new ResponseBody<List<string>>();
            try
            {
                var files = sftp.ListDirectory(remoteFolder);
                var res = files.Where(x => !x.IsDirectory);
                if (!string.IsNullOrEmpty(ext.Trim()))
                {
                    res = res.Where(x => x.Name.ToUpper().EndsWith($".{ext.ToUpper()}"));
                }
                result.Data = res.Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseBody<bool> downloadFile(string remoteFolder, string localFolder, string filename)
        {
            var result = new ResponseBody<bool>() { Data = true };
            try
            {
                string remoteFile = $"{remoteFolder}/{filename}";
                string downloadFile = $"{localFolder}\\{filename}";

                if (File.Exists(downloadFile))
                    File.Delete(downloadFile);

                using (Stream fs = File.OpenWrite(downloadFile))
                {
                    sftp.DownloadFile(remoteFile, fs);
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseBody<bool> AsyncDownloadFile(string remoteFolder, string localFolder, string filename)
        {
            var result = new ResponseBody<bool>() { Data = true};
            try
            {
                string remoteFile = $"{remoteFolder}/{filename}";
                string downloadFile = $"{localFolder}\\{filename}";
                if (!Directory.Exists(localFolder))
                {
                    Directory.CreateDirectory(localFolder);
                }
                var getFile = sftp.Get(remoteFile);

                if (File.Exists(downloadFile))
                    File.Delete(downloadFile);

                using (Stream fs = File.OpenWrite(downloadFile))
                {
                    var async = sftp.BeginDownloadFile(remoteFile, fs);
                    while (!async.IsCompleted)
                    {
                        if(getFile.Length == 0)
                        {
                            OnDownloadProcessing(filename, 100);
                        }
                        else
                        {
                            OnDownloadProcessing(filename, ushort.Parse((((SftpDownloadAsyncResult)async).DownloadedBytes * 100 / ulong.Parse(getFile.Length.ToString())).ToString()));
                        }
                    }
                    sftp.EndDownloadFile(async);
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
                result.Data = false;
            }
            return result;
        }

        public ResponseBody<bool> uploadFile(string remoteFolder, string localFolder, string localFilename, string remoteFilename = "")
        {
            var result = new ResponseBody<bool>() { Data = true };
            try
            {
                string remoteFile = $"{remoteFolder}/{(string.IsNullOrWhiteSpace(remoteFilename) ? localFilename : remoteFilename)}";
                string uploadFile = Path.Combine(localFolder, localFilename);
                using (Stream fs = File.OpenRead(uploadFile))
                {
                    sftp.UploadFile(fs, remoteFile.Replace("\\","/"));
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseBody<bool> uploadFile(string remotePath, string localpath)
        {
            return uploadFile(ClsFile.GetDirectoryName(remotePath), ClsFile.GetDirectoryName(localpath), ClsFile.GetFileName(localpath), ClsFile.GetFileName(remotePath));
        }

        public ResponseBody<bool> AsyncUploadFile(string remoteFolder, string localFolder, string localFilename, string remoteFilename)
        {
            var result = new ResponseBody<bool>() { Data = true };
            try
            {
                string remoteFile = $"{remoteFolder}/{remoteFilename}";
                string uploadFile = $"{localFolder}\\{localFilename}";

                FileInfo fInfo = new FileInfo(uploadFile);

                using (Stream fs = File.OpenRead(uploadFile))
                {
                    var async = sftp.BeginUploadFile(fs, remoteFile);
                    while (!async.IsCompleted)
                    {
                        OnDownloadProcessing(localFilename, ushort.Parse((((SftpUploadAsyncResult)async).UploadedBytes * 100 / ulong.Parse(fInfo.Length.ToString())).ToString()));
                    }
                    sftp.EndUploadFile(async);
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
                result.Data = false;
            }
            return result;
        }

        public ResponseBody<bool> moveFile(string filename, string remoteFolder_from, string remoteFolder_to, bool acceptDupplicate = false)
        {
            var result = new ResponseBody<bool>();
            try
            {
                string remoteFile_From = $"{remoteFolder_from}/{filename}";
                string remoteFile_To = $"{remoteFolder_to}/{filename}";
                string extension = ClsFile.GetExtensionName(filename).TrimStart('.');
                if (acceptDupplicate)
                {
                    var lstFiles = listFiles(remoteFolder_to, extension);
                    if (lstFiles.StatusCode != StatusCode.SUCCEED)
                    {
                        result.StatusCode = lstFiles.StatusCode;
                        result.Message = lstFiles.Message;
                        return result;
                    }
                    int i = 1;
                    string fname = filename;
                    while (lstFiles.Data.Contains(fname))
                    {
                        fname = $"{filename.Split('.')[0]}({i}).{extension}";
                        i++;
                    }
                    remoteFile_To = $"{remoteFolder_to}/{fname}";
                }
                var getFile = sftp.Get(remoteFile_From);
                getFile.MoveTo(remoteFile_To);
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
                result.Data = false;
            }
            return result;
        }

        public ResponseBody<bool> clearFile(string remoteFolder, string ext = "")
        {
            var result = new ResponseBody<bool>();
            try
            {
                var lstFiles = listFiles(remoteFolder, ext);
                if(lstFiles.StatusCode != StatusCode.SUCCEED)
                {
                    result.StatusCode = lstFiles.StatusCode;
                    result.Message = lstFiles.Message;
                    return result;
                }
                foreach (string path in lstFiles.Data)
                {
                    sftp.DeleteFile(path);
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
                result.Data = false;
            }
            return result;
        }

        public ResponseBody<bool> renameFile(string remoteFolder, string oldName, string newName)
        {
            var result = new ResponseBody<bool>();
            try
            {
                sftp.RenameFile($"{remoteFolder}/{oldName}", $"{remoteFolder}/{newName}");
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                result.StatusCode = StatusCode.FAILED;
                result.Message = ex.Message;
                result.Data = false;
            }
            return result;
        }
    }
}

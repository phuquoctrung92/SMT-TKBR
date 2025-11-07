using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using SmtLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.FtpClient;
using System.Text;
using System.Threading.Tasks;

namespace SmtLib
{
    public class FtpConnector
    {
        FtpClient ftp;

        public string HOST { get { return _host; } set { _host = value; } }
        public string USERNAME { get { return _username; } set { _username = value; } }
        public string PASSWORD { get { return _password; } set { _password = value; } }
        public int PORT { get { return _port; } set { _port = value; } }
        private string _host = "";
        private string _username = "";
        private string _password = "";
        private int _port = 21;

        public int Timeout = 5000;
        public bool isConnected { get { return ftp != null ? ftp.IsConnected : false; } }

        public FtpConnector()
        {
        }
        public FtpConnector(string _host, string _username, string _password, int _port = 21, int timeout = 5000)
        {
            HOST = _host;
            USERNAME = _username;
            PASSWORD = _password;
            PORT = _port;
            Timeout = timeout;
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
                ftp = new FtpClient();
                ftp.Host = HOST;
                ftp.Port = PORT;
                ftp.Credentials = new System.Net.NetworkCredential(USERNAME, PASSWORD);
                ftp.ConnectTimeout = Timeout;
                ftp.Connect();
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
                if (ftp.IsConnected)
                {
                    ftp.Disconnect();
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

        public ResponseBody<bool> uploadFile(string remoteFolder, string localFolder, string localFilename, string remoteFilename)
        {
            var result = new ResponseBody<bool>() { Data = true };
            try
            {
                string remoteFile = $"{remoteFolder}/{remoteFilename}";
                string uploadFile = $"{localFolder}\\{localFilename}";

                if (!ftp.DirectoryExists(remoteFolder))
                {
                    ftp.CreateDirectory(remoteFolder);
                }

                byte[] b = File.ReadAllBytes(uploadFile);
                using (Stream fw = ftp.OpenWrite(remoteFile))
                {
                    fw.Write(b, 0, b.Length);
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
    }
}

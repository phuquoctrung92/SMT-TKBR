using SmtLib;
using SmtLib.DataBaseObjects;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace ServerSystemLib
{
    public class HT000
    {
        public static HtSendData Execute(HtReceiveData rcvData, DateTime sysdate)
        {
            HtSendData sndData = new HtSendData();

            try
            {
                if (rcvData.Action == ActionKB.G)
                {
                    switch (rcvData.ActionSub)
                    {
                        case ActionSub.Update:
                            if (string.IsNullOrWhiteSpace(IniSVSetting.Update_Path))
                            {
                                sndData.CreateError("アップデートファイルのパスが設定されていません。");
                                return sndData;
                            }
                            if (!File.Exists(IniSVSetting.Update_Path))
                            {
                                sndData.CreateError("アップデートファイルが存在していません。");
                                return sndData;
                            }
                            var updFileBinary = clsUtil.convertFileToBinary(IniSVSetting.Update_Path);
                            sndData.Data.Add(updFileBinary.Length.ToString());
                            sndData.File = updFileBinary;
                            return sndData;
                    }
                }
                // パラメータ不一致
                sndData.CreateError(HTErrorMessage.ERR_PARAMETER, rcvData.kbn + "_" + rcvData.ActionSub);
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                sndData.CreateError(ex.Message);
            }
            return sndData;
        }
    }
}

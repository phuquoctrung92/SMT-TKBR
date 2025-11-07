using SmtLib;
using SmtLib.DataBaseObjects;
using System;
using System.Linq;

namespace ServerSystemLib
{
    public class Main
    {

        HtReceiveData rcvData = new HtReceiveData();
        HtSendData sndData = new HtSendData();
        DateTime SysDate;

        public HtSendData Execute(string data)
        {
            sndData = rcvData.SetData(data);
            return Execute(rcvData, sndData);
        }
        public HtSendData Execute(HtReceiveData receiveData, HtSendData sendData)
        {
            rcvData = receiveData;
            if (sendData.DataKbn != HtSendData.DATA_KBN_NORMAL) { return sndData; }

            try
            {
                sndData = new HtSendData();

                if (SQLServer.Instance.Open() < 0)
                {
                    sndData.CreateError("DataBase接続に失敗しました。");
                    return sndData;
                }

                SysDate = SQLServer.Instance.GetSysDate();

                SQLServer.Instance.BeginTransaction();

                switch (rcvData.kbn)
                {
                    case DisplayKB.HT000:
                        sndData = HT000.Execute(rcvData, SysDate);
                        break;
                    default:
                        // パラメータ不一致
                        sndData.DataKbn = HtSendData.DATA_KBN_ERROR;
                        sndData.Add(HTErrorMessage.ERR_PARAMETER);
                        break;
                }

                if (SQLServer.Instance.ExistsTransaction)
                {
                    if (sndData.DataKbn != HtSendData.DATA_KBN_NORMAL)
                    {
                        SQLServer.Instance.Rollback();
                    }
                    else
                    {
                        SQLServer.Instance.Commit();
                    }
                }

                //読み取り履歴に追加
                Yomitori_Rireki_Insert();
            }
            catch (Exception ex)
            {
                if (SQLServer.Instance.ExistsTransaction)
                {
                    SQLServer.Instance.Rollback();
                }

                clsLogger.Error(ex);
                sndData.CreateError(ex.Message);
            }
            finally { if (SQLServer.Instance.ExistsConnection) SQLServer.Instance.Close(); }
            return sndData;
        }

        private void Yomitori_Rireki_Insert()
        {
            try
            {
                /*
                var rireki = new MSSQL.DAT.OBJ.trn_kenpin_rrk(rcvData.kbn.ToString(), SysDate)
                {
                    kpr_shiji_no = rcvData.Value.Count > 1 ? rcvData.Value[1] : "",
                    kpr_kenpin_kb = 1,
                    kpr_result = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? 1 : 9,
                    kpr_message = sndData.DataKbn == HtSendData.DATA_KBN_ERROR ? (sndData.Data.FirstOrDefault() ?? "") : "",
                    kpr_kenpin_date = SysDate,
                    kpr_kenpin_serialno = rcvData.BHTSNo,
                    kpr_kenpin_tanto_code = rcvData.Value.Count > 0 ? rcvData.Value[0] : ""
                };

                switch (rcvData.kbn)
                {
                    case DisplayKB.HT100:
                        rireki.kpr_shiji_no = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? sndData.Data[0] : "";
                        rireki.kpr_value1 = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? rcvData.Value[0] : "";
                        rireki.kpr_read_value = rcvData.Value.Count > 0 ? rcvData.Value[0] : "";
                        rireki.kpr_kenpin_tanto_code = rcvData.Value.Count > 1 ? rcvData.Value[1] : "";
                        break;
                    case DisplayKB.HT210:
                        if (rcvData.ActionSub == ActionSub.ReadOyaNo)
                        {
                            rireki.kpr_value1 = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? rcvData.Value[2] : "";
                            rireki.kpr_read_value = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                            rireki.kpr_read_code_type = rcvData.Value.Count > 3 ? rcvData.Value[3] : "";
                        }
                        else if (rcvData.ActionSub == ActionSub.KenpinKoNo)
                        {
                            rireki.kpr_value1 = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                            rireki.kpr_value2 = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? rcvData.Value[3] : "";
                            rireki.kpr_read_value = rcvData.Value.Count > 3 ? rcvData.Value[3] : "";
                            rireki.kpr_read_code_type = rcvData.Value.Count > 4 ? rcvData.Value[4] : "";
                        }
                        break;
                    case DisplayKB.HT220:
                        if (rcvData.ActionSub == ActionSub.NumberCheckFirst)
                        {
                            rireki.kpr_read_value = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                            rireki.kpr_read_code_type = rcvData.Value.Count > 3 ? rcvData.Value[3] : "";
                        }
                        else if(rcvData.ActionSub == ActionSub.NumberCheckComp)
                        {
                            rireki.kpr_value1 = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                        }                        
                        break;
                    case DisplayKB.HT230:
                        if (rcvData.ActionSub == ActionSub.ReadOyaNo)
                        {
                            rireki.kpr_read_value = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                            rireki.kpr_read_code_type = rcvData.Value.Count > 3 ? rcvData.Value[3] : "";
                        }
                        else if (rcvData.ActionSub == ActionSub.KenpinKoNo)
                        {
                            rireki.kpr_value1 = rcvData.Value.Count > 2 ? rcvData.Value[2] : "";
                            rireki.kpr_value2 = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? rcvData.Value[3] : "";
                            rireki.kpr_value3 = sndData.DataKbn == HtSendData.DATA_KBN_NORMAL ? rcvData.Value[4] : "";
                            rireki.kpr_read_value = $"{rcvData.Value[3]}|{rcvData.Value[4]}";
                        }
                        break;

                    default:
                        return;
                }

                rireki.INSERT(rireki.kpr_kenpin_tanto_code);
                */
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
            }
        }
    }

}

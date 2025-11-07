using SmtLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSystemLib
{
    internal class Common
    {
        public static HtSendData CreateYareSashikomi(string ht_serial, string user_id, int reprint_kbn, string yare_taisho_from, string yare_taisho_to)
        {
            HtSendData htSendData = new HtSendData();
            try
            {
                //引数4：ヤレ対象連番From　が11桁ではない　OR　後ろ6桁が数字ではない　とき
                if (yare_taisho_from.Length != 11 || !ClsCheck.IsNumeric(yare_taisho_from.Substring(5, 6)))
                {
                    htSendData.CreateError("ヤレ対象連番Fromの指定が不正\nです");
                    return htSendData;
                }
                //引数5：ヤレ対象連番To　が11桁ではない　OR　後ろ6桁が数字ではない　とき
                if (yare_taisho_to.Length != 11 || !ClsCheck.IsNumeric(yare_taisho_to.Substring(5, 6)))
                {
                    htSendData.CreateError("ヤレ対象連番Toの指定が不正\nです");
                    return htSendData;
                }
                //引数4：ヤレ対象連番From　の前3桁と　引数5：ヤレ対象連番To の前3桁が同じではないとき
                if (yare_taisho_from.Substring(0, 3) != yare_taisho_to.Substring(0, 3))
                {
                    htSendData.CreateError("ヤレ対象連番FromToの指定が\n不正です");
                    return htSendData;
                }
                //引数4：ヤレ対象連番From 後ろ6桁　>　引数5：ヤレ対象連番To  後ろ6桁　のとき
                if ((int.Parse(yare_taisho_from.Substring(5, 6))) > (int.Parse(yare_taisho_to.Substring(5, 6))))
                {
                    htSendData.CreateError("ヤレ対象連番FromToの指定が\n逆です");
                    return htSendData;
                }

                //変数：ヤレ連番Fromに　引数4：ヤレ対象連番Fromの 'R' を '0' に置換した文字列をセット
                string yare_renban_from = yare_taisho_from.Replace('R', '0');
                //変数：ヤレ連番Toに　　 引数5：ヤレ対象連番Toの 'R' を '0' に置換した文字列をセット
                string yare_renban_to = yare_taisho_to.Replace('R', '0');

                //検品データを検索
                //var lstKenpin = MSSQL.DAT.trn_juchu.getKenpinDataByYareRenbanFromTo(ConstKrsv.JUCHU_NO, yare_renban_from, yare_renban_to);
                //if (lstKenpin.Count == 0)
                //{
                //    htSendData.CreateError("検品範囲外の連番です");
                //    return htSendData;
                //}

                //foreach (var item in lstKenpin)
                //{
                //    //string mae_no = "";
                //    //string ato_no = "";

                //    //ループ一回目のとき
                   

                //    //ヤレ再発行データを作成
                  
                //}
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                htSendData.CreateError("例外が発生されました");
            }
            return htSendData;
        }
    }
}

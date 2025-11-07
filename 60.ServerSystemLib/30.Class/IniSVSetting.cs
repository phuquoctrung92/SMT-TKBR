using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSystemLib
{
    public class IniSVSetting : IniReadWrite
    {
        private IniSVSetting() : base("SV_config.ini") { }
        private static IniSVSetting Instance = new IniSVSetting();
        public static int Config_Recv_Delay { get { return Instance.GetInteger("Config", "Recv_Delay", 100); } }
        public static string Torikomi_Path { get { return Instance.GetString("Torikomi", "Path"); } }
        public static string Torikomi_Path_BK { get { return Instance.GetString("Torikomi", "Backup_Path"); } }
        public static string Torikomi_Extension { get { return Instance.GetString("Torikomi", "Extension"); } }
        public static int Torikomi_Row_Begin { get { return Instance.GetInteger("Torikomi", "Row_Begin", 0); } }
        public static int Torikomi_Interval { get { return Instance.GetInteger("Torikomi", "Row_Begin", 3000); } }
        public static string Update_Path { get { return Instance.GetString("Update", "Path"); } }
    }
}

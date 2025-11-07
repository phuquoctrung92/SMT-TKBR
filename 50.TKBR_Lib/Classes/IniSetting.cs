using SmtLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBR_Lib.Classes
{
    public class IniSetting
    {
        private IniSetting() { }
         
        public static int Common_Dummy_Front { get { return GetIni_int("Common", "Dummy_Front",0); } }
        public static int Common_Dummy_Back { get { return GetIni_int("Common", "Dummy_Back",0); } }
        public static string Common_Dummy_Futo_Front { get { return GetIni_String("Common", "Dummy_Futo_Front"); } }
        public static string Common_Dummy_Futo_Back { get { return GetIni_String("Common", "Dummy_Futo_Back"); } }
      
        //public static bool Common_IsPrintPreView { get { return GetIni_bool("Common", "IsPrintPreView"); } }

        //public static string Common_ScannerComPort { get { return GetIni_String("Common", "ScannerComPort"); } }


        public static string Futo_Posion(string szi_cd) { 
            if(string.IsNullOrEmpty(szi_cd)){ szi_cd = "XXXXXXX"; }
             return GetIni_String("Futo_Posion", szi_cd); 
            
        } 

        public static string SPWMS_URL { get { return GetIni_String("SPWMS", "URL"); } }
        public static string SPWMS_company_code { get { return GetIni_String("SPWMS", "company_code"); } }
        public static string SPWMS_api_id { get { return GetIni_String("SPWMS", "api_id"); } }
        public static string SPWMS_worker_code { get { return GetIni_String("SPWMS", "worker_code"); } }
        public static string SPWMS_passwd { get { return GetIni_String("SPWMS", "passwd"); } }
        public static string SPWMS_owner_code { get { return GetIni_String("SPWMS", "owner_code"); } }
        public static string SPWMS_base_code { get { return GetIni_String("SPWMS", "base_code"); } }


        public static string FunyukiRenkei_OutputDirectory { get { return GetIni_String("Funyuki_Renkei", "output_directory"); } }

        private static string GetIni_String(string section, string key, string defaultValue = ""){ 
        
            IniReadWrite Instance = new IniReadWrite("setting.ini");
            return Instance.GetString(section, key, defaultValue);
        
        }
           private static bool GetIni_bool(string section, string key){ 
        
            IniReadWrite Instance = new IniReadWrite("setting.ini");
            return Instance.GetBoolean(section, key);
        
        }
        private static int GetIni_int(string section, string key, int defaultValue=0){ 
        
            IniReadWrite Instance = new IniReadWrite("setting.ini");
            return Instance.GetInteger(section, key, defaultValue);
        
        }
     
    }
}

using System.Diagnostics;

namespace SmtLib
{
    /// <summary>
    /// ファイル情報
    /// </summary>
    public class ClsFileInfo
    {

        private string m_source_file;
        /// <summary>ファイルバージョンを取得</summary>
        public enum ReturnFileVersions
        {
            /// <summary>ファイルバージョン</summary>
            FileVersion,
            /// <summary>ファイルメジャーNo</summary>
            FileMajorPert,
            /// <summary>ファイルマイナーNo</summary>
            FileMinorPert,
            /// <summary>ファイルプライベートNo</summary>
            FilePrivatePert,
            /// <summary>ビルドNo</summary>
            FileBuildPert,
            /// <summary>製品ファイルバージョン</summary>
            ProductFileVersion,
            /// <summary>製品メジャーNo</summary>
            ProductMajorPert,
            /// <summary>製品マイナーNo</summary>
            ProductMinorPert,
            /// <summary>製品プライベートNo</summary>
            ProductPrivatePert,
            /// <summary>製品ビルドNo</summary>
            ProductBuildPert
        }
        /// <summary>初期設定</summary>
        /// <param name="_source_file">ファイルパス</param>
        public ClsFileInfo(string _source_file)
        {
            m_source_file = _source_file;
        }

        /// <summary>ファイルバージョンを取得</summary>
        /// <param name="return_file_verion">ReturnFileVersions</param>
        /// <returns>バージョン</returns>
        public string GetVersion(ReturnFileVersions return_file_verion = ReturnFileVersions.FileVersion)
        {
            var file_version_info = FileVersionInfo.GetVersionInfo(m_source_file);
            string file_version = string.Empty;

            switch (return_file_verion)
            {
                case ReturnFileVersions.FileVersion:
                    {
                        file_version = file_version_info.FileVersion;
                        break;
                    }
                case ReturnFileVersions.FileMajorPert:
                    {
                        file_version = file_version_info.FileMajorPart.ToString();
                        break;
                    }
                case ReturnFileVersions.FileMinorPert:
                    {
                        file_version = file_version_info.FileMinorPart.ToString();
                        break;
                    }
                case ReturnFileVersions.FilePrivatePert:
                    {
                        file_version = file_version_info.FilePrivatePart.ToString();
                        break;
                    }
                case ReturnFileVersions.FileBuildPert:
                    {
                        file_version = file_version_info.FileBuildPart.ToString();
                        break;
                    }
                case ReturnFileVersions.ProductFileVersion:
                    {
                        file_version = file_version_info.ProductVersion;
                        break;
                    }
                case ReturnFileVersions.ProductMajorPert:
                    {
                        file_version = file_version_info.ProductMajorPart.ToString();
                        break;
                    }
                case ReturnFileVersions.ProductMinorPert:
                    {
                        file_version = file_version_info.ProductMinorPart.ToString();
                        break;
                    }
                case ReturnFileVersions.ProductPrivatePert:
                    {
                        file_version = file_version_info.ProductPrivatePart.ToString();
                        break;
                    }
                case ReturnFileVersions.ProductBuildPert:
                    {
                        file_version = file_version_info.ProductBuildPart.ToString();
                        break;
                    }
            }

            return file_version;
        }

    }
}
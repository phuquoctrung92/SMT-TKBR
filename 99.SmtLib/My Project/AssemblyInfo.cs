using System;
using System.Reflection;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。

// アセンブリ属性の値を確認します。

[assembly: AssemblyTitle("SmtLib")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("SP Media-Tec")]
[assembly: AssemblyProduct("SmtLib")]
[assembly: AssemblyCopyright("Copyright (C) SP Media-Tec 2019")]
[assembly: AssemblyTrademark("")]

[assembly: ComVisible(false)]

// このプロジェクトが COM に公開される場合、次の GUID がタイプ ライブラリの ID になります。
[assembly: Guid("bb9548d1-6a40-45fb-9ba0-941c1260ce5e")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
// 
// Major Version
// Minor Version 
// Build Number
// Revision
// 
// すべての値を指定するか、下のように '*' を使ってビルドおよびリビジョン番号を 
// 既定値にすることができます:
// <Assembly: AssemblyVersion("1.0.*")> 

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// log4net アプリケーション構成ファイル (App.config) の構成情報を監視します。
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

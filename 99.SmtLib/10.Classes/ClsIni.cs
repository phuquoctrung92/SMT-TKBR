using SmtLib;
using System;
/// <summary>
/// iniファイルを読み書き
/// </summary>
public class IniReadWrite : kernel32
{
    /// <summary>
    /// 初期設定
    /// </summary>
    /// <param name="fileName">iniファイル先</param>
    public IniReadWrite(string fileName) : base(fileName)
    {
        if (!System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
        {
            System.IO.File.Create(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }
    }

    /// <summary>
    /// テキストを取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <returns>テキスト（存在しない場合、NULLを返す）</returns>
    public string GetString(string section, string key)
    {
        return IniReadKeyString(section, key);
    }

    /// <summary>
    /// テキストを取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">存在しない場合、この値を返す</param>
    /// <returns>テキスト</returns>
    public string GetString(string section, string key, string defaultValue)
    {
        return IniReadKeyString(section, key, defaultValue);
    }

    /// <summary>
    /// 数字を取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <returns>数字（存在しない場合、０を返す）</returns>
    public int GetInteger(string section, string key)
    {
        return IniReadKeyInteger(section, key);
    }

    /// <summary>
    /// 数字を取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">存在しない場合、この値を返す</param>
    /// <returns>数字</returns>
    public int GetInteger(string section, string key, int defaultValue)
    {
        return IniReadKeyInteger(section, key, defaultValue);
    }

    /// <summary>
    /// 実数を取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <returns>実数（存在しない場合、０を返す）</returns>
    public float GetFloat(string section, string key)
    {
        string value = GetString(section, key, "0");
        return float.Parse(value);
    }

    /// <summary>
    /// 実数を取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <param name="defaultValue">存在しない場合、この値を返す</param>
    /// <returns>実数</returns>
    public float GetFloat(string section, string key, float defaultValue)
    {
        string value = GetString(section, key, defaultValue.ToString());
        return float.Parse(value);
    }

    /// <summary>
    /// ブール値を取得
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <returns>True / False</returns>
    public bool GetBoolean(string section, string key)
    {
        try
        {
            string data = GetString(section, key, "").ToLower();

            return data == "1" || data == "true";
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// テキストを書き込み
    /// </summary>
    /// <param name="section">セクション</param>
    /// <param name="key">キー</param>
    /// <param name="value">書き込みデータ</param>
    /// <returns>True: 成功、False：失敗</returns>
    public bool SetString(string section, string key, string value)
    {
        return IniWriteKeyString(section, key, value);
    }
}
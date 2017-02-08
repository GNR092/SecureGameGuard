using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;

namespace SecureGameGuard
{
    /// <summary>
    /// SecureGameGuard.
    /// 
    /// Copyright (C) GNR092, 2016-2017.
    /// </summary>
    public class GameGuard
    {
        static readonly object _Lock = new object();
        private static List<string> array { get; set; }
        public static bool exit = false;
        private static readonly string PasswordHash = "G4M36U4RD14N";
        private static readonly string SaltKey = "S@LT&KEY";
        private static readonly string VIKey = "@1B2c3D4e5F6g7H!";

        public static void StartSecureGame(List<string> Config, bool error = false)
        {
            if (error)
            {
                array = Config;
            }
            else
            {
                Config.RemoveAt(0);
                array = Config;
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(CurrentLoop), 1);
        }

        private static void CurrentLoop(object o)
        {
            while (!exit)
            {
                lock (_Lock)
                {
                    foreach (var cheat in array)
                    {
                        if (string.IsNullOrEmpty(cheat)) continue;
                        foreach (Process Pitems in Process.GetProcesses())
                        {
                            try
                            {
                                if (Pitems.ProcessName.ToLower().Contains(cheat.ToLower()))
                                {
                                    try
                                    {
                                        Pitems.Kill();
                                        Pitems.WaitForExit();
                                        AutoClosingMessageBox.Show("Hack Detectado informando Administradores!!", "SecureGameGuard Hack detected!!", 3000);
                                        continue;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine(e);
                                    }
                                }

                                var desc = FileVersionInfo.GetVersionInfo(Pitems.MainModule.FileName);

                                if (desc.FileDescription.ToLower().Contains(cheat.ToLower()))
                                {
                                    try
                                    {
                                        Pitems.Kill();
                                        Pitems.WaitForExit();
                                        continue;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine(e);
                                    }
                                }
                            }
                            catch
                            {
                            }

                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }

        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string Encrypt(string plainText)
        {
            byte[] bytes1 = Encoding.UTF8.GetBytes(plainText);
            byte[] bytes2 = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(32);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.Zeros;
            ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(VIKey));
            byte[] inArray;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes1, 0, bytes1.Length);
                    cryptoStream.FlushFinalBlock();
                    inArray = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(inArray);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] buffer = Convert.FromBase64String(encryptedText);
            byte[] bytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(32);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.None;
            ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes, Encoding.ASCII.GetBytes(VIKey));
            MemoryStream memoryStream = new MemoryStream(buffer);
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] numArray = new byte[buffer.Length];
            int count = cryptoStream.Read(numArray, 0, numArray.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(numArray, 0, count).TrimEnd("\0".ToCharArray());
        }

    }
}
public class DList
{
    public List<string> Default = new List<string>();
    public DList()
    {
        Default.Add("Cheat Engine");
        Default.Add("Engine");
        Default.Add("Cheat");
        Default.Add("CheatEngine");
        Default.Add("Nopde");
        Default.Add("Jakes");
        Default.Add("Hack");
        Default.Add("Hax");
        Default.Add("Poke");
        Default.Add("ArtMoney");
        Default.Add("ollydbg");
    }
}

public class AutoClosingMessageBox
{
    System.Threading.Timer _timeoutTimer;
    string _caption;

    AutoClosingMessageBox(string text, string caption, int timeout)
    {
        _caption = caption;
        _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
            null, timeout, System.Threading.Timeout.Infinite);
        MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Show(string text, string caption, int timeout)
    {
        new AutoClosingMessageBox(text, caption, timeout);
    }

    private void OnTimerElapsed(object state)
    {
        IntPtr mbWnd = FindWindow(null, _caption);
        if (mbWnd != IntPtr.Zero)
            SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        _timeoutTimer.Dispose();
    }

    const int WM_CLOSE = 0x0010;
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
}

public enum TypeInvoke
{
    Text,
    progressbar,
}

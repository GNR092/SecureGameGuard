/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SecureGameGuard
{
	/// <summary>
	/// SecureGameGuard.
	/// 
	/// Copyright (C) GNR092, 2016-2017.
	/// </summary>
	public static class GameGuard
	{
		static readonly object _Lock = new object();
		private static List<string> array { get; set; }

		

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
			while (!SecureGame.Disconect)
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
										AutoClosingMessageBox.Show("Hack Detectado informando Administradores!!", "SecureGameGuard Hack detected!!", SecureGame.CloseTime);
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
										AutoClosingMessageBox.Show("Hack Detectado informando Administradores!!", "SecureGameGuard Hack detected!!", SecureGame.CloseTime);
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
						Thread.Sleep(100);
					}
				}
			}

			SecureGame.Start = false;
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
			CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] numArray = new byte[buffer.Length];
			int count = cryptoStream.Read(numArray, 0, numArray.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(numArray, 0, count).TrimEnd("\0".ToCharArray());
		}

	}
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace SecureGameGuard
{
	public class GameGuard
	{
		static readonly object _Lock = new object();
		private static List<string> array { get; set;}
		public static bool exit = false;
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
			ThreadPool.QueueUserWorkItem(new WaitCallback(CurrentLoop), Config);
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
										Console.ForegroundColor = ConsoleColor.Yellow;
										string name = Pitems.ProcessName;
										Console.WriteLine("Encontrado {0},\n{1}", name, desc);

										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Cerrando {0}", name);
										Pitems.Kill();
										Pitems.WaitForExit();
										Console.ForegroundColor = ConsoleColor.Green;
										Console.WriteLine("Cerrado {0}", name);
										Console.ResetColor();
										Console.Write(Environment.NewLine);
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

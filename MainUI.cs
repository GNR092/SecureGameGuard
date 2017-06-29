/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace SecureGameGuard
{
	/// <summary>
	/// SecureGameGuard.
	/// 
	/// Copyright (C) GNR092, 2016-2017.
	/// </summary>
	public partial class MainUI : Form
	{
		private Configs cnf = new Configs();
		private string DownloadString = null;
		private List<string> lst0 = null, lst1 = null;
		private bool error = false;
		private bool Down = false;
        private string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();


		public MainUI()
		{
            AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs args)
            {
                string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

                dllName = dllName.Replace(".", "_");

                if (dllName.EndsWith("_resources")) return null;

                System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", Assembly.GetExecutingAssembly());

                byte[] bytes = (byte[])rm.GetObject(dllName);

                return Assembly.Load(bytes);  
            };
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            SecureGame.notify = bf_gmg;
            bf_gmg.ShowBalloonTip(2000, "Notificacion", "Iniciando SecureGameGuard V" + ver, ToolTipIcon.Info);
			this.Show();
			new Thread(() =>
				{
					Invoke(new Action(() => this.Show()));
					Invoke(new Action(() => lb_version.Text = "Version:" + ver));
					var url = new Uri("https://raw.githubusercontent.com/GNR092/LauncherUpdaterPlugin/master/AutoUpdater/GameText.txt");
					var url2 = new Uri("http://192.168.20.197/GameText.txt");

					using (WebClient cli = new WebClient())
					{
						cli.DownloadProgressChanged += cli_DownloadProgressChanged;
						cli.DownloadStringCompleted += cli_DownloadStringCompleted;
						cnf.load();
						try
						{
							cli.DownloadStringAsync(url);
							while (!Down)
							{
								Invoke(new Action(() => Thread.Sleep(500)));
							}
						}
						catch (Exception)
						{

							error = true;
						}
						Thread.Sleep(1000);
						check();

						Invoke(new Action(() => this.Hide()));
					}
				})
			{ IsBackground = false }.Start();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void cli_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			Invoke(new Action(() => progressBarUI1.Value = 0));
			Invoke(new Action(() => progressBarUI1.BackColor = Color.DarkBlue));
			Invoke(new Action(() => progressBarUI1.ForeColor = Color.Blue));
			try
			{
				if (e.Result != null)
				{
					DownloadString = e.Result;
					Down = true;
				}
				else
				{
					Down = true;
					error = true;
				}
			}
			catch
			{
				Down = true;
				error = true;
			}

		}

		void cli_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			Invoke(new Action(() => progressBarUI1.Value = e.ProgressPercentage));
		}

		void check()
		{
            bf_gmg.ShowBalloonTip(1000, "Notificacion", "Preparando componentes", ToolTipIcon.Info);
			Invoke(new Action(() => progressBarUI1.Value = 25));
			if (!error)
			{
				if (cnf.List == null)
				{
					DownloadString = DownloadString.Replace("\r\n", "");
					cnf.List = GameGuard.Encrypt(DownloadString);
					cnf.save();
				}
				else
					DownloadString = DownloadString.Replace("\r\n", "");

				Invoke(new Action(() => progressBarUI1.Value = 50));

				lst0 = DownloadString.Split(char.Parse(",")).ToList();//lista
				lst1 = GameGuard.Decrypt(cnf.List).Split(char.Parse(",")).ToList();//lista desencriptada

				Invoke(new Action(() => progressBarUI1.Value = 75));

				if (lst0[0] != lst1[0])
				{
					cnf.List = GameGuard.Encrypt(DownloadString);
					cnf.save();
				}
			}


			Invoke(new Action(() => progressBarUI1.Value = 100));

			if (!error)
			{
				GameGuard.StartSecureGame(lst0);
			}
			else if (error && cnf.List == null)
			{
				DList Defaultlist = new DList();
				GameGuard.StartSecureGame(Defaultlist.Default, error);
			}
			else if (error && cnf.List != null)
			{
				DList Defaultlist = new DList();
				GameGuard.StartSecureGame(Defaultlist.Default, error);
			}
			Thread.Sleep(1000);
		}

        private void MainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void bf_gmg_Click(object sender, EventArgs e)
        {
            var SuperMsgBox = new SS();
            SuperMsgBox.AgregarTitulo("About");
            SuperMsgBox.AgregarMensaje("''"+Assembly.GetExecutingAssembly().GetName().Name+"''" +"\nVersion: "+ver+" by GNR092");
            SuperMsgBox.AgregarBoton("Donar");
            SuperMsgBox.AgregarBoton("Facebook");
            SuperMsgBox.AgregarBoton("Salir");
            string cmd = SuperMsgBox.Mostrar();
            switch (cmd)
            {
                case "Donar":
                    System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8MJZJBPQHZJG6");
                    break;
                case "Facebook":
                    System.Diagnostics.Process.Start("http://fb.me/GNR092");
                    break;
                default:
                    break;
            }
        }
	}
}

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
       

        public MainUI()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            this.Show();
            new Thread(() =>
                {
                    Invoke(new Action(() => this.Show()));
                    Invoke(new Action(() => lb_version.Text = "Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                    var url = new Uri("https://raw.githubusercontent.com/GNR092/LauncherUpdaterPlugin/master/AutoUpdater/GameText.txt");
                    var url2 = new Uri("http://192.168.20.197/GameText.txt");
                    Thread.Sleep(500);
                    using (WebClient cli = new WebClient())
                    {
                        cli.DownloadProgressChanged += cli_DownloadProgressChanged;
                        cli.DownloadStringCompleted += cli_DownloadStringCompleted;
                        cnf.load();
                        try
                        {
                            cli.DownloadStringAsync(url);
                        }
                        catch (Exception)
                        {

                            error = true;
                        }
                        Thread.Sleep(1000);
                    }
                }) { IsBackground = false }.Start();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void cli_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Invoke(new Action(() => progressBarUI1.Value = 0));
            Invoke(new Action(() => progressBarUI1.BackColor = Color.DarkBlue));
            Invoke(new Action(() => progressBarUI1.ForeColor = Color.Blue));
            DownloadString = e.Result;

            check();

            Invoke(new Action(() => this.Hide()));
        }

        void cli_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new Action(() => progressBarUI1.Value = e.ProgressPercentage));
        }

        void check()
        {
            Invoke(new Action(() => progressBarUI1.Value = 25));
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

            Invoke(new Action(() => progressBarUI1.Value = 100));

            if (!error)
            {
                GameGuard.StartSecureGame(lst0);
            }
            else if(error && cnf.List == null)
            {
                DList Defaultlist = new DList();
                GameGuard.StartSecureGame(Defaultlist.Default, error);
            }
            Thread.Sleep(2000);
        }
    }
}

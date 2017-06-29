/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SecureGameGuard
{
	partial class MainUI
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.progressBarUI1 = new CustomProgressBar.ProgressBarUI();
            this.lb_version = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.bf_gmg = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // progressBarUI1
            // 
            this.progressBarUI1.BackColor = System.Drawing.Color.Brown;
            this.progressBarUI1.ForeColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.progressBarUI1, "progressBarUI1");
            this.progressBarUI1.Name = "progressBarUI1";
            this.progressBarUI1.UseWaitCursor = true;
            // 
            // lb_version
            // 
            resources.ApplyResources(this.lb_version, "lb_version");
            this.lb_version.BackColor = System.Drawing.Color.Transparent;
            this.lb_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_version.Name = "lb_version";
            this.lb_version.Tag = "version";
            this.lb_version.UseWaitCursor = true;
            // 
            // lb_name
            // 
            resources.ApplyResources(this.lb_name, "lb_name");
            this.lb_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_name.Name = "lb_name";
            this.lb_name.Tag = "";
            this.lb_name.UseWaitCursor = true;
            // 
            // bf_gmg
            // 
            resources.ApplyResources(this.bf_gmg, "bf_gmg");
            this.bf_gmg.Click += new System.EventHandler(this.bf_gmg_Click);
            // 
            // MainUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SecureGameGuard.Properties.Resources.Splash;
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.progressBarUI1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainUI";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainUI_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CustomProgressBar.ProgressBarUI progressBarUI1;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.NotifyIcon bf_gmg;
	}
}

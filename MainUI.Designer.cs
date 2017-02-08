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
            this.progressBarUI1 = new CustomProgressBar.ProgressBarUI();
            this.lb_version = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarUI1
            // 
            this.progressBarUI1.BackColor = System.Drawing.Color.Brown;
            this.progressBarUI1.ForeColor = System.Drawing.Color.Crimson;
            this.progressBarUI1.Location = new System.Drawing.Point(10, 215);
            this.progressBarUI1.Name = "progressBarUI1";
            this.progressBarUI1.Size = new System.Drawing.Size(230, 10);
            this.progressBarUI1.TabIndex = 100;
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.BackColor = System.Drawing.Color.Transparent;
            this.lb_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_version.Font = new System.Drawing.Font("Raleway ExtraLight", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.Location = new System.Drawing.Point(60, 193);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(2, 16);
            this.lb_version.TabIndex = 99;
            this.lb_version.Tag = "version";
            this.lb_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_name.Font = new System.Drawing.Font("Raleway ExtraLight", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(53, 172);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(142, 14);
            this.lb_name.TabIndex = 101;
            this.lb_name.Tag = "";
            this.lb_name.Text = "Game Guard By GNR092";
            this.lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SecureGameGuard.Properties.Resources.Splash;
            this.ClientSize = new System.Drawing.Size(250, 236);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.progressBarUI1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameGuard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CustomProgressBar.ProgressBarUI progressBarUI1;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label lb_name;
	}
}

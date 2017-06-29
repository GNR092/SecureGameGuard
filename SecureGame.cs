using System;
using System.Windows.Forms;
namespace SecureGameGuard
{
	public class SecureGame
	{
		public static bool Start = false;
		public static bool Disconect = false;
		public static int CloseTime = 4000;
        public static MainUI GameGuard;
        public static NotifyIcon notify;
        

        public static void Initialize()
        {
            try
            {
                GameGuard = new MainUI();
                StartGameSecure();
            }
            catch (Exception ex)
            {

                MessageBoxAutoClosing.Show(ex, "Error", 10000);
            }
        }
        public static void Initialize(int closetime)
        {
            try
            {
                CloseTime = closetime;
                GameGuard = new MainUI();
                StartGameSecure();
            }
            catch (Exception ex)
            {

                MessageBoxAutoClosing.Show(ex, "Error", 10000);
            }
        }
        public static void Exit()
        {
            if (Start)
            {
                Disconect = false;
                GameGuard.Close();
            }
            else
            {
                MessageBoxAutoClosing.Show("No iniciado nada que parar", "Error", 5000, MessageBoxAutoClosingButtoms.OK, MessageBoxAutoClosingIcon.Error);
            }
        }

		private static void StartGameSecure()
		{
			GameGuard.Show();
			while (GameGuard.Visible)
			{
				System.Windows.Forms.Application.DoEvents();
			}
			Start = true;
		}
	}
}

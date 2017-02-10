using System;
namespace SecureGameGuard
{
	public class SecureGame
	{
		public static bool Start = false;
		public static bool Disconect = false;
		public static int CloseTime = 4000;

		public static void StartGameSecure()
		{
			var GameGuard = new MainUI();
			GameGuard.Show();
			while (GameGuard.Visible)
			{
				System.Windows.Forms.Application.DoEvents();
			}
			Start = true;
		}
	}
}

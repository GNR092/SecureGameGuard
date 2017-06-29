/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SecureGameGuard
{
	public class MessageBoxAutoClosing
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        MessageBoxIcon icons;
        MessageBoxButtons Buttoms;
        #region ctor
        public MessageBoxAutoClosing(string text, int timeout)
        {
            _caption = "inf";
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            MessageBox.Show(text);
        }

        public MessageBoxAutoClosing(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            MessageBox.Show(text, caption);
        }

        public MessageBoxAutoClosing(string text, string caption, int timeout, MessageBoxAutoClosingButtoms buttom)
        {
            _caption = caption;
            icons = (MessageBoxIcon)icon;
            Buttoms = (MessageBoxButtons)buttom;

            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);

            MessageBox.Show(text, caption, Buttoms);
        }

        public MessageBoxAutoClosing(string text, string caption, int timeout, MessageBoxAutoClosingButtoms buttom , MessageBoxAutoClosingIcon icon)
        {
            _caption = caption;
            icons = (MessageBoxIcon)icon;
            Buttoms = (MessageBoxButtons)buttom;

            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);

            MessageBox.Show(text, caption, Buttoms, icons);
        }

        public MessageBoxAutoClosing(string text, string caption, int timeout, MessageBoxAutoClosingIcon icon)
        {
            _caption = caption;
            icons = (MessageBoxIcon)icon;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icons);
        }
        #endregion

        #region Show

        public static void Show(object text, int timeout)
        {
            new MessageBoxAutoClosing(text.ToString(), timeout);
        }
        public static void Show(string text, int timeout)
        {
            new MessageBoxAutoClosing(text, timeout);
        }

        public static void Show(object text, string caption, int timeout)
        {
            new MessageBoxAutoClosing(text.ToString(), caption, timeout);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new MessageBoxAutoClosing(text, caption, timeout);
        }

        public static void Show(string text, string caption, int timeout,MessageBoxAutoClosingButtoms buttom)
        {
            new MessageBoxAutoClosing(text, caption, timeout,buttom);
        }
        public static void Show(object text, string caption, int timeout, MessageBoxAutoClosingButtoms buttom)
        {
            new MessageBoxAutoClosing(text.ToString(), caption, timeout, buttom);
        }

        public static void Show(string text, string caption, int timeout, MessageBoxAutoClosingButtoms buttom, MessageBoxAutoClosingIcon icon)
        {
            new MessageBoxAutoClosing(text, caption, timeout, buttom,icon);
        }
        public static void Show(object text, string caption, int timeout, MessageBoxAutoClosingButtoms buttom, MessageBoxAutoClosingIcon icon)
        {
            new MessageBoxAutoClosing(text.ToString(), caption, timeout, buttom, icon);
        }

        public static void Show(string text, string caption, int timeout,MessageBoxAutoClosingIcon icon)
        {
            new MessageBoxAutoClosing(text, caption, timeout, icon);
        }
        public static void Show(object text, string caption, int timeout, MessageBoxAutoClosingIcon icon)
        {
            new MessageBoxAutoClosing(text.ToString(), caption, timeout, icon);
        }
        #region formats
        public static void Show(string format, int timeout, params object[] args)
        {
            Show(string.Format(format, args), timeout);
        }
        public static void Show(string format, string caption, int timeout, params object[] args)
        {
            Show(string.Format(format, args), caption, timeout);
        }
        public static void Show(string format, string caption, int timeout, MessageBoxAutoClosingIcon icon, params object[] args)
        {
            Show(string.Format(format, args), caption, timeout, icon);
        }
        public static void Show(string format, string caption, int timeout, MessageBoxAutoClosingButtoms buttom, params object[] args)
        {
            Show(string.Format(format, args), caption, timeout, buttom);
        }
        public static void Show(string format, string caption, int timeout, MessageBoxAutoClosingButtoms buttom, MessageBoxAutoClosingIcon icon, params object[] args)
        {
            Show(string.Format(format, args), caption, timeout, buttom,icon);
        }
        #endregion
        #endregion

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow(null, _caption);
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }

        const int WM_CLOSE = 0x0010;
        private string text;
        private string caption;
        private int timeout;
        private MessageBoxAutoClosingIcon icon;
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}

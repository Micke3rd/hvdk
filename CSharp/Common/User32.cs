using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Hvdk.Common
{
	public static partial class User32
	{
		private const string _user32Dll = "user32.dll";

		public static void AppActivate(string Name, int PauseAfterActivation)
		{
			if (string.IsNullOrWhiteSpace(Name))
				throw new ArgumentException($"'{nameof(Name)}' cannot be null or whitespace", nameof(Name));

			//is it already the foreground window?
			var selectedWindow = GetForegroundWindow();
			var WinCaptionEx = new StringBuilder(260);
			GetWindowText(selectedWindow, WinCaptionEx, WinCaptionEx.Capacity);
			if (WinCaptionEx.ToString() == Name)
				return;
			else
			{
				var w = FindWindow(null, Name);
				if (w != IntPtr.Zero)
				{
					SetForegroundWindow(w);
					System.Threading.Thread.Sleep(PauseAfterActivation);
					return;
				}
			}
		}

		[DllImport(_user32Dll, SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport(_user32Dll)]
		static extern IntPtr GetForegroundWindow();

		[DllImport(_user32Dll)]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport(_user32Dll)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
	}
}
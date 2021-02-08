using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;

namespace Hvdk.Common
{
	public static partial class User32
    {
        /// <summary>
        /// returns the presentation, the finally written char, if key is used
        /// </summary>
        public static string KeyCodeToUnicode(Key key)
        {
            var keyboardState = new byte[255];
            var keyboardStateStatus = GetKeyboardState(keyboardState);

            if (!keyboardStateStatus)
                throw new Exception("error?");

            var virtualKeyCode = (uint) KeyInterop.VirtualKeyFromKey(key);
            var scanCode = MapVirtualKey(virtualKeyCode, 0);

            var result = new StringBuilder();
			ToUnicode(virtualKeyCode, scanCode, keyboardState, result, (int)5, (uint)0);
			return result.ToString();
        }

        [DllImport(_user32Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState, 
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);
    }
}

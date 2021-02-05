using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace Hvdk.Common
{
    public static partial class User32
    {
        public static string KeyCodeToUnicode(Keys key)
        {
            var keyboardState = new byte[255];
            var keyboardStateStatus = GetKeyboardState(keyboardState);

            if (!keyboardStateStatus)
            {
                return string.Empty;
            }

            var virtualKeyCode = (uint)key;
            var scanCode = MapVirtualKey(virtualKeyCode, 0);

            //var MAPVK_VK_TO_CHAR = MapVirtualKey(virtualKeyCode, 2);
            //var MAPVK_VSC_TO_VK = MapVirtualKey(virtualKeyCode, 1);
            //var MAPVK_VSC_TO_VK_EX = MapVirtualKey(virtualKeyCode, 3);

            var nonVirtualKey = MapVirtualKey(virtualKeyCode, 2);
            char mappedChar = Convert.ToChar(nonVirtualKey); // works


            var wpfKey = KeyInterop.KeyFromVirtualKey((int)virtualKeyCode);
			//wpfKey = System.Windows.Input.Key.A;
			var formsKey = KeyInterop.VirtualKeyFromKey(wpfKey);



			var inputLocaleIdentifier = GetKeyboardLayout(0);

			var result = new StringBuilder();
            //ToUnicodeEx(virtualKeyCode, scanCode, keyboardState, result, (int)5, (uint)0, inputLocaleIdentifier);
            ToUnicode(virtualKeyCode, scanCode, keyboardState, result, (int)5, (uint)0);

            return result.ToString();
        }

        [DllImport(_user32Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

        /// <summary>
        /// Retrieves the active input locale identifier
        /// </summary>
        /// <param name="idThread">The identifier of the thread to query, or 0 for the current thread</param>
        /// <returns></returns>
        [DllImport(_user32Dll, SetLastError = true)]
        static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, 
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

        [DllImport(_user32Dll, SetLastError = true)]
        static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState,
          [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);


    }
}

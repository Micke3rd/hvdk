using System;
using System.Collections.Generic;

namespace Hvdk.Common
{
	public static class KeyboardUtils
	{
		static List<string> _FKeys;
		static List<string> FKeys
		{
			get
			{
				if (_FKeys == null)
				{
					_FKeys = new List<string>();
					_FKeys.Add("dummy1");
					_FKeys.Add("dummy2");
					_FKeys.Add("dummy3");
					_FKeys.Add("dummy4");
					_FKeys.Add("a");
					_FKeys.Add("b");
					_FKeys.Add("c");
					_FKeys.Add("d");
					_FKeys.Add("e");
					_FKeys.Add("f");
					_FKeys.Add("g");
					_FKeys.Add("h");
					_FKeys.Add("i");
					_FKeys.Add("j");
					_FKeys.Add("k");
					_FKeys.Add("l");
					_FKeys.Add("m");
					_FKeys.Add("n");
					_FKeys.Add("o");
					_FKeys.Add("p");
					_FKeys.Add("q");
					_FKeys.Add("r");
					_FKeys.Add("s");
					_FKeys.Add("t");
					_FKeys.Add("u");
					_FKeys.Add("v");
					_FKeys.Add("w");
					_FKeys.Add("x");
					_FKeys.Add("y");
					_FKeys.Add("z");
					_FKeys.Add("1");
					_FKeys.Add("2");
					_FKeys.Add("3");
					_FKeys.Add("4");
					_FKeys.Add("5");
					_FKeys.Add("6");
					_FKeys.Add("7");
					_FKeys.Add("8");
					_FKeys.Add("9");
					_FKeys.Add("0");
					_FKeys.Add("ENTER");
					_FKeys.Add("ESCAPE");
					_FKeys.Add("BACKSPACE");
					_FKeys.Add("TAB");
					_FKeys.Add("SPACEBAR");
					_FKeys.Add("-");
					_FKeys.Add("=");
					_FKeys.Add("[");
					_FKeys.Add("]");
					_FKeys.Add("\\");
					_FKeys.Add("");
					_FKeys.Add(";");
					_FKeys.Add("dummy5");
					_FKeys.Add("`");
					_FKeys.Add(",");
					_FKeys.Add(".");
					_FKeys.Add("/");
					_FKeys.Add("CAPSLOCK");
					_FKeys.Add("F1");
					_FKeys.Add("F2");
					_FKeys.Add("F3");
					_FKeys.Add("F4");
					_FKeys.Add("F5");
					_FKeys.Add("F6");
					_FKeys.Add("F7");
					_FKeys.Add("F8");
					_FKeys.Add("F9");
					_FKeys.Add("F10");
					_FKeys.Add("F11");
					_FKeys.Add("F12");
					_FKeys.Add("PRINTSCREEN");
					_FKeys.Add("SCROLLLOCK");
					_FKeys.Add("PAUSE");
					_FKeys.Add("INSERT");
					_FKeys.Add("HOME");
					_FKeys.Add("PAGEUP");
					_FKeys.Add("DELETE");
					_FKeys.Add("END");
					_FKeys.Add("PAGEDOWN");
					_FKeys.Add("RIGHTARROW");
					_FKeys.Add("LEFTARROW");
					_FKeys.Add("DOWNARROW");
					_FKeys.Add("UPARROW");
					_FKeys.Add("NUMLOCK");
					_FKeys.Add("K/");
					_FKeys.Add("K*");
					_FKeys.Add("K-");
					_FKeys.Add("K+");
					_FKeys.Add("KENTER");
					_FKeys.Add("K1");
					_FKeys.Add("K2");
					_FKeys.Add("K3");
					_FKeys.Add("K4");
					_FKeys.Add("K5");
					_FKeys.Add("K6");
					_FKeys.Add("K7");
					_FKeys.Add("K8");
					_FKeys.Add("K9");
					_FKeys.Add("K0");
					_FKeys.Add("K.");
					_FKeys.Add("F13");
					_FKeys.Add("F14");
					_FKeys.Add("F15");
					_FKeys.Add("F16");
					_FKeys.Add("F17");
					_FKeys.Add("F18");
					_FKeys.Add("F19");
					_FKeys.Add("F20");
					_FKeys.Add("F21");
					_FKeys.Add("F22");
					_FKeys.Add("F23");
					_FKeys.Add("F24"); //115
				}
				return _FKeys;
			}
		}


		static List<string> _FModifiers;
		static List<string> FModifiers
		{
			get
			{
				if (_FModifiers == null)
				{
					_FModifiers = new List<string>();
					//the [ and ] and text is arbitrary. You can call the modifiers whatever you like, as long as the list order is preserved
					_FModifiers.Add("[LCTRL]");
					_FModifiers.Add("[LSHIFT]");
					_FModifiers.Add("[LALT]");
					_FModifiers.Add("[LWIN]");
					_FModifiers.Add("[RCTRL]");
					_FModifiers.Add("[RSHIFT]");
					_FModifiers.Add("[RALT]");
					_FModifiers.Add("[RWIN]");
				}
				return _FModifiers;
			}
		}

		//keys and modifers must be converted to keycodes
		//this is based specs in /common/hut1_12v2.pdf
		//special keycodes for modifiers like shift and control

		public static byte GetModifierKeyCode(string modifier)
		{
			var i = FModifiers.IndexOf(modifier);
			if (i == -1) { return 0; } else { return (byte)i; };
		}


		public static byte GetKeyKeyCode(string key)
		{
			if (key.Length == 1)
				key = key.ToLower();
			var i = FKeys.IndexOf(key);
			if (i < 0)
				throw new ArgumentOutOfRangeException(nameof(key), key);

			return (byte)i;
		}	
	}
}



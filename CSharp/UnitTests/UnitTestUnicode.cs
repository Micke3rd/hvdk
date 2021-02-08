using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Hvdk.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using System;
using System.Linq;

namespace UnitTests
{
	[TestClass]
	public class UnitTestUnicode
	{
		CultureInfo _arabic = CultureInfo.GetCultureInfo("ar-EG");
		[TestMethod]
		public void TestArabicKeyboard()
		{
			CheckIfKeyboardLayoutIsInstalled(_arabic);

			var actual = User32.KeyCodeToUnicode(Key.Oem1);
			Assert.AreEqual("ك", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem3);
			Assert.AreEqual("ذ", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem7);
			Assert.AreEqual("ط", actual);
		}


		CultureInfo _german = CultureInfo.GetCultureInfo("de-DE");
		[TestMethod]
		public void TestGermanKeyboard			()
		{
			CheckIfKeyboardLayoutIsInstalled(_german);

			var actual = User32.KeyCodeToUnicode(Key.Oem1);
			Assert.AreEqual("ü", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem3);
			Assert.AreEqual("ö", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem7);
			Assert.AreEqual("ä", actual);
			actual = User32.KeyCodeToUnicode(Key.Y);
			Assert.AreEqual("y", actual);

		}


		CultureInfo _russian = CultureInfo.GetCultureInfo("ru-RU");
		[TestMethod]
		public void TestRussianKeyboard			()
		{
			CheckIfKeyboardLayoutIsInstalled(_russian);

			var actual = User32.KeyCodeToUnicode(Key.Oem1);
			Assert.AreEqual("ж", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem3);
			Assert.AreEqual("ё", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem7);
			Assert.AreEqual("э", actual);
		}

		CultureInfo _english = CultureInfo.GetCultureInfo("en-US");
		[TestMethod]
		public void TestEnglishKeyboard()
		{
			CheckIfKeyboardLayoutIsInstalled(_english);

			var actual = User32.KeyCodeToUnicode(Key.Oem1);
			Assert.AreEqual(";", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem3);
			Assert.AreEqual("`", actual);
			actual = User32.KeyCodeToUnicode(Key.Oem7);
			Assert.AreEqual("'", actual);
			actual = User32.KeyCodeToUnicode(Key.Y);
			Assert.AreEqual("y", actual);
		}

		private static void CheckIfKeyboardLayoutIsInstalled(CultureInfo ci)
		{
			var msg = ci.Name + " keyboard (language) is not installed";
			var il = InputLanguage.FromCulture(ci);

			Assert.IsNotNull(il, msg);

			var found = false;
			foreach (var e in InputLanguage.InstalledInputLanguages)
				if (il.Equals(e))
				{
					found = true;
					break;
				}

			Assert.IsTrue(found, msg);

			InputLanguage.CurrentInputLanguage = il;
		}


		[TestMethod]
		public void HowToListAllEnumValues()
		{
			//e.g. for russian
			InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(_russian);

			var list = new Dictionary<string, Key>();
			foreach (var e in Enum.GetValues<System.Windows.Input.Key>())
			{
				if (Enum.GetNames<System.Windows.Input.ModifierKeys>().Contains(e.ToString()))
					continue;

				list[User32.KeyCodeToUnicode(e)] = e;
			}
		}

		[TestMethod]
		public void HowToConvertWpfIntoWinformsAndBack()
		{
			var formsKey = Keys.Control;
			var wpfKey = KeyInterop.KeyFromVirtualKey((int)formsKey);
			wpfKey = System.Windows.Input.Key.A;
			formsKey = (Keys)KeyInterop.VirtualKeyFromKey(wpfKey);
		}

	}


}


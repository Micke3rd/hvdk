using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Hvdk.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace UnitTests
{
	[TestClass]
	public class UnitTestUnicode

	{
		[TestMethod]
		public void Test1()
		{
			var old = CultureInfo.CurrentCulture;
			var actual = User32.KeyCodeToUnicode(System.Windows.Forms.Keys.Oem3);
			Assert.AreEqual("ö", actual);

			try
			{
				//var dict = new Dictionary<string, CultureInfo>();
				//foreach (var ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
				//{
				//	dict.Add(ci.Name, ci);
				//	if ("zh".Equals(ci.Name))
				//	{

				//	}
				//}
				var kc = new KeysConverter(); 
				string keyChar = kc.ConvertToString(System.Windows.Forms.Keys.Oem3);
				keyChar = kc.ConvertToString(null,old,System.Windows.Forms.Keys.Oem3);

				var kc2 = new KeyConverter();
				string keyChar2 = kc.ConvertToString(Key.Oem3);
				keyChar = kc.ConvertToString(null, old, Key.Oem3);




				var ci = CultureInfo.GetCultureInfo("zh");
				CultureInfo.CurrentCulture = ci;
				CultureInfo.CurrentUICulture = ci;

				actual = User32.KeyCodeToUnicode(System.Windows.Forms.Keys.Y);
				Assert.AreEqual("y", actual);


				ci = CultureInfo.GetCultureInfo("de");
				CultureInfo.CurrentCulture = ci;
				CultureInfo.CurrentUICulture = ci;
			}
			finally
			{
				CultureInfo.CurrentCulture = old;
			}

	

			//		KeyboardLayoutId	7	int
			//		LCID    7   int
			//		"de".Equals(ci.Name)

			//		KeyboardLayoutId	9	int
			//		LCID    9   int
			//		"en".Equals(ci.Name)

			//		KeyboardLayoutId    8   int
			//		LCID    8   int
			//		Name    "el"    string

			//		KeyboardLayoutId    30724   int
			//		LCID    30724   int
			//		Name    "zh"    string


			

	

		}

	}


}


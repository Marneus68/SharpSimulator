﻿using System;
using System.Collections.Generic;

namespace SharpSimulator
{
	public class TextUtils {
		public static string StringListToString(List<string> list) {
			string ret = "";
			foreach(var s in list) {
				ret += s;
				ret += ", ";
			}
			return ret;
		}

		public static void OptionalPrint(string str) {
			if (str == "")
				System.Console.WriteLine (str);
		}
	}
}


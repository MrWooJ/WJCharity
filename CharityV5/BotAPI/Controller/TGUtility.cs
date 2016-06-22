using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using TGModels;
using TGController;
using TGFileManager;

namespace TGUtility
{
	public class TGUtilityClass
	{
		public static string TimeStampForNow()
		{
			Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			return unixTimestamp.ToString();
		}

		public static string StringOfCity(string cityName)
		{
			if (cityName.Contains("تهران"))
			return "Tehran";
			else if (cityName.Contains("اصفهان"))
			return "Isfahan";
			else if (cityName.Contains("مازندران"))
			return "Mazandaran";
			else if (cityName.Contains("گیلان"))
			return "Gilan";
			else if (cityName.Contains("خراسان رضوی"))
			return "Khorasan-Razavi";
			else if (cityName.Contains("آذربایجان غربی"))
			return "Azarbayjan-Gharbi";
			return "Other";
		}

		public static string StringOfArabicNumbers(string arbNumber)
		{
			string EnglishNumbers="";
			for (int i = 0; i < arbNumber.Length; i++){
				EnglishNumbers += char.GetNumericValue(arbNumber, i);
			}
			return EnglishNumbers;
		}
	}
}
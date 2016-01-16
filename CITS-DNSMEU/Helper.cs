using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crestline.DNSMEU
{
	public static class Helper
	{
		public async static Task<string> UpdateDNSRecord(string DNSRecordId, string Password, string IP)
		{
			var webClient = new WebClient();

			var result = await webClient.DownloadStringTaskAsync(string.Format("https://cp.dnsmadeeasy.com/servlet/updateip?password={0}&id={1}&ip={2}", Password, DNSRecordId, IP));

			return result;
		}

		public static string GetLastIP()
		{
			try
			{
				return ConfigurationManager.AppSettings["LastIP"];
			}
			catch
			{
				return null;
			}
		}

		public static void UpdateIP(string IP)
		{
			UpdateSetting("LastIP", IP);
		}

		public static void UpdateSetting(string key, string value)
		{
			try
			{
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				var settings = configFile.AppSettings.Settings;
				if (settings[key] == null)
				{
					settings.Add(key, value);
				}
				else
				{
					settings[key].Value = value;
				}
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			catch (ConfigurationErrorsException)
			{
				//TODO: Log somewhere
			}
		}
	}
}

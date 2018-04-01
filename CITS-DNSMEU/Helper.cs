using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crestline.DNSMEU
{
	public static class Helper
	{
		public const string LastIP = "LastIP";
		public const string DNSRecordID = "DNSRecordID";
		public const string Password = "Password";
		public const string ProductName = "Crestline DNSMEU";
		public const string IP_URL = "https://www.crestline.net/myip.php";

		public async static Task<string> UpdateDNSRecord(string DNSRecordId, string Password, string IP)
		{
			var webClient = new WebClient();

			var result = await webClient.DownloadStringTaskAsync(string.Format("https://cp.dnsmadeeasy.com/servlet/updateip?password={0}&id={1}&ip={2}", Password, DNSRecordId, IP));

			return result;
		}

		public static string GetSetting(string key)
		{
			try
			{
				return ConfigurationManager.AppSettings[key];
			}
			catch
			{
				return null;
			}
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
				Log(string.Format("Excpetion while updating setting '{0}' with value '{1}'", key, value), EventLogEntryType.Error);
			}
		}

		public static void CheckForDNSUpdate()
		{
			//refresh config file in case it changed
			var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			var dnsRecordID = GetSetting(DNSRecordID);
			var password = GetSetting(Password);
			var lastIP = GetSetting(LastIP);

			if (string.IsNullOrEmpty(dnsRecordID))
			{
				Log("No DNS Record ID found in settings. Run executable to save settings.", EventLogEntryType.Error);
				return;
			}
			if (string.IsNullOrEmpty(password))
			{
				Log("No Password found in settings. Run executable to save settings.", EventLogEntryType.Error);
				return;
			}

			var webClient = new WebClient();
			var currentIP = webClient.DownloadString(Helper.IP_URL);

			if (IsIPAddress(currentIP))
			{
				if (currentIP != lastIP)
				{
					//different values and new one is an IP format jsut in case, so update value
					var result = webClient.DownloadString(string.Format("https://cp.dnsmadeeasy.com/servlet/updateip?password={0}&id={1}&ip={2}", password, dnsRecordID, currentIP));
					if (result == "success")
					{
						Log("Record updated successfully", EventLogEntryType.Information);
					}
					else
					{
						Log(string.Format("Record may not have been updated successfully. Result is '{0}'", result), EventLogEntryType.Warning);
					}
				}
				else
				{
					Log("Not updating. Current IP matches the LastIP", EventLogEntryType.Information);
				}
			}
			else
			{
				Log(string.Format("Not updating because currenty IP obtained '{0}' is not an IP format", currentIP), EventLogEntryType.Warning);
			}
		}

		public static bool IsIPAddress(string IP)
		{
			try
			{
				Match match = Regex.Match(IP, @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
				return match.Success;
			}
			catch
			{
				return false;
			}
		}
		public static void Log(string message, System.Diagnostics.EventLogEntryType type)
		{
			var log = new System.Diagnostics.EventLog("Application");
			log.Source = Helper.ProductName;
			log.WriteEntry(message, type);
		}
	}
}

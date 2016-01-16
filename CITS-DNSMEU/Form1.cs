using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crestline.DNSMEU
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.GetPublicIP();

		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "";
			this.UpdateRecord();
		}

		private async void GetPublicIP()
		{
			var webClient = new WebClient();
			string IP = await webClient.DownloadStringTaskAsync("http://www.dnsmadeeasy.com/myip.jsp");

			txtIP.Text = IP;
			Helper.UpdateIP(IP);
		}

		private async void UpdateRecord()
		{
			var result = await Helper.UpdateDNSRecord(txtDNSRecordID.Text, txtPassword.Text, txtIP.Text);
			lblStatus.Text = result;
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			Helper.UpdateSetting("DNSRecordID", txtDNSRecordID.Text);
			Helper.UpdateSetting("Password", txtPassword.Text);
		}
	}
}

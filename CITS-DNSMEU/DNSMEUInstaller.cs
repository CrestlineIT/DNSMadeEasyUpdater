using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Crestline.DNSMEU
{
	[RunInstaller(true)]
	public partial class DNSMEUInstaller : System.Configuration.Install.Installer
	{
		private bool serviceExists = false;

		public DNSMEUInstaller()
		{
			InitializeComponent();

			this.BeforeInstall += DNSMEUInstaller_BeforeInstall;
			this.Committed += DNSMEUInstaller_Committed;
		}

		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);

			try
			{
				if (!this.serviceExists)
				{
					var spi = new ServiceProcessInstaller();

					spi.Account = ServiceAccount.LocalSystem;
					var si = new ServiceInstaller();
					si.StartType = ServiceStartMode.Automatic;

					si.ServiceName = Helper.ProductName;

					Installers.Add(si);
					Installers.Add(spi);

					var eli = new EventLogInstaller();
					eli.Log = "Application";
					eli.Source = Helper.ProductName;

					Installers.Add(eli);
				}
			}
			catch (Exception ex)
			{
				this.Rollback(stateSaver);
			}
		}

		private void DNSMEUInstaller_BeforeInstall(object sender, InstallEventArgs e)
		{
			try
			{
				var svc = new ServiceController(Helper.ProductName);
				if (svc != null)
				{
					this.serviceExists = true;
					svc.Stop();
				}
			}
			catch { }
		}

		private void DNSMEUInstaller_Committed(object sender, InstallEventArgs e)
		{
			try
			{
				var svc = new ServiceController(Helper.ProductName);
				svc.Start();
			}
			catch
			{
				Helper.Log("Exception starting service", EventLogEntryType.Error);
			}
		}
	}
}

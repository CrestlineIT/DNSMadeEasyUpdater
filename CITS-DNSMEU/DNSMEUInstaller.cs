using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Crestline.DNSMEU
{
	[RunInstaller(true)]
	public partial class DNSMEUInstaller : System.Configuration.Install.Installer
	{
		public DNSMEUInstaller()
		{
			InitializeComponent();

			var spi = new ServiceProcessInstaller();

			spi.Account = ServiceAccount.LocalService;
			var si = new ServiceInstaller();
			si.StartType = ServiceStartMode.Automatic;

			var title = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;
			si.ServiceName = title;

			Installers.Add(si);
			Installers.Add(spi);
		}
	}
}

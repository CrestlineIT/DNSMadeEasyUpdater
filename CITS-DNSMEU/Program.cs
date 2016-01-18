using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crestline.DNSMEU
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (Environment.UserInteractive)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
			else
			{
				System.ServiceProcess.ServiceBase.Run(new CrestlineDNSMEU());
			}
		}
	}
}

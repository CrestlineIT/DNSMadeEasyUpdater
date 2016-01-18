using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Crestline.DNSMEU
{
	partial class CrestlineDNSMEU : ServiceBase
	{
		private System.Timers.Timer timer;

		public CrestlineDNSMEU()
		{
			InitializeComponent();
			this.ServiceName = "Crestline DNSMEU";
		}

		protected override void OnStart(string[] args)
		{
			this.timer = new System.Timers.Timer(15 * 60 * 1000);
			this.timer.AutoReset = true;
			this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
			this.timer.Start();
			this.timer_Elapsed(null, null);
		}

		protected override void OnStop()
		{
			this.timer.Stop();
			this.timer = null;
		}
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Helper.CheckForDNSUpdate();
		}
	}
}

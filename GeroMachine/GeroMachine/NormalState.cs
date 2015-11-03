using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public class NormalState : State
	{
		public NormalState(Trigger[] triggers) : base(triggers) { }

		/// <summary>
		/// なにかイベントが発生していたらそのイベントIDを返す.
		/// </summary>
		/// <returns>とりあえず0固定</returns>
		public override uint CheckTrigger()
		{
			return MonitoredTriggers[0].Id;
		}
	}
}

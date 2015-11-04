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
		/// なにかトリガが発生していたらそのトリガIDを返す.
		/// </summary>
		public override uint CheckTrigger()
		{
			foreach(Trigger trigger in MonitoredTriggers)
			{
				if (trigger.HasOccured)
				{
					return trigger.Id;
				}
			}

			return 0;
		}
	}
}

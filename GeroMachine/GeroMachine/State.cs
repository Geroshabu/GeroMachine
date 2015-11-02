using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public abstract class State
	{
		/// <summary>
		/// このステートで発生するトリガ
		/// </summary>
		private Trigger[] MonitoredTriggers;

		public State(Trigger[] triggers)
		{
			MonitoredTriggers = triggers;
		}

		/// <summary>
		/// なにかイベントが発生していたらそのイベントIDを返す.
		/// </summary>
		/// <returns>イベントID</returns>
		public abstract int CheckTrigger();
	}
}

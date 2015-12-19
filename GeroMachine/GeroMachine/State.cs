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
		/// この状態を識別するための情報 (デバッグ用)
		/// </summary>
		public string StateName { get; set; }

		/// <summary>
		/// このステートで発生するトリガ
		/// </summary>
		protected Trigger[] MonitoredTriggers;

		public State(Trigger[] triggers)
		{
			MonitoredTriggers = triggers;
		}
	}
}

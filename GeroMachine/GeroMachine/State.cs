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

		public State(Trigger[] triggers)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public class State
	{
		/// <summary>
		/// なにかイベントが発生していたらそのイベントIDを返す.
		/// </summary>
		/// <returns>とりあえず0固定</returns>
		public virtual int CheckTrigger()
		{
			return 0;
		}
	}
}

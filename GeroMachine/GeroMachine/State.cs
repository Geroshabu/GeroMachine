using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	/// <summary>
	///	状態の種類
	/// </summary>
	public enum StateType
	{
		NormalState,
		EndState
	}

	public abstract class State
	{
		/// <summary>
		/// この状態を識別するための情報 (デバッグ用)
		/// </summary>
		public string StateName { get; set; }

		/// <summary>
		/// この状態の種類
		/// </summary>
		public StateType StateType { get; private set; }

		public State()
		{
		}
	}
}

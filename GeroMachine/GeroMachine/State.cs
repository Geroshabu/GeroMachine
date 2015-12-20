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

		/// <summary>
		/// <see cref="State"/>クラスの新しいインスタンスを初期化する.
		/// </summary>
		/// <remarks>このコンストラクタは, <see cref="State"/>から派生するクラスからだけ呼び出される.</remarks>
		/// <param name="stateType">この<see cref="State"/>の種類.</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// 引数<paramref name="stateType"/>の値が, <see cref="StateType"/>の定義に含まれない.
		/// </exception>
		public State(StateType stateType)
		{
		}
	}
}

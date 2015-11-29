using System;
using System.Collections.Generic;

namespace GeroMachine
{
	/// <summary>
	/// 状態遷移表を管理する機能を提供する
	/// </summary>
	public class TransitionMatrix : ITransitionMatrix
	{
		/// <summary>
		/// 遷移表の本体
		/// </summary>
		private Dictionary<State, Dictionary<Trigger, Transition>> MatrixData;

		/// <summary>
		/// <see cref="TransitionMatrix"/>クラスの新しいインスタンスを初期化する.
		/// </summary>
		/// <param name="matrix">遷移表のもとになる2次元ハッシュテーブル</param>
		/// <exception cref="ArgumentNullException">引数<paramref name="transitionMatrix"/>がnull</exception>
		public TransitionMatrix(Dictionary<State, Dictionary<Trigger, Transition>> transitionMatrix)
		{
			if (transitionMatrix == null)
			{
				throw new ArgumentNullException("transitionMatrix");
			}

			MatrixData = transitionMatrix;
		}

		/// <summary>
		/// 状態が<paramref name="currentState"/>のときにトリガ<paramref name="trigger"/>が発生した場合の,
		/// 起こる遷移を取得する.
		/// </summary>
		/// <param name="currentState">現在の状態</param>
		/// <param name="trigger">発生したトリガ</param>
		/// <returns><paramref name="currentState"/>で<paramref name="trigger"/>が発生したときに起こる遷移.
		/// 起こる遷移が無ければ, nullが返る.</returns>
		/// <exception cref="ArgumentNullException">引数<paramref name="currentState"/>がnull,
		/// または引数<paramref name="trigger"/>がnull.</exception>
		/// <exception cref="ArgumentOutOfRangeException">引数<paramref name="currentState"/>が,
		/// 状態遷移表に存在しない.</exception>
		public ITransition SearchTransition(State currentState, Trigger trigger)
		{
			if (currentState == null)
			{
				throw new ArgumentNullException("currentState");
			}
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}
			if (MatrixData.ContainsKey(currentState) == false)
			{
				throw new ArgumentOutOfRangeException("currentState");
			}

			if (MatrixData[currentState].ContainsKey(trigger))
			{
				return MatrixData[currentState][trigger];
			}

			return null;
		}
	}
}

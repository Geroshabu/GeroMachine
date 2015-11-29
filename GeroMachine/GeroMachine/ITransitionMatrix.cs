namespace GeroMachine
{
	/// <summary>
	/// 状態遷移表を管理するためのメソッドを定義する
	/// </summary>
	interface ITransitionMatrix
	{
		/// <summary>
		/// 状態が<paramref name="currentState"/>のときにトリガ<paramref name="trigger"/>が発生した場合の,
		/// 起こる遷移を取得する.
		/// </summary>
		/// <param name="currentState">現在の状態</param>
		/// <param name="trigger">発生したトリガ</param>
		/// <returns><paramref name="currentState"/>で<paramref name="trigger"/>が発生したときに起こる遷移</returns>
		ITransition SearchTransition(State currentState, Trigger trigger);
	}
}

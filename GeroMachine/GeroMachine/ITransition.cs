namespace GeroMachine
{
	interface ITrantision
	{
		/// <summary>
		/// この遷移を実行する.
		/// </summary>
		/// <returns>遷移先の状態</returns>
		State Execute();
	}
}

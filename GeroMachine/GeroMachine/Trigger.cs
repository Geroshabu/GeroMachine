namespace GeroMachine
{
	public class Trigger
	{
		/// <summary>
		/// <see cref="HasOccured"/>プロパティのフィールド
		/// </summary>
		private bool _HasOccured;

		/// <summary>
		/// トリガが発生したかどうかを取得する.
		/// <para>
		/// このプロパティによりトリガの発生状況を取得した後は,
		/// このプロパティ値はfalseになる.
		/// </para>
		/// </summary>
		/// <value>トリガが発生していればtrue, 発生していなければfalse</value>
		public bool HasOccured
		{
			get
			{
				bool ans = _HasOccured;
				_HasOccured = false;
				return ans;
			}
			protected set { _HasOccured = value; }
		}

		/// <summary>
		/// このトリガのID
		/// </summary>
		/// <remarks>これはユーザに関係ない情報. 後で消す.</remarks>
		public uint Id { get; protected set; }

		/// <summary>
		/// <seealso cref="Id"/>を採番するための値.
		/// </summary>
		private static uint CountOfTrigger = 0;

		/// <summary>
		/// <see cref="Trigger"/>クラスの新しいインスタンスを初期化する.
		/// </summary>
		public Trigger()
		{
			HasOccured = false;
			Id = CountOfTrigger;
			CountOfTrigger++;
		}
	}
}

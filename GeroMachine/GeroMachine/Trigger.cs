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
		/// このプロパティ値は<c>false</c>になる.
		/// </para>
		/// </summary>
		/// <value>トリガが発生していれば<c>true</c>, 発生していなければ<c>false</c></value>
		public bool HasOccured { get; protected set; }

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

using System;

namespace GeroMachine
{
	/// <summary>
	/// ある状態への遷移
	/// </summary>
	public class Transition : ITransition
	{
		/// <summary>
		/// 遷移時に実行される処理のデリゲート
		/// </summary>
		public delegate void TransitionMethodDelegate();

		/// <summary>
		/// 遷移時に実行される処理
		/// </summary>
		private TransitionMethodDelegate TransitionMethod;

		/// <summary>
		/// 遷移先の状態
		/// </summary>
		private State NextState;

		/// <summary>
		/// <see cref="Transition"/>クラスの新しいインスタンスを初期化する.
		/// </summary>
		/// <param name="nextState">遷移先の状態.
		/// nullを指定すると, この遷移は内部遷移となる.(NotImplemented)</param>
		/// <param name="transitionMethod">遷移時に実行する処理.
		/// <see cref="Execute"/>を実行したときに, ここで指定した処理が実行される.
		/// 実行する処理が無い場合は, nullを指定する</param>
		public Transition(State nextState, TransitionMethodDelegate transitionMethod)
		{
			if (nextState == null)
			{
				throw new NotImplementedException();
			}

			NextState = nextState;
			TransitionMethod = transitionMethod;
		}

		/// <summary>
		/// この遷移を実行する.
		/// <para>実行時には, コンストラクタで指定した処理も実行される.</para>
		/// </summary>
		/// <returns>遷移先の状態</returns>
		public State Execute()
		{
			if (TransitionMethod != null)
			{
				TransitionMethod();
			}

			return NextState;
		}
	}
}

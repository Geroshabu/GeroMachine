using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public class StateMachine
	{
		private State CurrentState;
		private ITransitionMatrix TransitionMatrixData;

		/// <summary>
		/// このステートマシンが動作中かどうかを取得.
		/// </summary>
		/// <value>true : 動作中, false : 終了状態に到達済み</value>
		public bool IsWorking { get; private set; }

		/// <summary>
		/// 初期状態と状態遷移表を指定し,
		/// <see cref="StateMachine"/>クラスのインスタンスを初期化する.
		/// </summary>
		/// <param name="initialState">初期状態</param>
		/// <param name="matrixData">状態遷移表</param>
		/// <exception cref="ArgumentNullException">引数<paramref name="initialState"/>がnull,
		/// または引数<paramref name="matrixData"/>がnull.</exception>
		public StateMachine(State initialState, ITransitionMatrix matrixData)
		{
			if (initialState == null)
			{
				throw new ArgumentNullException("initialState");
			}
			if (matrixData == null)
			{
				throw new ArgumentNullException("matrixData");
			}

			CurrentState = initialState;
			TransitionMatrixData = matrixData;
			IsWorking = true;
		}

		/// <summary>
		/// このステートマシンにトリガーを入力する
		/// </summary>
		/// <remarks>
		/// ステートマシンにトリガーを入力すると,
		/// このステートマシンが持っている状態遷移表に従って遷移が発生し,
		/// 現在の状態が遷移後の状態に更新される.
		/// トリガーに対する遷移が定義されていない場合は, 何もしない.
		/// </remarks>
		/// <param name="trigger">入力するトリガー</param>
		/// <exception cref="ArgumentNullException">引数<paramref name="trigger"/>がnull.</exception>
		/// <exception cref="InvalidOperationException">現在の状態が状態遷移表に存在しない.
		/// 状態遷移表の設定ミスなどによる.</exception>
		public void InputTrigger(Trigger trigger)
		{
			if (trigger == null)
			{
				throw new ArgumentNullException("trigger");
			}

			System.Diagnostics.Debug.Assert(CurrentState != null);

			ITransition transition;
			try
			{
				transition = TransitionMatrixData.SearchTransition(CurrentState, trigger);
			}
			catch (ArgumentOutOfRangeException e)
			{
				throw new InvalidOperationException("現在の状態は, 状態遷移表に登録されていません.", e);
			}

			if (transition != null)
			{
				CurrentState = transition.Execute();
			}

			if (CurrentState.StateType == StateType.EndState)
			{
				IsWorking = false;
			}
		}

		/// <summary>
		/// 現在の状態が何なのかを識別するための名前 (デバッグ用)
		/// </summary>
		public string CurrentStateName
		{
			get
			{
				return CurrentState.StateName;
			}
		}
	}
}

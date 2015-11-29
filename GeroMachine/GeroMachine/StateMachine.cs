using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public class StateMachine
	{
		private int CurrentStateId;
		private State[] States;
		private int[,] TransitionMatrix;

		private State CurrentState;
		private ITransitionMatrix TransitionMatrixData;

		public delegate void ShowMethod(int currentStateId);
		/// <summary>
		/// デバッグのために, 現在のステートを表示するメソッドを持っておく.
		/// </summary>
		public ShowMethod CurrentStateShowMethod { get; set; }

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
			throw new NotImplementedException();
		}

		public StateMachine(State[] stateList, int[,] transitionMatrix)
		{
			States = stateList;
			CurrentStateId = 0;

			TransitionMatrix = transitionMatrix;
		}

		/// <summary>
		/// ステートマシンの非同期実行
		/// </summary>
		public void RunAsync()
		{
			System.Threading.Tasks.Task task = new Task(this.Run);
			task.Start();
		}

		/// <summary>
		/// ステートマシンの実行
		/// </summary>
		public void Run()
		{
			while (true)
			{
				uint trigger = States[CurrentStateId].CheckTrigger();
				int next_state_index = TransitionMatrix[CurrentStateId, trigger];
				CurrentStateId = next_state_index;

				if (CurrentStateShowMethod != null)
				{
					CurrentStateShowMethod(CurrentStateId);
				}

				System.Threading.Thread.Sleep(500);
			}
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
			throw new NotImplementedException();
		}
	}
}

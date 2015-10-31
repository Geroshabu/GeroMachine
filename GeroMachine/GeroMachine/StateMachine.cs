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

		public delegate void ShowMethod(int currentStateId);
		/// <summary>
		/// デバッグのために, 現在のステートを表示するメソッドを持っておく.
		/// </summary>
		public ShowMethod CurrentStateShowMethod { get; set; }

		public StateMachine()
		{
			States = new State[3]
			{
				new State(),
				new State(),
				new State()
			};
			CurrentStateId = 0;

			TransitionMatrix = new int[3, 1]
			{
				{ 1 },
				{ 2 },
				{ 0 }
			};
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
				int trigger = States[CurrentStateId].CheckTrigger();
				int next_state_index = TransitionMatrix[CurrentStateId, trigger];
				CurrentStateId = next_state_index;

				if (CurrentStateShowMethod != null)
				{
					CurrentStateShowMethod(CurrentStateId);
				}

				System.Threading.Thread.Sleep(500);
			}
		}
	}
}

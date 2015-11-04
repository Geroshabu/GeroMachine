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
	}
}

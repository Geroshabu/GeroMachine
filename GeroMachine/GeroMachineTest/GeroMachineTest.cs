using Xunit;
using System.Reflection;

namespace GeroMachineTest
{
	public class GeroMachineTest
	{
		/// <summary>
		/// StateMachineを作成する前のテスト
		/// </summary>
		public class BeforeCreationTest
		{
			/// <summary>
			/// 1個のステート, 1個のトリガだけの遷移表で
			/// ステートマシンを作成する.
			/// </summary>
			[Fact]
			public void CreateSimpleStateMachine()
			{
				// Prepare datas
				int initial_current_state_id = 0;
				GeroMachine.State[] states = new GeroMachine.State[1]
				{
					new GeroMachine.NormalState()
				};
				int[,] transition_matrix = new int[1, 1]
				{
					{0 }
				};

				// Execute
				var state_machine = new GeroMachine.StateMachine(states, transition_matrix);

				// Get result value
				FieldInfo field_info;
				GeroMachine.State[] result_states;
				int[,] result_transition_matrix;
				int result_current_state_id;

				field_info = state_machine.GetType().GetField("States",
					BindingFlags.GetField | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				result_states = (GeroMachine.State[])field_info.GetValue(state_machine);
				field_info = state_machine.GetType().GetField("TransitionMatrix",
					BindingFlags.GetField | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				result_transition_matrix = (int[,])field_info.GetValue(state_machine);
				field_info = state_machine.GetType().GetField("CurrentStateId",
					BindingFlags.GetField | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				result_current_state_id = (int)field_info.GetValue(state_machine);

				// Validate
				Assert.Equal(initial_current_state_id, result_current_state_id);
				Assert.Equal(states, result_states);
				Assert.Equal(transition_matrix, result_transition_matrix);
            }
		}
	}
}

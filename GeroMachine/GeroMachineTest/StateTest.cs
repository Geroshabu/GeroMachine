using GeroMachine;

namespace GeroMachineTest
{
	public class StateTest
	{
		public class CreationTest
		{
			private class DerivedState : State
			{
				public DerivedState(StateType stateType) : base(stateType) { }
			}
		}
	}
}

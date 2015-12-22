using Xunit;
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

			[Fact(DisplayName = "State:Creation:コンストラクタの単純な値初期化テスト", Skip = "Not Implemented")]
			public void TestConstructor()
			{
			}

			[Fact(DisplayName = "State:Creation:コンストラクタの引数に不正な値が渡されるテスト", Skip = "Not Implemented")]
			public void TestOutOfRangeArgumentConstructor()
			{
			}
		}
	}
}

using System;
using System.Reflection;
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

			[Fact(DisplayName = "State:Creation:コンストラクタの単純な値初期化テスト")]
			public void TestConstructor()
			{
				// Execute
				DerivedState instance = new DerivedState(StateType.NormalState);

				// Get Result
				FieldInfo field_info = instance.GetType().BaseType.GetField("<StateType>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				StateType actual_StateType = (StateType)field_info.GetValue(instance);

				// Validate
				Assert.Equal(StateType.NormalState, actual_StateType);
			}

			[Fact(DisplayName = "State:Creation:コンストラクタの引数に不正な値が渡されるテスト")]
			public void TestOutOfRangeArgumentConstructor()
			{
				// Execute & Validate
				DerivedState instance;
				Assert.Throws<ArgumentOutOfRangeException>("stateType",
					() => instance = new DerivedState((StateType)2));
			}
		}
	}
}

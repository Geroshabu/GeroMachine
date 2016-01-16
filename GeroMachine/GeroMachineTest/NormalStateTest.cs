using Xunit;
using GeroMachine;
using System.Reflection;

namespace GeroMachineTest
{
	public class NormalStateTest
	{
		/// <summary>
		/// インスタンス作作成前, および作成時のテスト
		/// </summary>
		public class CreationTest
		{
			/// <summary>
			/// コンストラクタのテスト
			/// </summary>
			[Fact(DisplayName = "NormalState:Creation:コンストラクタの単純な値初期化テスト")]
			public void TestConstructor()
			{
				// Execute
				NormalState normal_state = new NormalState();

				// Get results
				FieldInfo field_info = normal_state.GetType().BaseType.GetField("<StateType>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				StateType actual_StateType = (StateType)field_info.GetValue(normal_state);

				// Validata
				Assert.Equal(StateType.NormalState, actual_StateType);
            }
		}

		/// <summary>
		/// あるインスタンスに対してのテスト
		/// </summary>
		public class SingleInstanceTest
		{
			private NormalState normalState;

			/// <summary>
			/// <see cref="NormalState"/>インスタンスを作成する.
			/// </summary>
			public SingleInstanceTest()
			{
				normalState = new NormalState();
			}
		}
	}
}

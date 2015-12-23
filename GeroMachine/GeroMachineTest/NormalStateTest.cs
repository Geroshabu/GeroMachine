using Xunit;
using GeroMachine;
using System.Reflection;

namespace GeroMachineTest
{
	public class NormalStateTest
	{
		/// <summary>
		/// �C���X�^���X��쐬�O, ����э쐬���̃e�X�g
		/// </summary>
		public class CreationTest
		{
			/// <summary>
			/// �R���X�g���N�^�̃e�X�g
			/// </summary>
			[Fact(DisplayName = "NormalState:Creation:�R���X�g���N�^�̒P���Ȓl�������e�X�g")]
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
		/// ����C���X�^���X�ɑ΂��Ẵe�X�g
		/// </summary>
		public class SingleInstanceTest
		{
			private NormalState normalState;

			/// <summary>
			/// <see cref="NormalState"/>�C���X�^���X���쐬����.
			/// </summary>
			public SingleInstanceTest()
			{
				normalState = new NormalState();
			}
		}
	}
}

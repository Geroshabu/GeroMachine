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
			[Fact]
			public void TestConstructor()
			{
				// Prepare datas
				Trigger[] setting_MonitoredTriggers = new Trigger[3]
				{
					new Trigger(),
					new Trigger(),
					new Trigger()
				};
				Trigger[] expected_MonitoredTriggers = setting_MonitoredTriggers;
                Trigger[] expected_elements_MonitoredTriggers = (Trigger[])setting_MonitoredTriggers.Clone();

				// Execute
				NormalState normal_state = new NormalState(setting_MonitoredTriggers);

				// Get results
				FieldInfo field_info = normal_state.GetType().GetField("MonitoredTriggers",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				Trigger[] actual_MonitoredTriggers = (Trigger[])field_info.GetValue(normal_state);

				// Validata
				Assert.Equal(expected_MonitoredTriggers, actual_MonitoredTriggers);
				Assert.Equal(expected_elements_MonitoredTriggers.Length, actual_MonitoredTriggers.Length);
				for (int i = 0; i < expected_elements_MonitoredTriggers.Length; i++)
				{
					Assert.Equal(expected_elements_MonitoredTriggers[i], actual_MonitoredTriggers[i]);
				}
            }
		}

		/// <summary>
		/// ����C���X�^���X�ɑ΂��Ẵe�X�g
		/// </summary>
		public class SingleInstanceTest
		{
			private NormalState normalState;
			public SingleInstanceTest()
			{
				normalState = new NormalState(new Trigger[1] { new Trigger() });
			}

			/// <summary>
			/// <see cref="NormalState.CheckTrigger"/>���\�b�h�̃e�X�g
			/// </summary>
			[Fact]
			public void TestCheckTrigger()
			{
				// Prepare datas
				FieldInfo field_info = normalState.GetType().GetField("MonitoredTriggers",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				Trigger[] triggers = (Trigger[])field_info.GetValue(normalState);
				uint expected_Id = triggers[0].Id;

				// Execute
				uint actual_Id = normalState.CheckTrigger();

				// Validate
				Assert.Equal(expected_Id, actual_Id);
			}
		}
	}
}

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
			[Fact(Skip = "Under Construction")]
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
		/// あるインスタンスに対してのテスト
		/// </summary>
		public class SingleInstanceTest
		{
			private NormalState normalState;
			private Trigger[] monitoredTriggers;
			private uint[] monitoredTriggerIds;

			/// <summary>
			/// <see cref="NormalState"/>インスタンスを作成する.
			/// </summary>
			public SingleInstanceTest()
			{
				monitoredTriggers = new Trigger[10]
				{
					new Trigger(), new Trigger(), new Trigger(),
					new Trigger(), new Trigger(), new Trigger(),
					new Trigger(), new Trigger(), new Trigger(), new Trigger()
				};
				monitoredTriggerIds = new uint[10];
				for (int i = 0; i < monitoredTriggers.Length; i++)
				{
					monitoredTriggerIds[i] = monitoredTriggers[i].Id;
				}
				normalState = new NormalState(monitoredTriggers);
			}
		}
	}
}

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

			/// <summary>
			/// <see cref="NormalState.CheckTrigger"/>メソッドのテスト
			/// </summary>
			[Theory(Skip = "Not Implemented")]
			[InlineData(new uint[1] { 0 }, 0u)]
			[InlineData(new uint[1] { 4 }, 4u)]
			[InlineData(new uint[1] { 9 }, 9u)]
			[InlineData(new uint[0] { }, null)]
			[InlineData(new uint[3] { 3, 6, 8 }, 3u)]
			[InlineData(new uint[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0u)]
			public void TestCheckTrigger(uint[] setting_HasOccuredFlags, uint? detectedTriggerIndex)
			{
				// Prepare datas
				uint expected_result = 0;
				if (detectedTriggerIndex.HasValue)
				{
					expected_result = monitoredTriggerIds[detectedTriggerIndex.Value];
				}

				// Set data
				FieldInfo field_info = typeof(Trigger).GetField("_HasOccured",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				foreach (Trigger trigger in monitoredTriggers)
				{
					field_info.SetValue(trigger, false);
				}
				for (int i = 0; i < setting_HasOccuredFlags.Length; i++)
				{
					uint trigger_index = setting_HasOccuredFlags[i];
					Trigger trigger = monitoredTriggers[trigger_index];
					field_info.SetValue(trigger, true);
				}

				// Execute
				uint actual_result = normalState.CheckTrigger();

				// Validate
				Assert.Equal(expected_result, actual_result);
			}
		}
	}
}

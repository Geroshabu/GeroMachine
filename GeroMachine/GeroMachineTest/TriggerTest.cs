using System;
using Xunit;
using GeroMachine;
using System.Reflection;

namespace GeroMachineTest
{
	public class TriggerTest
	{
		/// <summary>
		/// インスタンス作作成前, および作成時のテスト
		/// </summary>
		public class CreationTest
		{
			/// <summary>
			/// <see cref="Trigger.CountOfTrigger"/>静的フィールドの初期値のテスト
			/// </summary>
			[Fact]
			public void TestCountOfTriggerFieldInitialization()
			{
				// Prepare datas
				uint expected_CountOfTrigger = 0;

				// Execute
				// Nothing to do

				// Get result
				FieldInfo field_info = typeof(Trigger).GetField("CountOfTrigger",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Static);
				uint actual_CountOfTrigger = (uint)field_info.GetValue(null);

				// Validate
				Assert.Equal(expected_CountOfTrigger, actual_CountOfTrigger);
			}

			/// <summary>
			/// コンストラクタのテスト
			/// </summary>
			[Theory(Skip = "Not Implemented")]
			[InlineData(1, 0, 1)]
			[InlineData(2, 1, 2)]
			public void TestConstructor(uint creationCount, uint expected_Id, uint expected_CountOfTrigger)
			{
				// Prepare datas
				const bool expected_HasOccured = false;

				// Execute
				Array triggers = Array.CreateInstance(typeof(Trigger), creationCount);
				for(int i = 0; i < triggers.Length; i++)
				{
					triggers.SetValue(new Trigger(), i);
				}

				// Get result
				Trigger last_element = (Trigger)triggers.GetValue(triggers.Length-1);
				FieldInfo field_info = last_element.GetType().GetField("<HasOccured>k__BackingField");
				bool actual_HasOccured = (bool)field_info.GetValue(last_element);

				field_info = last_element.GetType().GetField("<Id>k__BackingField");
				uint actual_Id = (uint)field_info.GetValue(last_element);

				field_info = typeof(Trigger).GetField("CountOfTrigger");
				uint actual_CountOfTrigger = (uint)field_info.GetValue(null);

				// Validate
				Assert.Equal(expected_HasOccured, actual_HasOccured);
				Assert.Equal(expected_Id, actual_Id);
				Assert.Equal(expected_CountOfTrigger, actual_CountOfTrigger);
			}
		}

		/// <summary>
		/// あるインスタンスに対してのテスト
		/// </summary>
		public class SingleInstanceTest
		{
			private Trigger trigger;
			public SingleInstanceTest()
			{
				trigger = new Trigger();
			}

			/// <summary>
			/// <see cref="Trigger.HasOccured"/>プロパティのGetterのテスト
			/// </summary>
			[Theory(Skip = "Not Implemented")]
			[InlineData(false, false, false)]
			[InlineData(true, true, false)]
			public void TestHasOccuredGetter(bool setting_HasOccured, bool expected_HasOccured, bool expected_after_execution)
			{
				// Setup
				Type type = trigger.GetType();
				FieldInfo field_info = type.GetField("<HasOccured>k__BackingField",
					BindingFlags.SetField | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				field_info.SetValue(trigger, setting_HasOccured);

				// Execute
				bool actual_HasOccured = trigger.HasOccured;

				// Get result
				bool actual_after_execution = (bool)field_info.GetValue(trigger);

				// Validate
				Assert.Equal(expected_HasOccured, actual_HasOccured);
				Assert.Equal(expected_after_execution, actual_after_execution);
			}

			/// <summary>
			/// <see cref="Trigger.HasOccured"/>プロパティのSetterのテスト
			/// </summary>
			[Theory]
			[InlineData(true, true)]
			public void TestHasOccuredSetter(bool input_HasOccured, bool expected_HasOccured)
			{
				// Execute
				Type type = trigger.GetType();
				MethodInfo method_info = type.GetMethod("set_HasOccured",
					BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
				method_info.Invoke(trigger, new object[] { input_HasOccured });
				
				// Get result
				FieldInfo field_info = type.GetField("<HasOccured>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				bool actual_HasOccured = (bool)field_info.GetValue(trigger);

				// Validate
				Assert.Equal(expected_HasOccured, actual_HasOccured);
			}

			/// <summary>
			/// <see cref="Trigger.Id"/>プロパティのGetterのテスト
			/// </summary>
			[Theory]
			[InlineData(42u, 42u)]
			public void TestIdGetter(uint setting_Id, uint expected_Id)
			{
				// Setup
				Type type = trigger.GetType();
				FieldInfo field_info = type.GetField("<Id>k__BackingField",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				field_info.SetValue(trigger, setting_Id);

				// Execute
				uint actual_Id = trigger.Id;

				// Validate
				Assert.Equal(expected_Id, actual_Id);
			}

			/// <summary>
			/// <see cref="Trigger.Id"/>プロパティのSetterのテスト
			/// </summary>
			[Theory]
			[InlineData(42u, 42u)]
			public void TestIdSetter(uint input_Id, uint expected_Id)
			{
				// Execute
				Type type = trigger.GetType();
				MethodInfo method_info = type.GetMethod("set_Id",
					BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
				method_info.Invoke(trigger, new object[] { input_Id });

				// Get result
				FieldInfo field_info = type.GetField("<Id>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				uint actual_Id = (uint)field_info.GetValue(trigger);

				// Validate
				Assert.Equal(expected_Id, actual_Id);
			}
		}
	}
}

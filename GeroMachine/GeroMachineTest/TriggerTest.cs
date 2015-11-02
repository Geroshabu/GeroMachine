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
			public CreationTest()
			{
				Type type = typeof(Trigger);
				FieldInfo field_info = type.GetField("CountOfTrigger",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static);
				field_info.SetValue(null, 0u);
			}

			/// <summary>
			/// コンストラクタのテスト
			/// </summary>
			[Fact]
			public void TestConstructor()
			{
				// Prepare datas
				Type type = typeof(Trigger);
				const bool expected_HasOccured = false;
				FieldInfo field_info = type.GetField("CountOfTrigger",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Static);
				uint expected_CountOfTrigger = (uint)field_info.GetValue(null) + 1;
				uint expected_Id = (uint)field_info.GetValue(null);

				// Execute
				Trigger trigger = new Trigger();

				// Get result
				field_info = type.GetField("<HasOccured>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				bool actual_HasOccured = (bool)field_info.GetValue(trigger);

				field_info = type.GetField("<Id>k__BackingField",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				uint actual_Id = (uint)field_info.GetValue(trigger);

				field_info = type.GetField("CountOfTrigger",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Static);
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

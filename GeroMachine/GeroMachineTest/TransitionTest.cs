using Xunit;
using System;
using System.Collections.Generic;
using System.Reflection;
using GeroMachine;

namespace GeroMachineTest
{
	public class TransitionTest
	{
		public class CreationTest
		{
			private static void DummyMethod() { return; }
			private static State setting_NextState = new NormalState(new Trigger[1] { new Trigger() });
			private static Transition.TransitionMethodDelegate setting_TransitionMethod = DummyMethod;

			public static IEnumerable<object> ConstructorTestData
			{
				get
				{
					return new[] {
						new object[] { setting_NextState, setting_NextState, setting_TransitionMethod, setting_TransitionMethod },
						new object[] { setting_NextState, setting_NextState, null, null }
					};
				}
			}

			[Theory(DisplayName = "コンストラクタの単純な値初期化テスト")]
			[MemberData("ConstructorTestData")]
			public void TestConstructor(State setting_NextState, State expected_NextState,
				Transition.TransitionMethodDelegate setting_TransitionMethod,
				Transition.TransitionMethodDelegate expected_TransitionMethod)
			{
				// Execute
				Transition transition = new Transition(setting_NextState, setting_TransitionMethod);

				// Get result
				Type type = typeof(Transition);
				FieldInfo field_info = type.GetField("NextState",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				State actual_NextState = (State)field_info.GetValue(transition);
				field_info = type.GetField("TransitionMethod",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				var actual_TransitionMethod = (Transition.TransitionMethodDelegate)field_info.GetValue(transition);

				// Validate
				Assert.Equal(expected_NextState, actual_NextState);
				Assert.Equal(expected_TransitionMethod, actual_TransitionMethod);
			}

			public static IEnumerable<object> NullParameterTestData
			{
				get
				{
					return new[] {
						new object[] { null, setting_TransitionMethod },
						new object[] { null, null }
					};
				}
			}

			[Theory(DisplayName = "内部遷移のインスタンス生成テスト")]
			[MemberData("NullParameterTestData")]
			public void TestNullParameter(State setting_NextState, Transition.TransitionMethodDelegate setting_TransitionMethod)
			{
				// Execute, Validate
				Assert.Throws<NotImplementedException>(() => new Transition(setting_NextState, setting_TransitionMethod));
			}
		}

		public class RegularInstanceTest
		{
			private State setting_NextState;
			private Transition.TransitionMethodDelegate setting_TransitionMethod;
			private Transition transition;
			private bool calledFlag;

			public RegularInstanceTest()
			{
				calledFlag = false;

				setting_NextState = new NormalState(new Trigger[1] { new Trigger() });
				setting_TransitionMethod = () => {
					calledFlag = true;
					return;
				};

				transition = new Transition(setting_NextState, setting_TransitionMethod);
			}

			[Fact(DisplayName = "Executeメソッドのテスト")]
			public void TestExecuteMethod()
			{
				// Prepare environment
				calledFlag = false;

				// Prepare datas
				State expected_result = setting_NextState;

				// Execute
				State actual_result = transition.Execute();

				// Validate
				Assert.Same(expected_result, actual_result);
				Assert.True(calledFlag);
			}
		}

		public class NoTransitionMethodInstanceTest
		{
			private State setting_NextState;
			private Transition transition;

			public NoTransitionMethodInstanceTest()
			{
				setting_NextState = new NormalState(new Trigger[1] { new Trigger() });
				transition = new Transition(setting_NextState, null);
			}

			[Fact(DisplayName = "Executeメソッドのテスト")]
			public void TestExecuteMethod()
			{
				// Prepare datas
				State expected_result = setting_NextState;

				// Execute
				State actual_result = transition.Execute();

				// Validate
				Assert.Same(expected_result, actual_result);
			}
		}
	}
}

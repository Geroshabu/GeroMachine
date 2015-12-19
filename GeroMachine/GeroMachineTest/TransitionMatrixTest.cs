using Xunit;
using GeroMachine;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace GeroMachineTest
{
	public class TransitionMatrixTest
	{
		/// <summary>
		/// インスタンス作成前, および作成時のテスト
		/// </summary>
		public class CreationTest
		{
			private Trigger[] TriggerSet1;
			private Trigger[] TriggerSet2;
			private Trigger[] TriggerSet3;

			[Fact(DisplayName = "TransitionMatrix:Creation:コンストラクタの単純な値初期化テスト")]
			public void TestConstructor()
			{
				// Prepare datas
				Trigger[] all_triggers = new Trigger[5]
				{
					new Trigger(),
					new Trigger(),
					new Trigger(),
					new Trigger(),
					new Trigger()
				};
				TriggerSet1 = new Trigger[3]
				{
					all_triggers[0],
					all_triggers[1],
					all_triggers[2]
				};
				TriggerSet2 = new Trigger[3]
				{
					all_triggers[0],
					all_triggers[2],
					all_triggers[4]
				};
				TriggerSet3 = new Trigger[3]
				{
					all_triggers[2],
					all_triggers[3],
					all_triggers[4]
				};
				State[] states = new State[3]
				{
					new NormalState(),
					new NormalState(),
					new NormalState()
				};
				var input_transitionMatrix = new Dictionary<State, Dictionary<Trigger, ITransition>>()
				{
					{
						states[0],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet1[0], new Transition(states[2], null) },
							{ TriggerSet1[1], new Transition(states[2], null) },
							{ TriggerSet1[2], new Transition(states[1], null) }
						}
					},
					{
						states[1],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet2[0], new Transition(states[0], null) },
							{ TriggerSet2[1], new Transition(states[1], null) },
							{ TriggerSet2[2], new Transition(states[2], null) }
						}
					},
					{
						states[2],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet3[0], new Transition(states[2], null) },
							{ TriggerSet3[1], new Transition(states[2], null) },
							{ TriggerSet3[2], new Transition(states[0], null) }
						}
					}
				};
				var expected_MatrixData = new Dictionary<State, Dictionary<Trigger, ITransition>>(input_transitionMatrix);

				// Execute
				TransitionMatrix transition_matrix = new TransitionMatrix(input_transitionMatrix);

				// Get result
				FieldInfo field_info = transition_matrix.GetType().GetField("MatrixData",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				var actual_MatrixData = (Dictionary<State, Dictionary<Trigger, ITransition>>)field_info.GetValue(transition_matrix);

				// Validate
				Assert.Same(input_transitionMatrix, actual_MatrixData);
				Assert.Equal(expected_MatrixData, actual_MatrixData);
			}

			[Fact(DisplayName ="TransitionMatrix:Creation:null引数のテスト")]
			public void TestNullArgumentConstructor()
			{
				// Execute
				TransitionMatrix transition_matrix;
				Assert.Throws<ArgumentNullException>(
					"transitionMatrix",
					() => transition_matrix = new TransitionMatrix(null)
				);
			}
		}

		/// <summary>
		/// あるインスタンスに対してのテスト
		/// </summary>
		public class RegularInstanceTest
		{
			private Trigger[] All_Triggers;
			private State[] All_States;
			private Dictionary<State, Dictionary<Trigger, ITransition>> setting_MatrixData;
			private TransitionMatrix TransitionMatrixInstance;

			public RegularInstanceTest()
			{
				All_Triggers = new Trigger[5]
				{
					new Trigger(),
					new Trigger(),
					new Trigger(),
					new Trigger(),
					new Trigger()
				};
				Trigger[] TriggerSet1 = new Trigger[3]
				{
					All_Triggers[0],
					All_Triggers[1],
					All_Triggers[2]
				};
				Trigger[] TriggerSet2 = new Trigger[3]
				{
					All_Triggers[0],
					All_Triggers[2],
					All_Triggers[4]
				};
				Trigger[] TriggerSet3 = new Trigger[3]
				{
					All_Triggers[2],
					All_Triggers[3],
					All_Triggers[4]
				};
				All_States = new State[3]
				{
					new NormalState(),
					new NormalState(),
					new NormalState()
				};
				setting_MatrixData = new Dictionary<State, Dictionary<Trigger, ITransition>>()
				{
					{
						All_States[0],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet1[0], new Transition(All_States[2], null) },
							{ TriggerSet1[1], new Transition(All_States[2], null) },
							{ TriggerSet1[2], new Transition(All_States[1], null) }
						}
					},
					{
						All_States[1],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet2[0], new Transition(All_States[0], null) },
							{ TriggerSet2[1], new Transition(All_States[1], null) },
							{ TriggerSet2[2], new Transition(All_States[2], null) }
						}
					},
					{
						All_States[2],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet3[0], new Transition(All_States[2], null) },
							{ TriggerSet3[1], new Transition(All_States[2], null) },
							{ TriggerSet3[2], new Transition(All_States[0], null) }
						}
					}
				};
				TransitionMatrixInstance = new TransitionMatrix(setting_MatrixData);
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:正常ケース")]
			public void TestSearchTransition()
			{
				// Prepare datas
				int index_CurrentState = 0;
				int index_Trigger = 1;
				State input_CurrentState = All_States[index_CurrentState];
				Trigger input_Trigger = All_Triggers[index_Trigger];
				ITransition expected_Result = setting_MatrixData[input_CurrentState][input_Trigger];

				// Execute
				ITransition actual_Result = TransitionMatrixInstance.SearchTransition(input_CurrentState, input_Trigger);

				// Validate
				Assert.Same(expected_Result, actual_Result);
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:正常ケース(該当する遷移がない場合)")]
			public void TestSearchTransitionNoTransition()
			{
				// Prepare datas
				int index_CurrentState = 1;
				int index_Trigger = 3;
				State input_CurrentState = All_States[index_CurrentState];
				Trigger input_Trigger = All_Triggers[index_Trigger];

				// Execute
				ITransition actual_Result = TransitionMatrixInstance.SearchTransition(input_CurrentState, input_Trigger);

				// Validate
				Assert.Null(actual_Result);
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:第一引数がnullエラー")]
			public void TestSearchTransitionNullArgument1()
			{
				// Prepare datas
				State input_State = null;
				Trigger input_Trigger = All_Triggers[0];

				// Execute & Validate
				Assert.Throws<ArgumentNullException>(
					"currentState",
					() => TransitionMatrixInstance.SearchTransition(input_State, input_Trigger));
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:第二引数がnullエラー")]
			public void TestSearchTransitionNullArgument2()
			{
				// Prepare datas
				State input_State = All_States[0];
				Trigger input_Trigger = null;

				// Execute & Validate
				Assert.Throws<ArgumentNullException>(
					"trigger",
					() => TransitionMatrixInstance.SearchTransition(input_State, input_Trigger));
			}

			[Fact(DisplayName ="TransitionMatrix:RegularInstance:SearchTransition:状態遷移表に存在しない状態が指定されたエラー")]
			public void TestSearchTransitionUnregisteredState()
			{
				// Prepare datas
				Trigger[] TestTriggerSet = new Trigger[2]
				{
					All_Triggers[0],
					All_Triggers[3]
				};
				State input_State = new NormalState();
				Trigger input_Trigger = All_Triggers[0];

				// Execute & Validate
				Assert.Throws<ArgumentOutOfRangeException>(
					"currentState",
					() => TransitionMatrixInstance.SearchTransition(input_State, input_Trigger));
            }
		}
	}
}

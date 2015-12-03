using Xunit;
using System;
using System.Reflection;
using System.Collections.Generic;
using GeroMachine;

namespace GeroMachineTest
{
	public class GeroMachineTest
	{
		/// <summary>
		/// StateMachineを作成する前のテスト
		/// </summary>
		public class CreationTest
		{
			private TransitionMatrix setting_TransitionMatrixData;
			private State setting_InitialState;

			public CreationTest()
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
				Trigger[] TriggerSet1 = new Trigger[3]
				{
					all_triggers[0],
					all_triggers[1],
					all_triggers[2]
				};
				Trigger[] TriggerSet2 = new Trigger[3]
				{
					all_triggers[0],
					all_triggers[2],
					all_triggers[4]
				};
				Trigger[] TriggerSet3 = new Trigger[3]
				{
					all_triggers[2],
					all_triggers[3],
					all_triggers[4]
				};
				State[] all_states = new State[3]
				 {
					new NormalState(TriggerSet1),
					new NormalState(TriggerSet2),
					new NormalState(TriggerSet3)
				 };
				var MatrixData = new Dictionary<State, Dictionary<Trigger, ITransition>>()
				{
					{
						all_states[0],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet1[0], new Transition(all_states[2], null) },
							{ TriggerSet1[1], new Transition(all_states[2], null) },
							{ TriggerSet1[2], new Transition(all_states[1], null) }
						}
					},
					{
						all_states[1],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet2[0], new Transition(all_states[0], null) },
							{ TriggerSet2[1], new Transition(all_states[1], null) },
							{ TriggerSet2[2], new Transition(all_states[2], null) }
						}
					},
					{
						all_states[2],
						new Dictionary<Trigger, ITransition>()
						{
							{ TriggerSet3[0], new Transition(all_states[2], null) },
							{ TriggerSet3[1], new Transition(all_states[2], null) },
							{ TriggerSet3[2], new Transition(all_states[0], null) }
						}
					}
				};
				setting_TransitionMatrixData = new TransitionMatrix(MatrixData);
				setting_InitialState = all_states[0];
			}

			[Fact(DisplayName = "StateMachine:Creation:Constructor:コンストラクタの単純な値初期化テスト")]
			public void TestConstructor()
			{
				// Prepare datas
				TransitionMatrix expected_TransitionMatrixData = setting_TransitionMatrixData;
				State expected_InitialState = setting_InitialState;

				// Execute
				StateMachine state_machine = new StateMachine(setting_InitialState, setting_TransitionMatrixData);

				// Get results
				FieldInfo field_info = state_machine.GetType().GetField("CurrentState",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				State actual_CurrentState = (State)field_info.GetValue(state_machine);
				field_info = state_machine.GetType().GetField("TransitionMatrixData",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				TransitionMatrix actual_TransitionMatrixData = (TransitionMatrix)field_info.GetValue(state_machine);

				// Validate
				Assert.Same(expected_InitialState, actual_CurrentState);
				Assert.Same(expected_TransitionMatrixData, actual_TransitionMatrixData);
			}

			[Fact(DisplayName = "StateMachine:Creation:Constructor:第一引数がnullエラー")]
			public void TestConstructorNullArgument1()
			{
				// Prepare datas
				setting_InitialState = null;

				// Execute & Validate
				StateMachine state_machine;
				Assert.Throws<ArgumentNullException>(
					"initialState",
					() => state_machine = new StateMachine(setting_InitialState, setting_TransitionMatrixData));
			}

			[Fact(DisplayName = "StateMachine:Creation:Constructor:第二引数がnullエラー")]
			public void TestConstructorNullArgument2()
			{
				// Prepare datas
				setting_TransitionMatrixData = null;

				// Execute & Validate
				StateMachine state_machine;
				Assert.Throws<ArgumentNullException>(
					"matrixData",
					() => state_machine = new StateMachine(setting_InitialState, setting_TransitionMatrixData));
			}
		}

		public class RegularInstanceTest
		{
			private StateMachine StateMachineInstance;

			#region TransitionMatrix Mocks
			private class TransitionMatrixStub : ITransitionMatrix
			{
				public ITransition SearchTransition(State currentState, Trigger trigger)
				{
					throw new NotImplementedException();
				}
			}

			private class TransitionMatrixSearchTransitionThrowArgumentNullExceptionMock : ITransitionMatrix
			{
				public bool HasCalledSearchTransition { get; set; }
				public ITransition SearchTransition(State currentState, Trigger trigger)
				{
					HasCalledSearchTransition = true;
					throw new ArgumentNullException("exception mock");
				}
			}

			private class TransitionMatrixSearchTransitionThrowArgumentOutOfRangeExceptionMock : ITransitionMatrix
			{
				public bool HasCalledSearchTransition { get; set; }
				public ITransition SearchTransition(State currentState, Trigger trigger)
				{
					HasCalledSearchTransition = true;
					throw new ArgumentOutOfRangeException("exception mock");
				}
			}

			private class TransitionMatrixSearchTransitionReturnNullMock : ITransitionMatrix
			{
				public bool HasCalledSearchTransition { get; set; }
				public ITransition SearchTransition(State currentState, Trigger trigger)
				{
					HasCalledSearchTransition = true;
					return null;
				}
			}

			private class TransitionMatrixSearchTransitionReturnParticularTransitionMock : ITransitionMatrix
			{
				public ITransition ReturnedTransition { get; set; }
				public bool HasCalledSearchTransition { get; set; }
				public TransitionMatrixSearchTransitionReturnParticularTransitionMock(ITransition returnedTransition)
				{
					ReturnedTransition = returnedTransition;
				}
				public ITransition SearchTransition(State currentState, Trigger trigger)
				{
					HasCalledSearchTransition = true;
					return ReturnedTransition;
				}
			}

			private class TransitionExecuteReturnParticularStateMock : ITransition
			{
				public State ReturnedState { get; set; }
				public bool HasCalledExecute { get; set; }
				public TransitionExecuteReturnParticularStateMock(State returnedState)
				{
					ReturnedState = returnedState;
				}
				public State Execute()
				{
					HasCalledExecute = true;
					return ReturnedState;
				}
			}

			private class StateStub : State
			{
				public StateStub() : base(null) { }
				public override uint CheckTrigger()
				{
					throw new NotImplementedException();
				}
			}

			private class TriggerStub : Trigger { }
			#endregion

			public RegularInstanceTest()
			{
				State setting_InitialState = new StateStub();
				TransitionMatrixStub setting_TransitionMatrix = new TransitionMatrixStub();
				StateMachineInstance = new StateMachine(setting_InitialState, setting_TransitionMatrix);
			}

			[Fact(DisplayName = "StateMachine:RegularInstance:InputTrigger:通常の使用")]
			public void TestInputTrigger()
			{
				// Prepare datas
				Trigger input_Trigger = new TriggerStub();
				State state_stub = new StateStub();
				State expected_CurrentState = state_stub;
				FieldInfo current_state_field_info = StateMachineInstance.GetType().GetField("CurrentState",
					BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
				State before_CurrentState = (State)current_state_field_info.GetValue(StateMachineInstance);

				// Prepare mocks
				var transition_mock = new TransitionExecuteReturnParticularStateMock(state_stub);
				transition_mock.HasCalledExecute = false;
				var transition_matrix_mock = new TransitionMatrixSearchTransitionReturnParticularTransitionMock(transition_mock);
				transition_matrix_mock.HasCalledSearchTransition = false;
				FieldInfo transition_matrix_data_field_info = StateMachineInstance.GetType().GetField("TransitionMatrixData",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				transition_matrix_data_field_info.SetValue(StateMachineInstance, transition_matrix_mock);

				// Execute
				StateMachineInstance.InputTrigger(input_Trigger);

				// Get results
				State actual_CurrentState = (State)current_state_field_info.GetValue(StateMachineInstance);

				// Validate
				Assert.True(transition_matrix_mock.HasCalledSearchTransition);
				Assert.True(transition_mock.HasCalledExecute);
				Assert.NotSame(before_CurrentState, actual_CurrentState);
				Assert.Same(expected_CurrentState, actual_CurrentState);
			}

			[Fact(DisplayName = "StateMachine:RegularInstance:InputTrigger:第一引数がnullエラー")]
			public void TestInputTriggerNullArgument()
			{
				// Prepare datas
				Trigger setting_Trigger = null;

				// Execute & Validate
				Assert.Throws<ArgumentNullException>(
					"trigger",
					() => StateMachineInstance.InputTrigger(setting_Trigger));
			}

			[Fact(DisplayName = "StateMachine:RegularInstance:InputTrigger:SearchTransitionにnullが渡される内部エラー")]
			public void TestSearchTransitionFailedSearchTransitionArgumentNull()
			{
				// Prepare datas
				var transition_matrix_mock = new TransitionMatrixSearchTransitionThrowArgumentNullExceptionMock();
				transition_matrix_mock.HasCalledSearchTransition = false;
				State setting_InitialState = new StateStub();
				Trigger input_Trigger = new TriggerStub();

				// Prepare mocks
				FieldInfo field_info = StateMachineInstance.GetType().GetField("TransitionMatrixData",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				field_info.SetValue(StateMachineInstance, transition_matrix_mock);

				// Execute & Validate
				Assert.Throws<ArgumentNullException>(
					"exception mock",
					() => StateMachineInstance.InputTrigger(input_Trigger));
			}

			[Fact(DisplayName = "StateMachine:RegularInstance:InputTrigger:状態遷移図に現在の状態が無い内部エラー")]
			public void TestSearchTransitionFailedSearchTransitionArgumentOutOfRange()
			{
				// Prepare datas
				var transition_matrix_mock = new TransitionMatrixSearchTransitionThrowArgumentOutOfRangeExceptionMock();
				transition_matrix_mock.HasCalledSearchTransition = false;
				State setting_InitialState = new StateStub();
				Trigger input_Trigger = new TriggerStub();

				// Prepare mocks
				FieldInfo field_info = StateMachineInstance.GetType().GetField("TransitionMatrixData",
					BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
				field_info.SetValue(StateMachineInstance, transition_matrix_mock);

				// Execute & Validate
				Assert.Throws<InvalidOperationException>(() => StateMachineInstance.InputTrigger(input_Trigger));
			}
		}
	}
}

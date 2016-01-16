using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GeroMachine;

namespace GeroMachineSample
{
	public partial class GeroMachineSampleForm : Form
	{
		Trigger[] AllTriggers;
		StateMachine MainStateMachine;

		public GeroMachineSampleForm()
		{
			InitializeComponent();
		}

		private void GeroMachineSampleForm_Load(object sender, EventArgs e)
		{
			AllTriggers = new Trigger[3]
			{
				new Trigger(),
				new Trigger(),
				new Trigger()
			};
			State[] all_states = new State[3]
			{
				new NormalState(),
				new NormalState(),
				new NormalState()
			};
			all_states[0].StateName = "State 1";
			all_states[1].StateName = "State 2";
			all_states[2].StateName = "State 3";
			var matrixData = new Dictionary<State, Dictionary<Trigger, ITransition>>
			{
				{
					all_states[0],
					new Dictionary<Trigger, ITransition>
					{
						{ AllTriggers[0], new Transition(all_states[1], null) },
						{ AllTriggers[1], new Transition(all_states[2], null) },
					}
				},
				{
					all_states[1],
					new Dictionary<Trigger, ITransition>
					{
						{ AllTriggers[0], new Transition(all_states[2], null) },
						{ AllTriggers[1], new Transition(all_states[2], null) },
						{ AllTriggers[2], new Transition(all_states[0], null) }
					}
				},
				{
					all_states[2],
					new Dictionary<Trigger, ITransition>
					{
						{ AllTriggers[0], new Transition(all_states[2], null) },
						{ AllTriggers[2], new Transition(all_states[0], null) }
					}
				}
			};

			TransitionMatrix transitino_matrix = new TransitionMatrix(matrixData);

			MainStateMachine = new StateMachine(all_states[0], transitino_matrix);
			ShowStateInformation();
		}

		private void Trigger1Button_Click(object sender, EventArgs e)
		{
			MainStateMachine.InputTrigger(AllTriggers[0]);
			ShowStateInformation();
		}

		private void Trigger2Button_Click(object sender, EventArgs e)
		{
			MainStateMachine.InputTrigger(AllTriggers[1]);
			ShowStateInformation();
		}

		private void Trigger3Button_Click(object sender, EventArgs e)
		{
			MainStateMachine.InputTrigger(AllTriggers[2]);
			ShowStateInformation();
		}

		private void ShowStateInformation()
		{
			CurrentStateNameLabel.Text = MainStateMachine.CurrentStateName;
		}
	}
}

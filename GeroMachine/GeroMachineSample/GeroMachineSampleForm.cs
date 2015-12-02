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

		private void RunButton_Click(object sender, EventArgs e)
		{
			GeroMachine.Trigger[] triggers = new GeroMachine.Trigger[1]
			{
				new GeroMachine.Trigger()
			};

			GeroMachine.State[] states = new GeroMachine.State[3]
			{
				new GeroMachine.NormalState(triggers),
				new GeroMachine.NormalState(triggers),
				new GeroMachine.NormalState(triggers)
			};
			int[,] transMatrix = new int[3, 1]
			{
				{ 1 },
				{ 2 },
				{ 0 }
			};

			RunButton.Enabled = false;
			GeroMachine.StateMachine state_machine = new GeroMachine.StateMachine(states, transMatrix);
			state_machine.CurrentStateShowMethod = ShowCurrentState;

			System.Reflection.PropertyInfo[] infos = typeof(GeroMachine.Trigger).GetProperties(System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			foreach (System.Reflection.PropertyInfo info in infos)
			{
				Console.WriteLine(info.Name);
			}

			state_machine.RunAsync();
		}

		/// <summary>
		/// デバッグ用
		/// </summary>
		private void ShowCurrentState(int currentStateId)
		{
			CurrentStateIdLabel.Text = currentStateId.ToString();
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
				new NormalState(AllTriggers),
				new NormalState(AllTriggers),
				new NormalState(AllTriggers)
			};
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
		}
	}
}

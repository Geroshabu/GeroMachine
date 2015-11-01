using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeroMachineSample
{
	public partial class GeroMachineSampleForm : Form
	{
		public GeroMachineSampleForm()
		{
			InitializeComponent();
		}

		private void RunButton_Click(object sender, EventArgs e)
		{
			GeroMachine.State[] states = new GeroMachine.State[3]
			{
				new GeroMachine.NormalState(),
				new GeroMachine.NormalState(),
				new GeroMachine.NormalState()
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
			state_machine.RunAsync();
		}

		/// <summary>
		/// デバッグ用
		/// </summary>
		private void ShowCurrentState(int currentStateId)
		{
			CurrentStateIdLabel.Text = currentStateId.ToString();
		}
	}
}

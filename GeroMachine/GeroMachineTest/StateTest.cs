using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeroMachineTest
{
	public class StateTest
	{
		[Fact]
		public void PassingTest()
		{
			GeroMachine.State state = new GeroMachine.State();
			Assert.Equal(0, state.CheckTrigger());
		}
	}
}

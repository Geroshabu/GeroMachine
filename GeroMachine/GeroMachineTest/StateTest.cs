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

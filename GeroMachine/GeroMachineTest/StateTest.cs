using Xunit;

namespace GeroMachineTest
{
	public class NormalStateTest
	{
		[Fact]
		public void PassingTest()
		{
			GeroMachine.NormalState state = new GeroMachine.NormalState();
			Assert.Equal(0, state.CheckTrigger());
		}
	}
}

using Xunit;

namespace GeroMachineTest
{
	public class NormalStateTest
	{
		[Fact]
		public void PassingTest()
		{
			GeroMachine.Trigger[] triggers = new GeroMachine.Trigger[1]
			{
				new GeroMachine.Trigger()
			};
			GeroMachine.NormalState state = new GeroMachine.NormalState(triggers);
			Assert.Equal(1u, state.CheckTrigger());
		}
	}
}

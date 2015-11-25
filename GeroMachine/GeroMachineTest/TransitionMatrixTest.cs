using Xunit;

namespace GeroMachineTest
{
	public class TransitionMatrixTest
	{
		/// <summary>
		/// インスタンス作成前, および作成時のテスト
		/// </summary>
		public class CreationTest
		{
			[Fact(DisplayName = "Transition:Creation:コンストラクタの単純な値初期化テスト", Skip ="NotImplemented")]
			public void TestConstructor()
			{
			}

			[Fact(DisplayName ="TransitionMatrix:Creation:null引数のテスト", Skip = "NotImplemented")]
			public void TestNullArgumentConstructor()
			{
			}
		}

		/// <summary>
		/// あるインスタンスに対してのテスト
		/// </summary>
		public class RegularInstanceTest
		{
			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:正常ケース", Skip = "NotImplemented")]
			public void TestSearchTransition()
			{
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:正常ケース(該当する遷移がない場合)", Skip = "NotImplemented")]
			public void TestSearchTransitionNoTransition()
			{
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:第一引数がnullエラー", Skip = "NotImplemented")]
			public void TestSearchTransitionNullArgument1()
			{
			}

			[Fact(DisplayName = "TransitionMatrix:RegularInstance:SearchTransition:第二引数がnullエラー", Skip = "NotImplemented")]
			public void TestSearchTransitionNullArgument2()
			{
			}
		}
	}
}

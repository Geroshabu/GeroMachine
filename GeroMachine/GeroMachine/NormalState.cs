using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
	public class NormalState : State
	{
		/// <summary>
		/// �Ȃɂ��C�x���g���������Ă����炻�̃C�x���gID��Ԃ�.
		/// </summary>
		/// <returns>�Ƃ肠����0�Œ�</returns>
		public override int CheckTrigger()
		{
			return 0;
		}
	}
}

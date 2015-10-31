using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroMachine
{
    public class StateMachine
    {
        private int CurrentStateId;
        private State[] States;
        private int[,] TransitionMatrix;

        public StateMachine()
        {
            States = new State[3]
            {
                new State(),
                new State(),
                new State()
            };
            CurrentStateId = 0;

            TransitionMatrix = new int[3, 1]
            {
                { 1 },
                { 2 },
                { 0 }
            };
        }

        /// <summary>
        /// ステートマシンの実行
        /// </summary>
        public void Run()
        {
            while (true)
            {
                int trigger = States[CurrentStateId].CheckTrigger();
                int next_state_index = TransitionMatrix[CurrentStateId, trigger];
                CurrentStateId = next_state_index;
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}

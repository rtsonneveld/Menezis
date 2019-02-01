using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menezis {
    public class State {
        public StateMachine stateMachine;
        public Func<Task> action;

        private State(){}

        public static State Create(Func<Task> action)
        {
            State state = new State();
            state.action = action;
            return state;
        }

        public async Task Update()
        {
            await action?.Invoke();
        }

        public override String ToString()
        {
            return action.Method.Name;
        }
    }
}

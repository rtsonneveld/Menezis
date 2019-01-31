using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menezis {
    public class State {
        public StateMachine stateMachine;
        public Func<IEnumerator> action;

        private State(){}

        public static State Create(Func<IEnumerator> action)
        {
            State state = new State();
            state.action = action;
            return state;
        }

        public IEnumerator Update()
        {
            yield return action?.DynamicInvoke();
        }

        public override String ToString()
        {
            return action.Method.Name;
        }
    }
}

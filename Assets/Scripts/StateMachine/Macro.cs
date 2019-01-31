using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menezis {
    public class Macro {
        public StateMachine stateMachine;
        public string name;
        public Func<IEnumerator> action;
        public int index;

        private Macro(){}

        public static Macro Create(string name, Func<IEnumerator> action)
        {
            Macro macro = new Macro();
            macro.name = name;
            macro.action = action;
            return macro;
        }

        public void Execute()
        {
            this.action();
        }
    }
}

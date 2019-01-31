using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menezis {
    public class StateMachine {

        //List<Macro> macros;
        Perso perso;

        public State activeRuleState;
        public State activeReflexState;

        private bool delayUpdate = false; // Updates need to be delayed one frame when an object has just been created

        public StateMachine(Perso perso)
        {
            this.perso = perso;

            activeRuleState = null;
            activeReflexState = null;
        }

        public IEnumerator UpdateRule()
        {
            while (true) {
                if (activeRuleState != null && !delayUpdate) {
                    yield return activeRuleState.Update();
                }

                yield return null;
            }
        }

        public IEnumerator UpdateReflex()
        {
            while (true) {
                if (activeReflexState != null && !delayUpdate) {
                    yield return activeReflexState.Update();
                }
                yield return null;
            }
        }

        public void DelayUpdate()
        {
            this.delayUpdate = true;
        }

        public void ResetDelayUpdate()
        {
            this.delayUpdate = false;
        }

        public void ChangeActiveRuleState(Func<IEnumerator> action)
        {
            this.activeRuleState = State.Create(action);
        }

        public void ChangeActiveReflexState(Func<IEnumerator> action)
        {
            this.activeReflexState = State.Create(action);
        }
    }
}
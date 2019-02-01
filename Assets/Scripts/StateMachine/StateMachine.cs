using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis {
    public class StateMachine {

        //List<Macro> macros;
        Perso Perso;

        public State ActiveState;

        public bool Busy { get; private set; } = false;

        private bool delayUpdate = false; // Updates need to be delayed one frame when an object has just been created

        public StateMachine(Perso perso)
        {
            this.Perso = perso;

            ActiveState = null;
        }

        public async Task Update()
        {
            Busy = true;

            if (ActiveState != null && !delayUpdate) {
                await ActiveState.Update();
            }

            Busy = false;
        }

        public void DelayUpdate()
        {
            this.delayUpdate = true;
        }

        public void ResetDelayUpdate()
        {
            this.delayUpdate = false;
        }

        public void SetState(Func<Task> state)
        {
            this.ActiveState = State.Create(state);
        }

    }
}
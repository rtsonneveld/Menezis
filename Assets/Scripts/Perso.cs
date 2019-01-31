using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis {
    public class Perso : MonoBehaviour {

        protected StateMachine sm;
        protected CustomBits customBits;

        // Used for scripts:
        protected int globalRandomizer;
        private float timeSinceLastFrame;

        private bool delayUpdate = false; 

        public string ActiveRule
        {
            get
            {
                return sm?.activeRuleState?.ToString();
            }
        }

        public string ActiveReflex
        {
            get
            {
                return sm?.activeReflexState?.ToString();
            }
        }

        protected virtual void Start()
        {
            sm = new StateMachine(this);
            customBits = new CustomBits(32);

            StartCoroutine(UpdateStateMachineRule());
            StartCoroutine(UpdateStateMachineReflex());
        }

        void Update()
        {
            timeSinceLastFrame += Time.deltaTime;
            if (timeSinceLastFrame > 1.0f/60.0f) {
                timeSinceLastFrame = 0.0f;
                globalRandomizer += 1;
            }

            // No more delaying of updates
            sm.ResetDelayUpdate();

        }

        // Delay update by a frame
        public void DelayUpdate()
        {
            this.sm?.DelayUpdate();
        }


        protected IEnumerator UpdateStateMachineRule()
        {
            yield return sm.UpdateRule();
        }

        protected IEnumerator UpdateStateMachineReflex()
        {
            yield return sm.UpdateReflex();
        }

        public Vector3 Position()
        {
            return this.transform.position;
        }

        public void Proc_ChangeOneCustomBit(int index, bool value)
        {
            // Rayman 2 uses indexes here that start with 1 instead of 0
            customBits.SetCustomBit(index - 1, value);
        }

        public bool Cond_IsCustomBitSet(int index)
        {
            // Rayman 2 uses indexes here that start with 1 instead of 0
            return customBits.GetCustomBit(index - 1);
        }
    }
}

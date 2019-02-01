using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis {
    public class Perso : MonoBehaviour {

        protected StateMachine smRule;
        protected StateMachine smReflex;

        public CustomBits customBits;

        // Used for scripts:
        protected int globalRandomizer;
        private float timeSinceLastFrame;

        public string ActiveRule
        {
            get
            {
                return smRule?.ActiveState?.ToString();
            }
        }

        public string ActiveReflex
        {
            get
            {
                return smReflex?.ActiveState?.ToString();
            }
        }

        protected virtual void Start()
        {
            smRule = new StateMachine(this);
            smReflex = new StateMachine(this);

            customBits = new CustomBits(32);
        }

        protected async void Update()
        {
            timeSinceLastFrame += Time.deltaTime;
            if (timeSinceLastFrame > 1.0f/60.0f) {
                timeSinceLastFrame = 0.0f;
                globalRandomizer += 1;
            }

            if (!smRule.Busy) {
                await smRule.Update();
            }
            if (!smReflex.Busy) {
                await smReflex.Update();
            }

            // No more delaying of updates
            smRule.ResetDelayUpdate();
            smReflex.ResetDelayUpdate();

        }

        // Delay updates by a frame
        public void DelayUpdate()
        {
            this.smRule?.DelayUpdate();
            this.smReflex?.DelayUpdate();
        }
    }
}

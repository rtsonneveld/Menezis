using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menezis.AIModels {

    public class World : Perso {

        public List<int> IntegerArray_25 = new List<int>();

        // Start is called before the first frame update
        protected override void Start()
        {

            for (int i=0;i<100;i++)
            IntegerArray_25.Add(0);
        }

        // Update is called once per frame
        protected void Update()
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menezis {
    public class StarsBackground : MonoBehaviour {
        Material material;

        // Start is called before the first frame update
        void Start()
        {
            this.material = this.gameObject.GetComponent<MeshRenderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            this.material.mainTextureOffset += new Vector2(Time.deltaTime / 2, Time.deltaTime * 2); // = this.material.mainTextureOffset
        }
    }
}
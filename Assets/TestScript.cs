using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    string frameString = "0 ";
    int bab = 3;
    bool updateReady = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    async void Update()
    {
        if (updateReady) {

            updateReady = false;
            await MyUpdate();
            updateReady = true;
        }
    }

    // Update is called once per frame
    async Task MyUpdate()
    {

        frameString = "F" + Time.frameCount + " ";
        await SubAction();

    }

    async Task SubAction()
    {
        Debug.Log(frameString + "SubAction Start");

        Debug.Log("Continue in 1 second");
        await new WaitForSeconds(1.0f);

        Debug.Log(frameString + "SubAction End");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStateController : MonoBehaviour
    
{
    public GameObject UIFail, UITimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownScript.fail == true && TriggerFlip.success == false && TriggerFlip.failure == false)
        {

            UIFail.SetActive(true);
            UITimer.SetActive(false);
            CountdownScript.fail = false;
        }
        if(CountdownScript.fail == false && TriggerFlip.failure == true || CountdownScript.fail == false && TriggerFlip.success == true)
        {
            UITimer.SetActive(false);
            TriggerFlip.failure = false;
            TriggerFlip.success = false;

        }
    }
}

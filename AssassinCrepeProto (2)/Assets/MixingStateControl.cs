using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingStateControl : MonoBehaviour
{
    public GameObject UIFail, UIWin, UITimer;
    // Start is called before the first frame update
    void Update()
    {
        if (CountdownScript.fail == true && IndicatorMove.win == true)
        {

            UIWin.SetActive(true);
            UITimer.SetActive(false);
            CountdownScript.fail = false;
            IndicatorMove.win = false;
        }
        if (CountdownScript.fail == true && IndicatorMove.lose == true)
        {
            UIFail.SetActive(true);
            UITimer.SetActive(false);
            CountdownScript.fail = false;
            IndicatorMove.lose = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingStateController : MonoBehaviour
{
    public GameObject UIFail, UISuccess, UITimer;
    bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownScript.fail == true)
        {
            if (ProgressBar.success == true)
            {
                UITimer.SetActive(false);
                UISuccess.SetActive(true);
                //ScoreReport.passed.Add(true);

                switch (PoisonScoreCount.minigameScore)
                {
                    case 0:
                        PoisonScoreCount.minigameScore = 1;
                        check = true;
                        break;
                    case 1:
                        PoisonScoreCount.minigameScore = 2;
                        check = true;
                        break;
                    default:
                        break;

                }
                CountdownScript.fail = false;


            }
            else
            {
                UITimer.SetActive(false);
                UIFail.SetActive(true);
                CountdownScript.fail = false;

            }

        }
    }
}


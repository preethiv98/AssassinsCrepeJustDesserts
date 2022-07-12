using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoStateController2 : MonoBehaviour
{
    public GameObject UIFail, UISuccess, UITimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CountdownScript.fail == true)
        {
            if (DecoratingCheck.success == true)
            {
                ScoreReport.passed[4] = true;
                UITimer.SetActive(false);
                UISuccess.SetActive(true);
                if (PoisonScoreCount.minigameScore == 0)
                {
                    PoisonScoreCount.minigameScore = 1;
                }
                else if (PoisonScoreCount.minigameScore == 1)
                {
                    PoisonScoreCount.minigameScore = 2;
                }
                else if (PoisonScoreCount.minigameScore == 2)
                {
                    PoisonScoreCount.minigameScore = 3;
                }
                else if (PoisonScoreCount.minigameScore == 3)
                {
                    PoisonScoreCount.minigameScore = 4;
                }
                else if (PoisonScoreCount.minigameScore == 4)
                {
                    PoisonScoreCount.minigameScore = 5;
                }
                Debug.Log(PoisonScoreCount.minigameScore);

                CountdownScript.fail = false;
            }
          
            else
            {
                UITimer.SetActive(false);
                UIFail.SetActive(true);
                ScoreReport.passed[4] = false;
                CountdownScript.fail = false;
            }
        }
    }
}

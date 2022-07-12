using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoStateCtrlToppings : MonoBehaviour
{
    public GameObject UIFail, UISuccess, UITimer;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownScript.fail == true)
        {
            if (DecoratingCheck2.success == true)
            {
                UISuccess.SetActive(true);
                UITimer.SetActive(false);
                if (!check)
                {
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
                        case 2:
                            PoisonScoreCount.minigameScore = 3;
                            check = true;
                            break;
                        case 3:
                            PoisonScoreCount.minigameScore = 4;
                            check = true;
                            break;
                        case 4:
                            PoisonScoreCount.minigameScore = 5;
                            check = true;
                            break;
                        default:
                            break;

                    }
                    Debug.Log(PoisonScoreCount.minigameScore);

                }
                CountdownScript.fail = false;
            }

            else
            {
                UIFail.SetActive(true);
                UITimer.SetActive(false);
                CountdownScript.fail = false;
            }
        }

    }
}

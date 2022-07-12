using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStateControl : MonoBehaviour
{
    public GameObject UIFail, UISuccess, UITimer;
    // Start is called before the first frame update
    void Start()
    {
        ScoreScript.scoreValue = 100;
        EggCracked.eggCrack = 0;
        Debug.Log(EggCracked.eggCrack + " this is how many eggs cracked");
    }

    // Update is called once per frame
    void Update()
    {
        if (DragOnClick.success == true)
        {
           
            
            UISuccess.SetActive(true);
            ScoreReport.passed[0] = true;
            if (UISuccess.activeSelf)
            {
                PoisonScoreCount.minigameScore = 1;
                Debug.Log(PoisonScoreCount.minigameScore);
            }
            //ScoreScript.scoreValue = 100;
            //EggCracked.eggCrack = 0;
            UITimer.SetActive(false);
            DragOnClick.success = false;
            
        }

        if (CountdownScript.fail == true && DragOnClick.success == false)
        {
            ScoreReport.passed[0] = false;
            UIFail.SetActive(true);
            UITimer.SetActive(false);
            Debug.Log(PoisonScoreCount.minigameScore);
            CountdownScript.fail = false;
        }
   
    }

   
}

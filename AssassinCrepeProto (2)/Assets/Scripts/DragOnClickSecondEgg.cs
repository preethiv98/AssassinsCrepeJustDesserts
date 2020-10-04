using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragOnClickSecondEgg : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public Image myImage;
    public GameObject crackedEgg;
    public GameObject wholeEgg;
    //public GameObject secondEgg;
    public GameObject UI;
    public GameObject UIFail;
    public GameObject UITimer;
    public GameObject yolk;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bowl")
        {
            if (myImage.fillAmount < 0.9)
            {
                Debug.Log("Failure");
                ScoreScript.scoreValue -= 10;
                if (ScoreScript.scoreValue <= 0)
                {
                    gameObject.SetActive(false);
                    wholeEgg.SetActive(false);
                    crackedEgg.SetActive(true);
                    UIFail.SetActive(true);
                    ScoreScript.scoreValue = 100;
                }
                //SpawnEgg();
            }
            else
            {
                Debug.Log("Destroyed");
                yolk.SetActive(true);

                gameObject.SetActive(false);
                wholeEgg.SetActive(false);
                //secondEgg.SetActive(true);
                crackedEgg.SetActive(true);
                UI.SetActive(true);
                UITimer.SetActive(false);
                PoisonScoreCount.minigameScore++;
                ScoreScript.scoreValue = 100;
                EggCracked.eggCrack++;
              
                


            }

        }
    }
}

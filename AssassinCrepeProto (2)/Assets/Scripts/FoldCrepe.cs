using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldCrepe : MonoBehaviour
{
    public GameObject Crepe1;
    public GameObject Crepe2;
    public GameObject Crepe3;
    public GameObject Crepe4;

    public GameObject UpArrow;
    public GameObject DownArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    public GameObject WinState;
    public GameObject LoseState;

    void Start()
    {
        StartCoroutine(ButtonCountdown());
    }


    // Would like to refine this so that when player misses a displayed arrow, but inputs correctly on the next one, the game will still fold the crepe in the correct order
    // (as opposed to skipping ahead to the third stage of the crepe folding)

    void Update()
    {
        // If player presses correct key while the arrow is displayed in the UI

        if (Input.GetKeyDown(KeyCode.UpArrow)&& UpArrow.activeSelf)
        {
            if (Crepe1.activeSelf == true)
            {

                Crepe1.SetActive(false);
                Crepe2.SetActive(true);
            }
            else if (Crepe2.activeSelf == true) {

                Crepe2.SetActive(false);
                Crepe3.SetActive(true);

            }
            else if (Crepe3.activeSelf == true)
            {

                Crepe3.SetActive(false);
                Crepe4.SetActive(true);

            }


        }
        ////

        if (Input.GetKeyDown(KeyCode.DownArrow) && DownArrow.activeSelf)
        {
            if (Crepe1.activeSelf == true)
            {

                Crepe1.SetActive(false);
                Crepe2.SetActive(true);
            }
            else if (Crepe2.activeSelf == true)
            {

                Crepe2.SetActive(false);
                Crepe3.SetActive(true);

            }
            else if (Crepe3.activeSelf == true)
            {

                Crepe3.SetActive(false);
                Crepe4.SetActive(true);

            }
        }


            if (Input.GetKeyDown(KeyCode.RightArrow) && RightArrow.activeSelf)
        {
            if (Crepe1.activeSelf == true)
            {

                Crepe1.SetActive(false);
                Crepe2.SetActive(true);
            }
            else if (Crepe2.activeSelf == true)
            {

                Crepe2.SetActive(false);
                Crepe3.SetActive(true);

            }
            else if (Crepe3.activeSelf == true)
            {

                Crepe3.SetActive(false);
                Crepe4.SetActive(true);

            }
        }

       

        if (Input.GetKeyDown(KeyCode.LeftArrow) && LeftArrow.activeSelf)
        {
            if (Crepe1.activeSelf == true)
            {

                Crepe1.SetActive(false);
                Crepe2.SetActive(true);
            }
            else if (Crepe2.activeSelf == true)
            {

                Crepe2.SetActive(false);
                Crepe3.SetActive(true);

            }
            else if (Crepe3.activeSelf == true)
            {

                Crepe3.SetActive(false);
                Crepe4.SetActive(true);

            }
        }

        //get win state during void update

        if (Crepe4.activeSelf == true)
        {
            WinState.SetActive(true);
            PoisonScoreCount.minigameScore++;
        }

    }

    // Coroutine for sequence of arrow displayed. Is there a way to randomize the set on each play? This is a placeholder sequence for now.
    // Also to continuously play random arrows before timer runs out.

    IEnumerator ButtonCountdown()
    {

        yield return new WaitForSecondsRealtime(2);

        UpArrow.SetActive(false);
        DownArrow.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        DownArrow.SetActive(false);
        RightArrow.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        RightArrow.SetActive(false);
        LeftArrow.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        LeftArrow.SetActive(false);

        //if final crepe form isn't activated after coroutine, activate lose state

        if (Crepe4.activeSelf == false)
        {
            LoseState.SetActive(true);
        }
    }

    
}

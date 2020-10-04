using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IndicatorMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Image smallMeter;
    public Image meter;
    public Image indicator;
    public GameObject success;
    public GameObject fail;
    private float finalX;
    Animator anim;
    public Text score;

    void Start()
    {
        finalX = meter.GetComponent<MoveMeter>().finalX;
        anim = GetComponent<Animator>();
        StartCoroutine(Move());

    }

    IEnumerator Move()
    {
        yield return new WaitForSecondsRealtime(15);

        if (Int32.Parse(score.text) > 50)
        {
            success.SetActive(true);
            PoisonScoreCount.minigameScore++;
        }
        else
        {
            fail.SetActive(true);
        }
       
    }

}

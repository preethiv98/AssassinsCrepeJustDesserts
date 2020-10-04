using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveMeter : MonoBehaviour
{
    public float speed = 1f;
    public float initialX;
    public float finalX;
    public float fractionPos = 0f;
    public Image bigMeter;
    public Image smallMeter;
    public Image indicator;
    public Text score;
    public GameObject fail;
    public GameObject success;
    Color initialColor;
    void Start()
    {
        initialX = transform.localPosition.x;
        finalX = (bigMeter.rectTransform.localPosition.x + (bigMeter.rectTransform.rect.height / 2)) - smallMeter.rectTransform.rect.height / 2;
        initialColor = smallMeter.color;
        smallMeter.color = initialColor;
    }
    void Update()
    {
        fractionPos = (transform.localPosition.x - initialX) / (finalX - initialX);
        if (Int32.Parse(score.text) == 0)
        {
            fail.SetActive(true);
        }
        if (Input.GetButton("Jump"))
        {
            if (transform.localPosition.x < finalX)
            {
                float move = Mathf.Lerp(transform.localPosition.x, finalX, 0.005f);

                transform.Translate(0, transform.localPosition.x - move, 0, Space.Self);

            }
        }
        else
        {
            if (transform.position.x > initialX)
            {
                float move = Mathf.Lerp(transform.localPosition.x, initialX, 0.005f);
                transform.Translate(0, transform.localPosition.x - move, 0, Space.Self);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        smallMeter.color = initialColor;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!success.activeInHierarchy && !fail.activeInHierarchy)
        {
            Color c = new Color(255, 0, 0, 0.5f);
            smallMeter.color = c;
            if (Int32.Parse(score.text) > 0)
            {
                int newScore = Int32.Parse(score.text) - 10;
                score.text = newScore.ToString();
            }
        }
    }
}

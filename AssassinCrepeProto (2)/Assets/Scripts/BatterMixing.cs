using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterMixing : MonoBehaviour
{
    public float speed = 0f;
    public float speed_increase_i;
    private float speed_increase;
    private float increaseFactor = 0.001f;
    private float decreaseFactor = 0.001f;
    const float MAX_SPEED = 1.0f;
    public Image meter;
    private float fraction;

    private void Start()
    {
        speed_increase = speed_increase_i;
        fraction = meter.GetComponent<MoveMeter>().fractionPos;
    }
    void Update()
    {
       
        fraction = meter.GetComponent<MoveMeter>().fractionPos;
        if (Input.GetButton("Jump"))
        {
            StartCoroutine(IncreaseSpeed(fraction, MAX_SPEED));
            if (speed_increase > 8.0f)
            {
                speed_increase -= increaseFactor;
            }
            increaseFactor += 0.001f;
        }
        else
        {
            decreaseFactor = increaseFactor;
            increaseFactor = 0.001f;

            if (fraction < 0.005f)
            {
                speed = Mathf.Lerp(speed, 0, 0.01f);
                transform.Rotate(0, speed, 0);
                speed_increase = speed_increase_i;
            }
            else
            {
                if (speed > 0f)
                {
                    
                    speed += 1f;
                    StartCoroutine(IncreaseSpeed(fraction, 0));
                }
                
            }
        }

    }


    private IEnumerator IncreaseSpeed(float fromSpeed, float toSpeed)
    {
        for (float t = 0; t < 1f; t += Time.deltaTime * speed_increase)
        {
            speed = Mathf.Lerp(fromSpeed, toSpeed, t);
            transform.Rotate(0, speed, 0);
            yield return null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedFill : MonoBehaviour
{
    // Start is called before the first frame update
    public Image myImage;
    public GameObject batter;
    public float waitTime = 5.0f;
    public bool repeat;
    private BatterMixing batterScript;
    private float speed;
    private float fraction = 0.0f;
    private float end;
    
    void Start()
    {
        batterScript = batter.GetComponent<BatterMixing>();
        end = 1.0f;
        //Do something
        ChangeFill(0, end, 0.0f);
        //yield return ChangeFill(1.0f, 0.0f);
        
    }

    void Update()
    {
    }

    public void ChangeFill(float start, float end, float frac)
    {      


    }



}


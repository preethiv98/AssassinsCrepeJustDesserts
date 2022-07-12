using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float fillSpeed = 0.5f;
    private bool on = false;
    public static bool success;
    private float targetProgress = 0;
    public GameObject UnCooked, KindOf, Ready, Burnt;
    // Start is called before the first frame update

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        IncrementProgress(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(on == true)
        {
            if (slider.value < targetProgress)
                slider.value += fillSpeed * Time.deltaTime;
        
        }
        State();

    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void TurnOn()
    {
        on = !on;
    }

     void State()
    {

        if (slider.value >= .70f && slider.value <= .75f )
        {
          
            success = true;
            Ready.SetActive(true);
         

        }
        else if (slider.value > .75f)
        {
            Burnt.SetActive(true);
            Ready.SetActive(false);
            success = false;
           
        }
        else if(slider.value > .35f)
        {
            KindOf.SetActive(true);
            UnCooked.SetActive(false);
            success = false;
        }
        else
        {
            success = false;
    

        }

    }

}

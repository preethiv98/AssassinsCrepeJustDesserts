using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject objective;

    public static bool paused = false;

   
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         
            panel.SetActive(true);
            Freeze();
            paused = true;
            
        }
        //if(!panel.activeSelf)
        //{
        //    if(objective.activeSelf)
        //    {
        //        Time.timeScale = 1;
        //    }
           
        //}
      

    }

    void Freeze()
    {
        Time.timeScale = 0;
    }
}

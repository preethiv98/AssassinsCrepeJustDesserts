using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlacement : MonoBehaviour
{
    public GameObject placement;
    // Start is called before the first frame update

    public void OnClick()
    {
           StartCoroutine(HoldForSeconds());
         
    }

    IEnumerator HoldForSeconds()
    {
        //placement.SetActive(true);
        yield return new WaitForSeconds(5);
        placement.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }


}

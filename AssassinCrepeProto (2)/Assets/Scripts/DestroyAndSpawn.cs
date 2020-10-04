using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAndSpawn : MonoBehaviour
{
    public Image myImage;
    public GameObject egg;
    public GameObject Model;

    public Vector3 touchPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  

    void Update()
    {
       if (myImage.fillAmount < 0.8 && egg.activeSelf == false)
        {
            Debug.Log("Successful");
            ScoreScript.scoreValue -= 10;
         // SpawnEgg();
        }
    }

   // void Show()
   // {
      //  egg.SetActive(true);
  //  }

   // void SpawnEgg()
   // {
     //   if(Model.name != "Egg(Clone)")
     //   {
      //      touchPos = new Vector3(-1.281304f, 3.375296f, 0.1516412f);
       //     Instantiate(egg, touchPos, Quaternion.identity);
      //  }
        
   // }
}

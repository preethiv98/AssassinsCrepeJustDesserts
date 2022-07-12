using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percent : MonoBehaviour
{
     public Text displayPercent;
     public double percentage;
     public double frosted;
     public double total;
        
    
    // Start is called before the first frame update
    void Start()
    {
        displayPercent =  GetComponent<Text>();
        percentage = 0;
        //total = Frosting.totalPieces;
        //frosted = Frosting.totalFrostedPieces;

    }

    // Update is called once per frame


    void Update()
    {
        frosted = Frosting.totalFrostedPieces;
        total = Frosting.totalPieces;
        percentage =  (frosted / total) * 100;
        percentage = System.Math.Round(percentage);
        displayPercent.text  = percentage.ToString() + '%';
    }
}

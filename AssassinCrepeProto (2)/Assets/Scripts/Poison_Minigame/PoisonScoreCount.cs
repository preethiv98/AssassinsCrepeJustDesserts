using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoisonScoreCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static int minigameScore = 0;
    private static int winOrLose;
    public GameObject win;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(minigameScore == 5)
        {
            winOrLose = 100;
        }
        if(minigameScore == 4)
        {
            winOrLose = Random.Range(75, 100);
        }
        if(minigameScore == 3)
        {
            winOrLose = Random.Range(50, 100);
        }
        if(minigameScore == 2)
        {
            winOrLose = Random.Range(25, 100);
        }
        if(minigameScore == 1)
        {
            winOrLose = Random.Range(1, 100);
        }
        if(winOrLose >= 75)
        {
            win.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    /*
     * Initializing variables for the text that will display the stats
     */
    public Text played1;
    public Text successfullyLvl1;
    public Text played2;
    public Text successfullyLvl2;
    public Text mostSuccessful1;
    public Text mostSuccessful2;
    public Text worstLevel1;
    public Text worstLevel2;

    public GameObject statsPanel;

    string mostsuccessfulLvl1 = " ";
    string worstMinigame1 = " ";

    string mostsuccessfulLvl2 = " ";
    string worstMinigame2 = " ";


    public int playedLvl1 = 0;// you can set a default value here
    public int playedLvl2 = 0;// you can set a default value here
    public int successfulLvl1 = 0;// you can set a default value here
    public int successfulLvl2 = 0;// you can set a default value here

    //Create the Lists of type Stats Lists that holds the minigames in the game and the number of times the player has
    //successfully completed the respective minigame
    public  List<StatsList> stats;
    public  List<StatsList> statsLvl2;
    public class StatsList
    {
        public string minigame = "";
        public int count = 0;
    }

    //Constructor that creates the size of the Lists
    public GameStats()
    {
        stats = new List<StatsList>(5);
        statsLvl2 = new List<StatsList>(5);
       
    }

    void Awake()
    {
     
        GameObject[] objs = GameObject.FindGameObjectsWithTag("stats");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
       
    }

    // Start is called before the first frame update
    void Start()
    {

        statsPanel.SetActive(false);
        //DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < 5; i++)
        {
            stats.Add(new StatsList());
        }
        for (int i = 0; i < 5; i++)
        {
            statsLvl2.Add(new StatsList());
        }

      //  foreach (StatsList stat in stats)
      //  {
       //     stat.minigame = "";
        //    stat.count = 0;
       // }
        //foreach (StatsList stat in statsLvl2)
       // {
        //    stat.minigame = "";
       //     stat.count = 0;
       // }
       
        //stats[0].count = 0;
        //Debug.Log(stats[0].count);
        stats[0].minigame = "Crepe Egg";
        stats[1].minigame = "Crepe Mixing";
        stats[2].minigame = "Crepe Cooking";
        stats[3].minigame = "Crepe Folding";
        stats[4].minigame = "Crepe Decorating";
        statsLvl2[0].minigame = "Cake Egg";
        statsLvl2[1].minigame = "Cake Mixing";
        statsLvl2[2].minigame = "Cake Baking";
        statsLvl2[3].minigame = "Cake Icing";
        statsLvl2[4].minigame = "Cake Decorating";
       // stats[0].count = 5;
       // statsLvl2[0].count = 5;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main_Menu"))
        {
            if(!statsPanel)
            {
                statsPanel = GameObject.Find("Stats");
                statsPanel.SetActive(false);
            }
          
            if (statsPanel.activeSelf)
            {
                
                played1 = GameObject.Find("played1").GetComponent<Text>();
                played2 = GameObject.Find("played2").GetComponent<Text>();
                successfullyLvl1 = GameObject.Find("successfullvl1").GetComponent<Text>();
                successfullyLvl2 = GameObject.Find("successfullvl2").GetComponent<Text>();
                mostSuccessful1 = GameObject.Find("mostsucesssful1").GetComponent<Text>();
                mostSuccessful2 = GameObject.Find("mostsucessful2").GetComponent<Text>();
                worstLevel1 = GameObject.Find("worstlevel1").GetComponent<Text>();
                worstLevel2 = GameObject.Find("worstlevel2").GetComponent<Text>();

                Calculate();

                played1.text = "Times Played: " + playedLvl1;
                played2.text = "Times Played: " + playedLvl2;
                successfullyLvl1.text = "Times Successfully Completed: " + successfulLvl1;
                successfullyLvl2.text = "Times Successfully Completed: " + successfulLvl2;
                mostSuccessful1.text = "Most Successful Minigame: " + mostsuccessfulLvl1;
                mostSuccessful2.text = "Most Successful Minigame: " + mostsuccessfulLvl2;
                worstLevel1.text = "Minigame You Stank At the Most: " + worstMinigame1;
                worstLevel2.text = "Minigame You Stank At The Most: " + worstMinigame2;

                //Debug.Log(stats[0].count);                  
            }
            
            
        }
        
        
    }

    //Calculates the minigames player best performed at and worst performed at
    void Calculate()
    {
        //Debug.Log(stats[0].count);
        bool allthesame = true;
        bool allthesame2 = true;
        bool allzero1 = true;
        bool allzero2 = true;
        int c = 0;
        int d = 0;
        int e = 999;
        int f = 999;
        for(int i = 0; i < stats.Count; i++)
        {
            if(stats[i].count != 0)
            {
                allzero1 = false;
            }
            if (statsLvl2[i].count != 0)
            {
                allzero2 = false;
            }            

        }
        Debug.Log(c);
        Debug.Log(allzero1);
        if(allzero1)
        {
            mostsuccessfulLvl1 = "N/A";
            worstMinigame1 = "N/A";
            
        }
       if(allzero2)
        {
            mostsuccessfulLvl2 = "N/A";
            worstMinigame2 = "N/A";
            
        }
        if (allzero2 && !allzero1)
        {
            for (int i = 0; i < stats.Count - 1; i++)
            {
                if (stats[i].count != stats[i + 1].count)
                {
                    allthesame = false;
                }
            }

            for (int j = 0; j < stats.Count - 1; j++)
            {
                if (statsLvl2[j].count != statsLvl2[j + 1].count)
                {
                    allthesame2 = false;
                }

            }
            if (allthesame)
            {
                mostsuccessfulLvl1 = "Crepe Decorating";
                worstMinigame1 = "N/A";
            }
            //if (allthesame2)
            //{
            //    mostsuccessfulLvl2 = "Cake Decorating";
            //    worstMinigame2 = "N/A";
            //}
            else
            {
                allthesame2 = false;
                allthesame = false;
                for (int i = 0; i < stats.Count; i++)
                {
                    if (c < stats[i].count)
                    {

                        c = stats[i].count;
                    }

                    if (e > stats[i].count)
                    {
                        e = stats[i].count;
                    }

                }
                for (int i = 0; i < stats.Count; i++)
                {
                    if (c == stats[i].count)
                    {
                        mostsuccessfulLvl1 = stats[i].minigame;
                    }

                    if (e == stats[i].count)
                    {
                        worstMinigame1 = stats[i].minigame;
                    }

                }
            }
            
        }
        if(!allzero1 && !allzero2)
        {
            for (int i = 0; i < stats.Count - 1; i++)
            {
                if (stats[i].count != stats[i + 1].count)
                {
                    allthesame = false;
                }
            }

            for (int j = 0; j < stats.Count - 1; j++)
            {
                if (statsLvl2[j].count != statsLvl2[j + 1].count)
                {
                    allthesame2 = false;
                }

            }
            if (allthesame)
            {
                mostsuccessfulLvl1 = "Crepe Decorating";
                worstMinigame1 = "N/A";
            }
            if (allthesame2)
            {
                mostsuccessfulLvl2 = "Cake Decorating";
                worstMinigame2 = "N/A";
            }
            else
            {
                allthesame2 = false;
                allthesame = false;
                for (int i = 0; i < stats.Count; i++)
                {
                    if (c < stats[i].count)
                    {

                        c = stats[i].count;
                    }
                    if (d < statsLvl2[i].count)
                    {
                        d = statsLvl2[i].count;
                    }
                    if (e > stats[i].count)
                    {
                        e = stats[i].count;
                    }
                    if (f > statsLvl2[i].count)
                    {
                        f = statsLvl2[i].count;
                    }
                }
                for (int i = 0; i < stats.Count; i++)
                {
                    if (c == stats[i].count)
                    {
                        mostsuccessfulLvl1 = stats[i].minigame;
                    }
                    if (d == statsLvl2[i].count)
                    {
                        mostsuccessfulLvl2 = statsLvl2[i].minigame;
                    }
                    if (e == stats[i].count)
                    {
                        worstMinigame1 = stats[i].minigame;
                    }
                    if (f == stats[i].count)
                    {
                        worstMinigame2 = statsLvl2[i].minigame;
                    }
                }
            }
            
            Debug.Log(c);
        }
        

    }
}

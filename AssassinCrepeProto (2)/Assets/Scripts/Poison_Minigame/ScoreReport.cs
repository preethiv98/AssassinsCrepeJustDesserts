using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreReport : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    bool viewedCredits = false;

    public AudioClip fail;
    public AudioClip success;
    public AudioClip checkmark;
    public AudioClip strike;
    [SerializeField]
    private GameObject[] letter;

    [SerializeField]
    private GameObject[] image;

    public static bool pass = true;
    public static bool toLevelTwo = false;

    public List<ScoreChart> report;

    public GameStats stats;


    public static bool [] passed = new bool [5];

    
    AudioSource source;

    [System.Serializable]
    public class ScoreChart
    {
        public GameObject checkmark;
        public GameObject strike;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        stats = GameObject.Find("StatController").GetComponent<GameStats>();
        StartCoroutine(ScoreList());
    }

    IEnumerator ScoreList()
    {
        
        yield return new WaitForSeconds(2f);
        if(passed[0])
        {
            report[0].checkmark.SetActive(true);
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.stats[0].count++;
                Debug.Log(stats.stats[0].count);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.statsLvl2[0].count++;
            }


            source.PlayOneShot(checkmark, 0.6f);
        }
        else if(!passed[0])
        {
            report[0].strike.SetActive(true);
           
            source.PlayOneShot(strike, 0.6f);
        }
        yield return new WaitForSeconds(2f);
        if (passed[1])
        {
            report[1].checkmark.SetActive(true);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.stats[1].count++;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.statsLvl2[1].count++;
            }
            source.PlayOneShot(checkmark, 0.6f);
        }
        else if (!passed[1])
        {
            report[1].strike.SetActive(true);
            
            source.PlayOneShot(strike, 0.6f);
        }
        yield return new WaitForSeconds(2f);
        if (passed[2])
        {
            report[2].checkmark.SetActive(true);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.stats[2].count++;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.statsLvl2[2].count++;
            }
            source.PlayOneShot(checkmark, 0.6f);
        }
        else if (!passed[2])
        {
            report[2].strike.SetActive(true);
            source.PlayOneShot(strike, 0.6f);
        }
        yield return new WaitForSeconds(2f);
        if (passed[3])
        {
            report[3].checkmark.SetActive(true);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.stats[3].count++;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.statsLvl2[3].count++;
            }
            source.PlayOneShot(checkmark, 0.6f);
        }
        else if (!passed[3])
        {
            report[3].strike.SetActive(true);
            source.PlayOneShot(strike, 0.6f);
        }
        yield return new WaitForSeconds(2f);
        if (passed[4])
        {
            report[4].checkmark.SetActive(true);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.stats[4].count++;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.statsLvl2[4].count++;
            }
            source.PlayOneShot(checkmark, 0.6f);

        }
        else if (!passed[4])
        {
            report[4].strike.SetActive(true);
            source.PlayOneShot(strike, 0.6f);
        }
        int count = 0;
        for(int i = 0; i < passed.Length; i++)
        {
            if(passed[i])
            {
                count++;
            }
        }
        yield return new WaitForSeconds(2f);
        if (count == 5)
        {
            letter[0].SetActive(true);
        }
        else if(count == 4)
        {
            letter[1].SetActive(true);
        }
        else if (count == 3)
        {
            letter[2].SetActive(true);
        }
        else if (count == 2)
        {
            letter[3].SetActive(true);
        }
        else if(count == 1 || count == 0)
        {
            letter[4].SetActive(true);

        }
       
        if (count >= 3 && pass)
        {
            image[1].SetActive(true);
            
            source.PlayOneShot(success, 0.6f);
           
                if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
                {
                    stats.playedLvl1++;
                    stats.successfulLvl1++;
                    button.SetActive(true);
                    toLevelTwo = true;
                }
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
                {
                    stats.playedLvl2++;
                    stats.successfulLvl2++;
                    if (!viewedCredits)
                    {
                        yield return new WaitForSeconds(4.3f);
                        SceneManager.LoadScene(25);

                    }
                   else
                    {
                        button.SetActive(true);
                        toLevelTwo = true;
                    }
                   

                }
                button.SetActive(true);
                toLevelTwo = true;
            
            
           
        }
        else
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelOne"))
            {
                stats.playedLvl1++;
               
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score_LevelTwo"))
            {
                stats.playedLvl2++;
                

            }
            //toLevelTwo = false;
            button.SetActive(true);
            image[0].SetActive(true);
            source.PlayOneShot(fail, 0.6f);
          
        }
       

    }
}

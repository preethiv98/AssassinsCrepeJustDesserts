using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerFlip : MonoBehaviour
{
    [SerializeField]
    private GameObject flipText;

    [SerializeField]
    private GameObject waitText;

    [SerializeField]
    private GameObject button;

    public static int index;

    [SerializeField]
    private GameObject[] strikes;

    [SerializeField]
    private Button myButton;

    [SerializeField]
    private Animator anim;

    private float nextActionTime = 0.0f;
    private float period = 0.1f;

    [SerializeField]
    private GameObject fail;

    

    [SerializeField]
    private Image fillBar;

    [SerializeField]
    private GameObject win;

    private bool check;
    
    public static bool success, failure;
    
    // Start is called before the first frame update
    void Start()
    {
        period = Random.Range(0.3f, 0.6f);
        InvokeRepeating("Flip", 1.0f, period);
        //StartCoroutine(Wait());
    }


   
   

    void OnEnable()
    {

        myButton.onClick.AddListener(ButtonClick);//adds a listener for when you click the button

    }

    void Awake()
    {
        //seconds = Random.Range(1, 5);
    }


    void Flip()
    {
        if(!flipText.activeSelf)
        {
            if(fillBar.fillAmount == 1)
            {
                success = true;
                button.SetActive(false);
                win.SetActive(true);
                ScoreReport.passed[2] = true;
                if (!check)
                {
                    switch(PoisonScoreCount.minigameScore)
                    {
                        case 0:
                            PoisonScoreCount.minigameScore = 1;
                            check = true;
                            break;
                        case 1:
                            PoisonScoreCount.minigameScore = 2;
                            check = true;
                            break;
                        case 2:
                            PoisonScoreCount.minigameScore = 3;
                            check = true;
                            break;
                        default:
                            break;

                    }
                   
                }
                
                
                Debug.Log(PoisonScoreCount.minigameScore);
               
                for(int i = 0; i < strikes.Length; i++)
                {
                    strikes[i].SetActive(false);
                }
            }
            flipText.SetActive(true);
            waitText.SetActive(false);
            Invoke("Resume", period);

        }
        else
        {
            flipText.SetActive(false);
            waitText.SetActive(true);
           
            
            //period = Random.Range(1.0f, 5.0f);
        }
       
    }


    // Update is called once per frame
    void Update()
    {

       // Invoke("Wait", seconds);
        //if (Time.time > nextActionTime)
        //{
        //    nextActionTime = Time.time + period;
        //    flipText.SetActive(true);
        //    waitText.SetActive(false);
        //}
        //else
        //{
        //    nextActionTime = Time.time + period;
        //    flipText.SetActive(true);
        //    waitText.SetActive(false);
        //}
    }

    //IEnumerator  Wait(int seconds)
    //{

    //    yield return WaitForSeconds(seconds);
    //        flipText.SetActive(false);
    //        waitText.SetActive(true);
        
    //}

    public void ButtonClick()
    {
        
        Debug.Log("Clicked");
        if(!flipText.activeSelf)
        {
            
            strikes[index].SetActive(true);
            index++;
            if (index == 3)
            {
                Debug.Log("You lose!");
                failure = true;
                fail.SetActive(true);
                ScoreReport.passed[2] = false;
                button.SetActive(false);
                for (int i = 0; i < strikes.Length; i++)
                {
                    strikes[i].SetActive(false);
                }
            }
        }
        else
        {
            myButton.enabled = false;
            anim.Play("CrepeFlipCook", 0);
            fillBar.fillAmount += 0.2f;
            //myButton.enabled = true;

        }
       

    }

    public void Suspend()
    {
        myButton.enabled = false;
    }

    public void Resume()
    {
        myButton.enabled = true;
    }


   
}

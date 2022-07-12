using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickPoison : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator anim;
    public GameObject particle;

    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Poison")
                {
                    anim.SetBool("poisonClicked", true);
                  

                    //if(PoisonScoreCount.LevelOneWin)
                    //{
                    Debug.Log(PoisonScoreCount.winOrLose);
                    
                    
                    //}
                    Debug.Log("This is a Poison");
                }
                else
                {
                    Debug.Log("This isn't a Poison");
                }
            }
        }

    }

    void SetParticleActive()
    {
        particle.SetActive(true);
    }

    void EndScene()
    {
        if (PoisonScoreCount.LevelOneWin && !PoisonScoreCount.LevelTwoWin  && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Poison")))
        {
            SceneManager.LoadScene(11);
           
            
        }
        else if (PoisonScoreCount.LevelTwoWin)
        {
            SceneManager.LoadScene(22);
          
            
        }
        else if(!PoisonScoreCount.LevelOneWin)
        {
            SceneManager.LoadScene(9);

        }
        else
        {
            SceneManager.LoadScene(21);
        }
    }
}

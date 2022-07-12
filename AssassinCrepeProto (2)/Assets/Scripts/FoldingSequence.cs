using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoldingSequence : MonoBehaviour
{
    public Image fillbar;
    bool failed;
    public GameObject fail;
    public GameObject success;
    public GameObject arrow;
    public List<CrepeFolding> fold;
    private int points = 0;
    public Text pointText;
    public GameObject[] strike;
    public AudioClip correct;
    public AudioClip strikeSound;
    AudioSource source;

    bool mutex = false;
   
    [System.Serializable]
    public class CrepeFolding
    {
        public GameObject crepe;
        public string[] sequence;
    }

    public FoldingSequence()
    {
        fold = new List<CrepeFolding>();
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        points = fold[0].sequence.Length;
        StartCoroutine(Folding());
    }

    // Update is called once per frame
    void Update()
    {
       // pointText.text = "Points: " + points;
        if(Input.GetKeyDown(KeyCode.LeftArrow) && arrow.transform.rotation == Quaternion.Euler(0,0,90) && mutex)
        {
            source.PlayOneShot(correct, 0.6f);
            fillbar.fillAmount += 0.2f;
            
            Debug.Log(mutex);
            mutex = false;
            Debug.Log(points);
            failed = false;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && arrow.transform.rotation == Quaternion.Euler(0, 0, 180) && mutex)
        {
            source.PlayOneShot(correct, 0.6f);
            fillbar.fillAmount += 0.2f;
           
            Debug.Log(mutex);
            mutex = false;
            Debug.Log(points);
            failed = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && arrow.transform.rotation == Quaternion.Euler(0, 0, 270) && mutex)
        {
            source.PlayOneShot(correct, 0.6f);
            fillbar.fillAmount += 0.2f;
           
            Debug.Log(mutex);
            mutex = false;
            Debug.Log(points);
            failed = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && arrow.transform.rotation == Quaternion.Euler(0, 0, 0) && mutex)
        {
            source.PlayOneShot(correct, 0.6f);
            fillbar.fillAmount += 0.2f;
          
            Debug.Log(mutex);
            mutex = false;
            Debug.Log(points);
            //failed = false;
        }
        else if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow))) && arrow.transform.rotation == Quaternion.Euler(0, 0, 90) && mutex)
        {
            source.PlayOneShot(strikeSound, 0.6f);
            fillbar.fillAmount -= 0.2f;
          
            mutex = false;
        }
        else if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow))) && arrow.transform.rotation == Quaternion.Euler(0, 0, 90) && mutex)
        {
            source.PlayOneShot(strikeSound, 0.6f);
            fillbar.fillAmount -= 0.2f;
            

            mutex = false;
        }
        else if (((Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow))) && arrow.transform.rotation == Quaternion.Euler(0, 0, 90) && mutex)
        {
            source.PlayOneShot(strikeSound, 0.6f);
            fillbar.fillAmount -= 0.2f;
            

            mutex = false;
        }
        else if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow))) && arrow.transform.rotation == Quaternion.Euler(0, 0, 90) && mutex)
        {
            fillbar.fillAmount -= 0.2f;
            source.PlayOneShot(strikeSound, 0.6f);

            mutex = false;
        }
        if(fillbar.fillAmount == 0 && !success.activeInHierarchy )
        {
            fail.SetActive(true);
            ScoreReport.passed[3] = false;
        }


    }

    IEnumerator Folding()
    {
        //yield return new WaitForSeconds(3f);
        for(int i = 0; i < fold.Count; i++)
        {
            fold[i].crepe.SetActive(true);
            for(int j = 0; j < fold[i].sequence.Length; j++)
            {
                if(fold[i].sequence[j].ToLower().Trim() == "left")
                {
                    Debug.Log("left");
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
                    mutex = true;
                    yield return new WaitForSeconds(0.8f);
                    fillbar.fillAmount -= 0.2f;

                    //points--;
                    //if(Input.GetKeyDown(KeyCode.LeftArrow))
                    //{

                    //    points++;
                    //    Debug.Log(points);
                    //}
                }
                if (fold[i].sequence[j].ToLower().Trim() == "down")
                {
                    Debug.Log("down");
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                    mutex = true;
                    yield return new WaitForSeconds(0.8f);
                    fillbar.fillAmount -= 0.2f;
                    //yield return new WaitForSeconds(1.5f);
                    //yield return new WaitForSeconds(1.5f);

                    //if (failed)
                    //{
                    //    if (!strike[0].activeSelf)
                    //    {
                    //        strike[0].SetActive(true);
                    //    }
                    //    else if (strike[0].activeSelf)
                    //    {
                    //        strike[1].SetActive(true);
                    //    }
                    //    else
                    //    {
                    //        fail.SetActive(true);
                    //    }
                    //}

                    // points--;
                    //if (Input.GetKeyDown(KeyCode.DownArrow))
                    //{
                    //    points++;
                    //}
                }
                if(fold[i].sequence[j].ToLower().Trim() == "right")
                {
                    Debug.Log("right");
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 270);
                    mutex = true;
                    yield return new WaitForSeconds(0.8f);
                    fillbar.fillAmount -= 0.2f;
                    //yield return new WaitForSeconds(1.5f);
                    //yield return new WaitForSeconds(1.5f);

                    //if (failed)
                    //{
                    //    if (!strike[0].activeSelf)
                    //    {
                    //        strike[0].SetActive(true);
                    //    }
                    //    else if (strike[0].activeSelf)
                    //    {
                    //        strike[1].SetActive(true);
                    //    }
                    //    else
                    //    {
                    //        fail.SetActive(true);
                    //    }
                    //}

                    // points--;
                    //if (Input.GetKeyDown(KeyCode.RightArrow))
                    //{
                    //    points++;
                    //}
                }
                if(fold[i].sequence[j].ToLower().Trim() == "up")
                {
                    Debug.Log("up");
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    mutex = true;
                    yield return new WaitForSeconds(0.8f);
                    fillbar.fillAmount -= 0.2f;
                    //yield return new WaitForSeconds(1.5f);
                    //yield return new WaitForSeconds(1.5f);

                    //if (failed)
                    //{
                    //    if (!strike[0].activeSelf)
                    //    {
                    //        strike[0].SetActive(true);
                    //    }
                    //    else if (strike[0].activeSelf)
                    //    {
                    //        strike[1].SetActive(true);
                    //    }
                    //    else
                    //    {
                    //        fail.SetActive(true);
                    //    }
                    //}
                    //points--;
                    //if (Input.GetKeyDown(KeyCode.UpArrow))
                    //{
                    //    points++;
                    //}
                }
                //yield return new WaitForSeconds(0.8f);
            }
            fold[i].crepe.SetActive(false);
        }
        if (!fail.activeInHierarchy)
        {
            success.SetActive(true);
            ScoreReport.passed[3] = true;
        }        
    }
}

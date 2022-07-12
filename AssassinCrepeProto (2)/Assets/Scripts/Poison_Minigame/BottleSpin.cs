using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpin : MonoBehaviour
{
    bool isMoving = false;
    bool theGameStopped = false;
    public GameObject win;
    public GameObject lose;
    int times = 0;

    public GameObject[] bottles;
    //public PoisonChecker check;

    public List<int> z = new List<int>();

    private float time = 5.0f;
    private float startTime;
    private float journeyLength;
    private float distCovered;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        
        //z.Add(0);
        //z.Add(1);
        //z.Add(2);
        //z.Add(3);
        //StartCoroutine(Stop());
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
        }
        else if(isMoving)
        {
            
            startTime = Time.time;

            gameObject.GetComponent<PoisonChecker>().particle.SetActive(false);
            StartCoroutine(Stop());
            //  StartCoroutine(Stop());


        }
        else if(theGameStopped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "PoisonUp")
                    {
                       
                        bool check = GameObject.Find("GameManager").GetComponent<PoisonChecker>().duds[0];
                        Debug.Log(check);
                        if (check)
                        {
                           
                            win.SetActive(true);
                            ScoreReport.pass = true;

                        }
                        else
                        {
                            lose.SetActive(true);
                            ScoreReport.pass = false;
                        }
                    }
                    else if (hit.transform.name == "PoisonDown")
                    {
                        bool check = GameObject.Find("GameManager").GetComponent<PoisonChecker>().duds[1];
                        Debug.Log(check);
                        if (check)
                        {
                            win.SetActive(true);
                            ScoreReport.pass = true;

                        }
                        else
                        {
                            lose.SetActive(true);
                            ScoreReport.pass = false;
                        }
                    }
                    else if (hit.transform.name == "PoisonLeft")
                    {
                        bool check = GameObject.Find("GameManager").GetComponent<PoisonChecker>().duds[2];
                        Debug.Log(check);
                        if (check)
                        {
                            win.SetActive(true);
                            ScoreReport.pass = true;
                        }
                        else
                        {
                            lose.SetActive(true);
                            ScoreReport.pass = false;
                        }
                    }
                    else if (hit.transform.name == "PoisonRight")
                    {
                        bool check = GameObject.Find("GameManager").GetComponent<PoisonChecker>().duds[3];
                        Debug.Log(check);
                        if (check)
                        {
                            win.SetActive(true);
                            ScoreReport.pass = true;

                        }
                        else
                        {
                            lose.SetActive(true);
                            ScoreReport.pass = false;
                        }
                    }
                }
            }
        }
    }

    IEnumerator Stop()
    {
        //yield return new WaitForSeconds(5f);
        // yield return new WaitForSeconds(5f);
        //isMoving = false;
        isMoving = false;

        for (int i = 0; i < 10; i++)
        {
            
            z.Add(0);
            z.Add(1);
            z.Add(2);
            z.Add(3);
            int c = Random.Range(0, z.Count);
            Debug.Log(z.Count);
            journeyLength = Vector3.Distance(bottles[0].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location);
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            bottles[0].transform.position = Vector3.Lerp(bottles[0].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location, fractionOfJourney);
            Debug.Log(c);
            //gameObject.GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            //check.bottleList.RemoveAt(c);
            z.RemoveAt(c);

            c = Random.Range(0, z.Count);
            journeyLength = Vector3.Distance(bottles[1].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location);
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            bottles[1].transform.position = Vector3.Lerp(bottles[1].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location, fractionOfJourney);
            Debug.Log(c);
            //gameObject.GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(c);



            c = Random.Range(0, z.Count);
            journeyLength = Vector3.Distance(bottles[2].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location);
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            bottles[2].transform.position = Vector3.Lerp(bottles[2].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[c]].location, fractionOfJourney);
            Debug.Log(c);
            // gameObject.GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            // GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(c);



            c = z[0];
            journeyLength = Vector3.Distance(bottles[3].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[0]].location);
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            bottles[3].transform.position = Vector3.Lerp(bottles[3].transform.position, gameObject.GetComponent<PoisonChecker>().bottleList[z[0]].location, fractionOfJourney);
            //GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            Debug.Log(z.Count);
            Debug.Log(c);
            // gameObject.GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(0);
            yield return new WaitForSeconds(0.5f);
            times++;
            
            Debug.Log(times);
            //z = Random.Range(0, GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.Count);
            // transform.position = startPos;
            //yield return new WaitForSeconds(5f);
            
            //isMoving = false;
        }
        theGameStopped = true;

    }
}

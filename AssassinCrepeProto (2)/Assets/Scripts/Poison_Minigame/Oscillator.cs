using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public static bool isMoving;
    bool theGameStopped = false;
    public GameObject win;
    public GameObject lose;

    float timeCounter = 0;
    Vector3 startPos;
    [SerializeField]
    private float speed, width, height;

    float time = 5.0f;
    // Start is called before the first frame update
    void Start()
    {


        startPos = transform.position;
        //StartCoroutine(Stop());
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;

        }
        else if (isMoving)
        {
            GameObject.Find("GameManager").GetComponent<PoisonChecker>().particle.SetActive(false);
            StartCoroutine(Stop());
            if (gameObject.tag == "Oscillator")
            {
                timeCounter += Time.deltaTime * speed;
                float x = startPos.x + Mathf.Sin(timeCounter) * height;
                float y = startPos.y;
                float z = startPos.z + Mathf.Cos(timeCounter) * height;


                transform.position = new Vector3(x, y, z);
            }
            if (gameObject.tag == "OscillatorReverse")
            {
                timeCounter += Time.deltaTime * speed;
                float x = startPos.x - Mathf.Sin(timeCounter) * height;
                float y = startPos.y;
                float z = startPos.z - Mathf.Cos(timeCounter) * height;


                transform.position = new Vector3(x, y, z);
            }
            if (gameObject.tag == "OscillatorLeft")
            {
                timeCounter += Time.deltaTime * speed;
                float x = startPos.x + Mathf.Sin(timeCounter) * height;
                float y = startPos.y;
                float z = startPos.z - Mathf.Cos(timeCounter) * height;


                transform.position = new Vector3(x, y, z);
            }
            if (gameObject.tag == "OscillatorRight")
            {
                timeCounter += Time.deltaTime * speed;
                float x = startPos.x - Mathf.Sin(timeCounter) * height;
                float y = startPos.y;
                float z = startPos.z + Mathf.Cos(timeCounter) * height;


                transform.position = new Vector3(x, y, z);
            }
        }
        else
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
        
        yield return new WaitForSeconds(5f);
        isMoving = false;
        if(!theGameStopped)
        {
            PoisonSwitch();
        }
        
        
       
    }
    
    void PoisonSwitch()
    {
        List<int> z = new List<int>();
        z.Add(0);
        z.Add(1);
        z.Add(2);
        z.Add(3);
        if (gameObject.tag == "Oscillator")
        {
            int c = Random.Range(0, z.Count);
            transform.position = GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList[c].location;
            Debug.Log(c);
            GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(c);
        }
        if (gameObject.tag == "OscillatorReverse")
        {
            int c = Random.Range(0, z.Count-1);
            transform.position = GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList[c].location;
            Debug.Log(c);
            GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(c);

        }
        if (gameObject.tag == "OscillatorLeft")
        {
            int c = Random.Range(0, z.Count-2);
            transform.position = GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList[c].location;
            Debug.Log(c);
            GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            z.RemoveAt(c);
        }
        if (gameObject.tag == "OscillatorRight")
        {
            int c = z[0];
            transform.position = GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList[c].location;
            GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.RemoveAt(c);
            Debug.Log(c);
            //z = Random.Range(0, GameObject.Find("GameManager").GetComponent<PoisonChecker>().bottleList.Count);
            // transform.position = startPos;
        }
        theGameStopped = true;
    }
}
        


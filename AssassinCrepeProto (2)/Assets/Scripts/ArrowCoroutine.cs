using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCoroutine : MonoBehaviour
{
    public GameObject Phase1;
    public GameObject Phase2;
    public GameObject Phase3;
    public GameObject Phase4;
    void Start()
    {
        StartCoroutine(Button());
    }

    IEnumerator Button()
    {
       
        yield return new WaitForSecondsRealtime(2);

        Phase1.SetActive(false);
        Phase2.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        Phase2.SetActive(false);
        Phase3.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        Phase3.SetActive(false);
        Phase4.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        Phase4.SetActive(true);

    }
}
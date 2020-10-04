using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{

    public GameObject scene;
    public GameObject ui;

    public void Activate()
    {
        scene.SetActive(true);
        ui.SetActive(false);
    }
}

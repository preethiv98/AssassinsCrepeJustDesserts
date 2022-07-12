using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimationComplete : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject otherUI;
    [SerializeField] private GameObject currentUI;
    

    void SetAndHide()
    {
        currentUI.SetActive(false);
        otherUI.SetActive(true);
    }
}

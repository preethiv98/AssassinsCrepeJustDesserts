using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CreditsVisibility : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Menu;
    public bool Visible;

    public void ChangeCreditsVisibility()
    {
        Credits.SetActive(Visible);
        Menu.SetActive(!Visible);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Invoke("MainMenu", 4f);
    }
     

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}

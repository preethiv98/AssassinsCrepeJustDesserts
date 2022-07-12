using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerLevel2 : MonoBehaviour
{
    public Button LevelTwo;
    public Button widow;
    ColorBlock colors;
    // Start is called before the first frame update
    void Awake()
    {
        if(ScoreReport.toLevelTwo)
        {
            widow.GetComponent<Image>().color = Color.white;
            LevelTwo.GetComponent<Image>().color = Color.white;
            colors = LevelTwo.colors;
            colors.normalColor = Color.white;
            LevelTwo.colors = colors;
            Button btn = LevelTwo.GetComponent<Button>();
            Button btnw = widow.GetComponent<Button>();
            btn.onClick.AddListener(LoadLevel);
            btnw.onClick.AddListener(LoadLevel);
        }
       
      
    }

    // Update is called once per frame
    void LoadLevel()
    {
        SceneManager.LoadScene(13);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFill : MonoBehaviour
{
    // Start is called before the first frame update
    public Image myImage;
    public GameObject egg;
   // public GameObject fail;
   // public GameObject egg;
    public float speed = 2.0f;
    public float waitTime = 5.0f;
    public bool repeat;
    public Vector3 touchPos;
    IEnumerator Start()
    {
        while(repeat)
        {
            //Do something
            yield return ChangeFill(0, 1.0f, waitTime);
            yield return ChangeFill(1.0f, 0.0f, waitTime);
        }
    }

    public IEnumerator ChangeFill(float start, float end, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i<1.0f)
        {
            i += Time.deltaTime * rate;
            myImage.fillAmount = Mathf.Lerp(start, end, i);
            yield return null;
        }
    }

  

}

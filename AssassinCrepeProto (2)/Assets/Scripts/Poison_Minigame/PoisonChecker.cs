using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonChecker : MonoBehaviour
{
    //Create list of type DudList that takes in a GameObject bottle
    //and a bool isPoison that checks if the bottle is the real poison bottle
    public GameObject particle;
    public List<DudList> bottleList;
    public List<bool> duds;
    public Material poison;
   // public List<GameObject> bottles;

    [System.Serializable]
    public class DudList
    { 
       public GameObject bottle;
        public bool isPoison = false;
        public Vector3 location;
      

    }

    void Start()
    {

        int c = Random.Range(0, bottleList.Count);
        //Transform trans = bottleList[c].location;

        for (int i = 0; i < bottleList.Count; i++)
        {
            // bottles[i] = bottleList[i].bottle;
           
            duds[i] = bottleList[i].isPoison;
            bottleList[i].location = new Vector3(bottleList[i].bottle.transform.position.x, bottleList[i].bottle.transform.position.y + 3, bottleList[i].bottle.transform.position.z);

        }
        bottleList[c].bottle.GetComponent<MeshRenderer>().material = poison;
        bottleList[c].isPoison = true;
        duds[c] = true;
        particle.transform.position = bottleList[c].location;
    }



   
}

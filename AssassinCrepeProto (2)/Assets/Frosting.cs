using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frosting : MonoBehaviour
{
    public class Cake //Cake classes to keep track of what colliders have been clicked
    {
        public Cake() { }
        public GameObject CakePiece;
        public bool isFrosted;
    }

    List<Cake> cake = new List<Cake>(); //List that holds all cake objects
    public static bool success = false; //Success state of the game
    public static int totalPieces; //Note: There should be 30 total pieces
    public static int totalFrostedPieces; //Increments when collider is clicked
   
    

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))) //Fills the list with all the colliders related to the cake
        {
            if (obj.tag == "Cake_Frosting") {
               // Debug.Log(obj.name);
                Cake slice = new Cake();
                slice.CakePiece = obj;
                slice.isFrosted = false;
                cake.Add(slice);
            }

        }
        totalPieces = cake.Count;
        totalFrostedPieces = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(totalPieces);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {    
                    for(int i = 0; i < cake.Count; i++)
                    {
                        if (cake[i].CakePiece.name == hit.transform.name && cake[i].isFrosted != true) 
                        {
                            //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                          
            
                            cake[i].isFrosted = true; 
                            totalFrostedPieces++;
                           
                            SpriteRenderer renderer = cake[i].CakePiece.GetComponent<SpriteRenderer>();
                            BoxCollider collide = cake[i].CakePiece.GetComponent<BoxCollider>();
                        
                            renderer.enabled = true; //Reveals the sprite on click
                            renderer.size = collide.size; //Resizes sprite to be same size as collider
                            renderer.transform.position = collide.transform.position; //Makes sprite load on same position as collider
                            break;
                        }
                    }
            }
        }


      
            if (totalFrostedPieces >= 24) //About half the pieces. Subject  to change later
            {
                success = true;
                //Debug.Log("You Won!!!");
            }
            else
            { 
                success = false;
                //Debug.Log("You had one job");
            }
     
    }

 
}

 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightfightanim : MonoBehaviour
{
    
    public GameObject Knight;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("y")){
                Knight.GetComponent<Animator>().Play("death");
        }
        if(Input.GetButton("h")){
                Knight.GetComponent<Animator>().Play("attack");
        }
        if(Input.GetButton("b")){
                Knight.GetComponent<Animator>().Play("block");
        }
        
    }
}

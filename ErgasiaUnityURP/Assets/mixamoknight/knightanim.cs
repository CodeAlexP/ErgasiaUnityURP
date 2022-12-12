using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightanim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject knight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("y")){
            knight.GetComponent<Animator>().Play("attack");

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;
    public GameObject d_template;
    public GameObject canva;
    private static string myTag;

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F))
        {
            //myTag = gameObject.tag;
            if (myTag == "FemaleA")
            {
                NewDialogue("Tonight we will fight the Skeletons..");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleB")
            {
                NewDialogue("I'm the Mayor of this village!");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleC")
            {
                NewDialogue("Im the Mayor's daughter..");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleD")
            {
                NewDialogue("This lake is f.. beautiful!");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleE")
            {
                NewDialogue("Welcome traveller to a new experience!");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "MaleA")
            {
                NewDialogue("I'm growing tomatoes here");
                canva.transform.GetChild(5).gameObject.SetActive(true);

            }
            else if (myTag == "MaleB")
            {
                NewDialogue("My tomatoes are better than the next one");
                canva.transform.GetChild(5).gameObject.SetActive(true);

            }
            else if (myTag == "MaleC")
            {
                NewDialogue("This is my doss-house");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "MaleD")
            {
                NewDialogue("We have a small community because the skeletons keep killing our tribe!");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (myTag == "Hiero")
            {
                NewDialogue("Rumours say that 'There is a Huge Aggresive Skeleton' inside a volcano near this area");
                canva.transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        Destroy(template_clone, 3f);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }


    private void OnTriggerEnter(Collider other)
    {
        myTag = gameObject.tag;    
        if (other.name == "PlayerArmature")
        {
            player_detection = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canva.transform.childCount >= 6) // check if child exists before accessing it
        {
            canva.transform.GetChild(5).gameObject.SetActive(false);
        }
        player_detection = false;
 
    }
}



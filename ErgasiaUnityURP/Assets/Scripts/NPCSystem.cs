using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;
    public GameObject d_template;
    public GameObject canva;
    public TextMeshProUGUI textInteract;
    private static string myTag;
    // Update is called once per frame

    void Start()
    {

    }


    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F))
        {
             textInteract.enabled=false;

            //myTag = gameObject.tag;
            if (myTag == "FemaleA")
            {
                NewDialogue("Tonight we will fight the Skeletons..");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleB")
            {
                NewDialogue("I'm the Mayor of this village!");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleC")
            {
                NewDialogue("Im the Mayor's daughter..");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleD")
            {
                NewDialogue("This lake is f.. beautiful!");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "FemaleE")
            {
                NewDialogue("Welcome traveller to a new experience!");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "MaleA")
            {
                NewDialogue("I'm growing tomatoes here");
                canva.transform.GetChild(8).gameObject.SetActive(true);

            }
            else if (myTag == "MaleB")
            {
                NewDialogue("My tomatoes are better than the next one");
                canva.transform.GetChild(8).gameObject.SetActive(true);

            }
            else if (myTag == "MaleC")
            {
                NewDialogue("This is my doss-house");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "MaleD")
            {
                NewDialogue("We have a small community because the skeletons keep killing our tribe!");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if (myTag == "Hiero")
            {
                NewDialogue("Rumours say that 'There is a Huge Aggresive Skeleton' inside a volcano near this area");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }
            else if(myTag=="PlagueDoctor")
            {
                NewDialogue("We have a lot of injured people from the last invasion of the skeletons!");
                canva.transform.GetChild(8).gameObject.SetActive(true);
            }

            if (GetComponentInParent<AgentPatrol>() != null)
            {
                this.GetComponentInParent<AgentPatrol>().enabled = false;
            }
            if (GetComponentInParent<NavMeshAgent>() != null)
            {
                this.GetComponentInParent<NavMeshAgent>().enabled= false;
            }
            this.GetComponentInParent<Animator>().Play("Idle Walk Run Blend");
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
            textInteract.enabled=true;
            textInteract.text=" Press F ";
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (canva.transform.childCount >= 7) // check if child exists before accessing it
        {
            canva.transform.GetChild(6).gameObject.SetActive(false);
        }
        player_detection = false;
        textInteract.enabled = false;
        if (GetComponentInParent<NavMeshAgent>() != null)
        {
            GetComponentInParent<NavMeshAgent>().enabled = true;
        }
        // If the NPC has the AgentPatrol script, re-enable it when the player exits the interaction range
        if (GetComponentInParent<AgentPatrol>() != null)
        {
            this.GetComponentInParent<AgentPatrol>().enabled = true;
        }

    }


}




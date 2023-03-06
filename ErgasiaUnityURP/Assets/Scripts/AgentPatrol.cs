using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AgentPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] private Transform[] points;
    int pointIndex;
    bool walking = false;
    bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        

        pointIndex = -1;
        walking = false;
       // animator.SetBool("Walking", false);
        StartCoroutine(NextPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !waiting && !agent.pathPending)
        {
             
            StartCoroutine(NextPoint());
        }
    }

    IEnumerator NextPoint()
    {
          GetComponent<Animator>().enabled=false;

        float randomSeconds = Random.Range(1, 4);
        yield return new WaitForSeconds(randomSeconds);

        pointIndex = (pointIndex + 1) % points.Length;
        agent.SetDestination(points[pointIndex].position);

      
        GetComponent<Animator>().enabled=true;
         GetComponent<Animator>().Play("Walking");

        yield return null;
    }
}




 
               

    
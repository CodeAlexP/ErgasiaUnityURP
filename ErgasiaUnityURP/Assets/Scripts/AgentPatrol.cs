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
    
    bool waiting = false;

    // Start is called before the first frame update
   // Start is called before the first frame update.
void Start()
{
    agent = GetComponent<NavMeshAgent>(); // Get a reference to the NavMeshAgent component.
    animator = GetComponent<Animator>(); // Get a reference to the Animator component.

    pointIndex = -1; // Initialize the patrol point index to -1.
  

    StartCoroutine(NextPoint()); // Start the patrol coroutine.
}

// Update is called once per frame.
void Update()
{
    // Check if the agent has reached the current patrol point and is not waiting or has no more path to follow.
    if (agent.remainingDistance <= agent.stoppingDistance && !waiting && !agent.pathPending)
    {
        StartCoroutine(NextPoint()); // Start the coroutine to go to the next patrol point.
    }
}

// Coroutine to move the agent to the next patrol point.
IEnumerator NextPoint()
{
    animator.Play("Idle Walk Run Blend"); // Play the animation for the idle to walk transition.

    float randomSeconds = Random.Range(1, 4); // Generate a random wait time between 1 and 4 seconds.
    yield return new WaitForSeconds(randomSeconds); // Wait for the random time.

    pointIndex = (pointIndex + 1) % points.Length; // Increment the patrol point index to the next point.
    agent.SetDestination(points[pointIndex].position); // Set the agent's destination to the next patrol point.

    animator.Play("Walking"); // Play the animation for walking.

    yield return null; // Return null to exit the coroutine.
}
}




 
               

    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    
    public GameObject Hero;

    public float lookRadius = 10f;
    public Slider enemyslider;
    Transform target;
    NavMeshAgent agent;
    private HealthBarScript healthBar;
    private bool dead;
     private float attackTimer = 0f;
    private float attackDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        dead=false;
         healthBar = GetComponent<HealthBarScript>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
         GetComponent<Animator>().Play("Walking");

    }
     private void OnTriggerStay(Collider other)
    {
        if (!dead && other.tag == "Player")
        {
            // Check if enough time has passed since last attack
            if (Time.time > attackTimer + attackDelay)
            {
                attackTimer = Time.time;
                for (int i = 0; i <= 2; i++)
                {
                    Hero.GetComponent<Player>().TakeDamage(2);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(!dead){

        
        if(other.tag=="Player"){


        
             GetComponent<Animator>().Play("EnemyAttack1");
                 for(int i=0;i<=2;i++){
                 Hero.GetComponent<Player>().TakeDamage(2);
        }
       
        }
        }
    }
    

    private void OnTriggerExit(Collider other) {
         if(!dead){
         if(other.tag=="Player"){

             GetComponent<Animator>().Play("Walking");
        }
         }
    }

    // Update is called once per frame
    public virtual void Die(){

          
		  GetComponent<Animator>().Play("Die");
          GetComponent<EnemyController>().enabled=false;
		  GetComponent<NavMeshAgent>().enabled=false;
          enemyslider.gameObject.SetActive(false);
          dead=true;
          
        
        
          


	
	}

    void Update()
    {
     

        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
               
                FaceTarget();
                 if (Input.GetMouseButtonDown(0)){
                enemyslider.value=enemyslider.value-20;
             }
            }
        }
        if(enemyslider.value==0){
        Die();

     }
    }

    void FaceTarget()
    {
        
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

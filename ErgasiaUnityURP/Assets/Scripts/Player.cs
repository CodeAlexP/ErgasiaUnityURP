using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using StarterAssets;
public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public GameObject HealthbarCANVA;
	public GameObject MINIMAPCANVA;
	public GameObject GAMEOVERCANVA;
	
   
	public HealthBarScript healthBar;



	

	// Start is called before the first frame update
	void Start()
	{
		
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
		  if (Input.GetMouseButtonDown(0))
        {
			int randomIndex = Random.Range(0, 3);
			if(randomIndex==0){
            GetComponent<Animator>().Play("MaleAttack1");

			}else if (randomIndex==1){
            GetComponent<Animator>().Play("MaleAttack2");

			}else{

            GetComponent<Animator>().Play("MaleAttack3");

			}
        }
		if(Input.GetKeyDown(KeyCode.C)){
            GetComponent<Animator>().Play("Roll");

		}
		
	}

	void TakeDamage(int damage)
	{

		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if(currentHealth==0){
          
		  Die();

		}
	}
	public virtual void Die(){


		  GetComponent<Animator>().Play("Die");
		  gameObject.GetComponent<ThirdPersonController>().enabled=false;
          HealthbarCANVA.SetActive(false);
		  MINIMAPCANVA.SetActive(false);
		  GAMEOVERCANVA.SetActive(true);
		  StartCoroutine(ExecuteAfterTenSeconds());
	
	}
		   private IEnumerator ExecuteAfterTenSeconds()
    {
        yield return new WaitForSeconds(10f);
     	 int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

	public void SavePlayer() {
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer() {
		PlayerData data = SaveSystem.LoadPlayer();

		currentHealth = data.health;

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];

		transform.position = position;
	}
	
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public HealthBarScript healthBar;
	public GameObject playerArmature;

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
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
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

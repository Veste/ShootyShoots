using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// The speed of the ship
	public Vector2 speed = new Vector2(50, 50);

	// Keep track of movement
	private Vector2 movement;

	// Update is called once per frame
	void Update () {
		// Retrieve input via axis
		float inputX = Input.GetAxis ("Horizontal"),
			  inputY = Input.GetAxis ("Vertical");

		// Set movement
		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY
		);

		// --- Shooting
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null) {
				weapon.Attack (false);
			}
		}
	}

	void FixedUpdate() {
		// Assign movement to the velocity of the player's rigidbody
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		bool damage_player = false;

		// Collision with enemy?
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript> ();
		if (enemy != null) {
			// Damage the enemy
			HealthScript enemy_health = enemy.GetComponent<HealthScript>();
			if (enemy_health != null) {
				// The enemy is dead
				enemy_health.Damage(enemy_health.hp);
				damage_player = true;
			}
		}

		if (damage_player) {
			HealthScript player_health = this.GetComponent<HealthScript>();
			if (player_health != null) {
				player_health.Damage(1);
			}
		}
	}
}

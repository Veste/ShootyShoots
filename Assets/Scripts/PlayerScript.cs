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
}

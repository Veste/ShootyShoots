using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// The speed of the object
	public Vector2 speed = new Vector2 (50, 50);

	// The direction that the object is moving in
	public Vector2 direction = new Vector2 (-1, 0);

	// Keep track of movement
	private Vector2 movement;
	
	// Update is called once per frame
	void Update () {
		
		// Set movement
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y
			);
	}
	
	void FixedUpdate() {
		// Assign movement to the velocity of the player's rigidbody
		rigidbody2D.velocity = movement;
	}
}

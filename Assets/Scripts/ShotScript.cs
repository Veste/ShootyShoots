using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	// Amount of damage dealt
	public int damage = 1;

	// Does the shot originate from an enemy or the player?
	public bool isEnemyShot = false;

	void Start() {
		// Destroy the game object after 20 seconds
		Destroy (gameObject, 20);
	}
}

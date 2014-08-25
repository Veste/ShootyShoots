using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;

	public bool isEnemy = true;

	public void Damage(int damage_amount) {
		hp -= damage_amount;
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		// Is this a shot? If so, grab the shot script component
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();

		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage);
				Destroy(shot.gameObject);
			}
		}
	}
}

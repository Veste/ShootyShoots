using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	// The projectile's prefab.
	public Transform shotPrefab;

	// Cooldown between shots (in seconds)
	public float fireRate = 0.25f;

	private float shotCooldown;

	void Start() {
		shotCooldown = 0f;
	}

	void Update() {
		if (shotCooldown > 0) {
			shotCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shotCooldown = fireRate;
		
			var shotTransform = Instantiate(shotPrefab) as Transform;

			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}

			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				move.direction = this.transform.right;
			}
		}
	}

	public bool CanAttack {
		get { return shotCooldown <= 0f; }
	}
}

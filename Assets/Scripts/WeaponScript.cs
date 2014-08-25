using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	// The projectile's prefab.
	public Transform shotPrefab;

	// Cooldown between shots (in seconds)
	public float fireRate = 0.25f;

	private float shotCooldown;
	private Vector2 random_shot_speed = Vector2.zero;

	void Start() {
		shotCooldown = Random.Range (0f, fireRate);
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
				if (isEnemy) {
					if (random_shot_speed == Vector2.zero) {
						random_shot_speed = new Vector2(Random.Range (10, move.speed.x + 1),
						                                Random.Range (10, move.speed.y + 1));
					}
					move.speed = random_shot_speed;
				}
			}
		}
	}

	public bool CanAttack {
		get { return shotCooldown <= 0f; }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("Enemy")]
    [SerializeField] float health = 100;
    [Header("Projectile")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [Header("Death")]
    [SerializeField] GameObject explosionEffectPrefab;
    [SerializeField] float durationOfExplosion = 1f;

	// Use this for initialization
	void Start () {
        resetShotCounter();
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();
	}

    private void resetShotCounter() {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime; // Subtract how long the frame takes.
        if (shotCounter <= 0) {
            Fire();
            resetShotCounter();
        }
    }

    private void Fire() {
        CreateLaser();
    }

    private void CreateLaser()
    {
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity
        ) as GameObject;
        // Negative projectile speed allows for it to shoot down.
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            damageDealer.Hit();
            Destroy(gameObject);
            ExplodingVisualEffect();
        }
    }

    private void ExplodingVisualEffect() 
    {
        GameObject explosion = Instantiate(
            explosionEffectPrefab,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        Object.Destroy(explosion, durationOfExplosion);
    }
}

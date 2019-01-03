using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damage = 100;


	// Use this for initialization
	void Start () {
		
	}

    public int GetDamage() {
        return damage;
    }
	
	// Update is called once per frame
	public void Hit () {
        Destroy(gameObject);
	}
}

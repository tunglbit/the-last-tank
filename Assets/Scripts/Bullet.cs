using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("EnemyBullet") || col.gameObject.tag.Equals("Bullet")) {
			Destroy(col.gameObject);
		}
		
		// var hit = col.gameObject;
		// var health = hit.GetComponent<Health> ();

		// if (health != null) {
		// 	health.TakeDamage (1);
		// }
		// Destroy (gameObject);
	}
}

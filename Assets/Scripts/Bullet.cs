using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("EnemyBullet") || col.gameObject.tag.Equals("Bullet") || col.gameObject.tag.Equals("BossBullet")) {
			Destroy(col.gameObject);
		}
	}
}

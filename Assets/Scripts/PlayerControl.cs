using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	float speed = 3f;
	public GameObject bulletPrefab;
	public Transform firePoint;
	Rigidbody2D rb2D;
	public AudioSource shootingAudio;
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.rotation = Quaternion.Euler (0, 0, -90);
			transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			transform.rotation = Quaternion.Euler (0, 0, 90);
			transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		}
		else if(Input.GetKey(KeyCode.UpArrow)){
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			transform.rotation = Quaternion.Euler (0, 0, -180);
			transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
		}

		// float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
		// float y = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

		// transform.Rotate (0, 0, -x);
		// transform.Translate (0, y, 0);

		if(Input.GetKeyDown(KeyCode.Space)) {
			Fire();
		}
	}

	public void Fire(){
		GameObject bulletIns = Instantiate (bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		shootingAudio.Play();
		bulletIns.GetComponent<Rigidbody2D> ().velocity = bulletIns.transform.up * 10;
		Destroy (bulletIns, 3);
	}
}

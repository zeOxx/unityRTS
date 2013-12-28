using UnityEngine;
using System.Collections;

public class TurretAim : MonoBehaviour {
	private Rigidbody rocket = null;
	private float lastShot = 0.0f;
	private float timer = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject obj = GameObject.Find("Airship");
		if (obj) {
			Vector3 enemyPos = obj.transform.position;
			Vector3 turretPos = gameObject.transform.position;

			if (Vector3.Distance (enemyPos, turretPos) < 10) {
				gameObject.transform.LookAt(enemyPos);
				if (lastShot < (Time.realtimeSinceStartup - timer)) {
					gameObject.GetComponentInChildren<TurretMuzzle> ().Fire ();
					lastShot = Time.realtimeSinceStartup;
				}
			}
		}
	}
}

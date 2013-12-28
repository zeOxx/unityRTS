using UnityEngine;
using System.Collections;

public class TurretMuzzle : MonoBehaviour {
	public Rigidbody rocket;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Fire () {
		Rigidbody clone;
		clone = Instantiate (rocket, transform.position, transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection(Vector3.forward * 20);
	}
}

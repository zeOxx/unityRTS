using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public float damage = 0;
	// Use this for initialization
	void Start () {
		damage = 10;
		Destroy(gameObject, 4);
	}

	public float Damage {
		get { return damage; }
		set { damage = value; }
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		//Debug.Log (collision.gameObject.GetComponent());
		if (collision.gameObject.GetComponent<Airship>()) {
				Destroy (gameObject, 0);
		}
	}
}

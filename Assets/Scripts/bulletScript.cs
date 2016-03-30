using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public float speed = 20.0f;
	// Use this for initialization
	void Start () {
		var r2d = GetComponent<Rigidbody2D> ();

		// Get the vector in the direction of the ship and muliply it by the scalar speed
		// to get the new velocity vector
		var velocity = r2d.transform.right * speed;
		r2d.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}

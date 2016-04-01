using UnityEngine;
using System.Collections;

public class SeekerScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var r2d = GetComponent<Rigidbody2D> (); // Get the enemy ship (self)
		var ship = GameObject.Find ("Player").transform.position; // Get the player ship

		r2d.velocity += (Vector2)(ship - r2d.transform.position);
		r2d.velocity *= 0.7f; // Scale down velocity vector to slow enemy down

		if (r2d.velocity != Vector2.zero)
			r2d.MoveRotation((Mathf.Atan(r2d.velocity.y / r2d.velocity.x) * Mathf.Rad2Deg) + 90.0f); 


		// Keep object within screen bounds
		r2d.position = new Vector2
			(
				Mathf.Clamp (r2d.position.x, -8.5f, 8.5f), 
				Mathf.Clamp (r2d.position.y, -4.5f, 4.5f)
			);
		// end bounds clanp
		
	}
		
	// When a collision happens
	void OnTriggerEnter2D(Collider2D collision) {
		var name = collision.gameObject.name;
		if (name == "Bullet(Clone)") {
			Destroy (gameObject);
			Destroy (collision.gameObject);
		}
	}
}

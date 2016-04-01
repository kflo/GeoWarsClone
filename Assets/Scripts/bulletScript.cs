using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public float speed = 20.0f;
	// Use this for initialization
	void Start () {
		var r2d = GetComponent<Rigidbody2D> ();
		var velocity = r2d.velocity;

		var xAxis = Input.GetAxisRaw ("RightAnalogHorizontal");
		var yAxis = Input.GetAxisRaw ("RightAnalogVertical");

		if (xAxis != 0.0f || yAxis != 0.0f) {
			var angle = (Mathf.Atan2 (-xAxis, yAxis) * Mathf.Rad2Deg) - 90.0f;
			velocity.x = -xAxis * speed;
			velocity.y = yAxis * speed;
			r2d.velocity = velocity;
			r2d.MoveRotation (-angle);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}

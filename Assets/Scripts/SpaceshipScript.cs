using UnityEngine;
using System.Collections;

public class SpaceshipScript : MonoBehaviour {
	private Rigidbody2D r2d;
	private float angle, speed;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		r2d = GetComponent<Rigidbody2D> ();
		angle = 0.0f;
		speed = 15.0f;
	}
	
	// Update is called once per frame
	void Update () {
		var v = r2d.velocity;
		var xAxis = (Input.GetAxis ( "LeftAnalogHorizontal" ));
		var yAxis = Input.GetAxis ( "LeftAnalogVertical" );
		if (xAxis != 0.0f || yAxis != 0.0f)
			angle = (Mathf.Atan2 (-xAxis, yAxis) * Mathf.Rad2Deg) - 90.0f;
		r2d.MoveRotation ( -angle );
		v.x = -xAxis * speed;
		v.y = yAxis * speed;
		r2d.velocity = v;
		r2d.position = new Vector2
			(
				Mathf.Clamp (r2d.position.x, -8.5f, 8.5f), 
				Mathf.Clamp (r2d.position.y, -4.5f, 4.5f)
			);
		
		if (Input.GetButtonDown ("PS4_X")) {
			Instantiate (bullet, transform.position, transform.rotation);
		}
	}

} 
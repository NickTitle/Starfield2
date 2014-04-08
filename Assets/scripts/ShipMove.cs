using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {

	public Vector2 speed = new Vector2(2.0f,2.0f);

	private Vector2 touchDownPosition;
	private Vector2 currentMousePositon;
	private Vector2 previousPosition;
	private Vector2 currentPosition;
	private Vector2 currentSpeed;
	private Vector2 movement;
	private float shipAngle;
	private bool mouseClicked;

	// Use this for initialization
	void Start () {
		currentSpeed = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !mouseClicked) {
			touchDownPosition = Input.mousePosition;
			mouseClicked = true;
		}
		else if ((Input.GetAxis ("Mouse X")!= 0 || Input.GetAxis ("Mouse Y")!=0) && mouseClicked) {

			currentMousePositon = Input.mousePosition;
			float xMotion = (Input.mousePosition.x - touchDownPosition.x) * speed.x/1000;
			float yMotion = (Input.mousePosition.y - touchDownPosition.y) * speed.y/1000;

			xMotion = Mathf.Clamp(xMotion,-speed.x, speed.x);
			yMotion = Mathf.Clamp(yMotion,-speed.y, speed.y);

			movement = new Vector2(xMotion, yMotion);

		}
		if (Input.GetMouseButtonUp(0)) {
			mouseClicked = false;
		}
	}

	void FixedUpdate() {

		Vector2 oldCurrentSpeed = currentSpeed;

		if (mouseClicked) {
			currentSpeed = oldCurrentSpeed+movement;
		} else {
			currentSpeed = Vector2.Scale(currentSpeed, new Vector2(0.993f, 0.993f));
		}

		currentSpeed.x = Mathf.Clamp(currentSpeed.x, -speed.x, speed.x);
		currentSpeed.y = Mathf.Clamp (currentSpeed.y, -speed.y, speed.y);

		rigidbody2D.velocity = currentSpeed;

		Vector3 moveDirection = currentPosition - previousPosition; 
		if (moveDirection != Vector3.zero) 
		{
			shipAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(shipAngle, Vector3.forward);
		}

		float direction = ((shipAngle > 80 && shipAngle <= 180) || (shipAngle>= -180 && shipAngle <-80) ? -0.3f : 0.3f);
		Vector3 theScale = transform.localScale;
		theScale.y = direction;
		transform.localScale = theScale;

		previousPosition = currentPosition;
		currentPosition = rigidbody2D.transform.position;
	}
}

using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {

	public Vector2 speed = new Vector2(2.0f,2.0f);

	private Vector2 touchDownPosition;
	private Vector2 currentMousePositon;
	private Vector2 previousPosition;
	private Vector2 currentPosition;
	private Vector2 movement;
	private float shipAngle;
	private bool mouseClicked;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !mouseClicked) {
			touchDownPosition = Input.mousePosition;
			mouseClicked = true;
		}
		else if ((Input.GetAxis ("Mouse X")!= 0 || Input.GetAxis ("Mouse Y")!=0) && mouseClicked) {

			currentMousePositon = Input.mousePosition;
			float xMotion = (Input.mousePosition.x - touchDownPosition.x) * speed.x / (Screen.width/10);
			float yMotion = (Input.mousePosition.y - touchDownPosition.y) * speed.y / (Screen.height/10);

			movement = new Vector2(xMotion, yMotion);

		}
		if (Input.GetMouseButtonUp(0)) {
			mouseClicked = false;
		}
	}

	void FixedUpdate() {

		if (mouseClicked) {
			rigidbody2D.velocity = movement;
		} else {
			movement = movement*0.98f;
			rigidbody2D.velocity = movement;
		}

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

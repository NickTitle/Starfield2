using UnityEngine;
using System.Collections;

public class FollowTargetScript : MonoBehaviour {

	public Rigidbody2D targetBody;
	public Transform targetTransform;
	public float camFreedomAmount;
	public float originalHeight;
	public float extraZoomHeight;
	public float minSpeedThreshold;
	public float maxSpeedThreshold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (targetTransform) {
			float xDif = targetTransform.position.x - transform.position.x;
			float yDif = targetTransform.position.y - transform.position.y;

			float camX = transform.position.x;
			float camY = transform.position.y;
			float camZ = transform.position.z;
			if (Mathf.Abs(xDif) >= camFreedomAmount) {
				camX = targetTransform.position.x - camFreedomAmount*(xDif > 0 ? 1.0f :-1.0f);
			}
			if (Mathf.Abs(yDif) >= camFreedomAmount) {
				camY = targetTransform.position.y - camFreedomAmount*(yDif > 0 ? 1.0f :-1.0f);
			}

			if (targetBody && targetBody.velocity.magnitude > minSpeedThreshold) {
				camZ = originalHeight + extraZoomHeight * ((targetBody.velocity.magnitude-minSpeedThreshold)/maxSpeedThreshold);
			}

			transform.position = new Vector3(camX, camY, camZ);
		}

	}
}

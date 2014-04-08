using UnityEngine;
using System.Collections;

public class SlowRotateDrift : MonoBehaviour {

	private float currentRotation;
	private float spinAmount;
	// Use this for initialization
	void Start () {
		spinAmount = (float)Random.Range(-1000f, 1000f)/20000.0f;
		currentRotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentRotation = (currentRotation+spinAmount)%360;
		transform.rotation = Quaternion.AngleAxis(currentRotation, Vector3.forward);
	}
}

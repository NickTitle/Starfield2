using UnityEngine;
using System.Collections;

public class ShipBasedParticleSpeed : MonoBehaviour {

	public Rigidbody2D target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.startSpeed = target.velocity.magnitude > 5 ? 5.0f : Mathf.Max(target.velocity.magnitude,0.5f);
	}
}

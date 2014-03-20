using UnityEngine;
using System.Collections;

public class ParticleSortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "background";
		particleSystem.renderer.sortingOrder = 2;
	}
}

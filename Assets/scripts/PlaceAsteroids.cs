using UnityEngine;
using System.Collections;

public class PlaceAsteroids : MonoBehaviour {

	public ArrayList asteroidArray;

	// Use this for initialization
	void Start () {
		for (int i = 0; i< 50; i++) {
			GameObject asteroid = (GameObject)Instantiate(Resources.Load("Asteroid"));
			float randX = Random.Range (-100f, 100f);
			float randY = Random.Range (-100f, 100f);
			asteroid.transform.position = new Vector3(randX, randY, 0);
			asteroidArray.Add(asteroid);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

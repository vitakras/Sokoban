using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour {

	public bool isOccupied = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log(collider.name);
		this.isOccupied = true;
	}

	void OnTriggerExit2D(Collider2D collider) {
		this.isOccupied = false;
	}
}

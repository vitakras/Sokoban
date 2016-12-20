using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour {

	private Location [] locations;

	// Use this for initialization
	void Start () {
		locations = FindObjectsOfType<Location>();
	}

	public int Occupied() {
		int count = 0;

		foreach(Location location in this.locations){
			if (location.isOccupied){
				count++;
			}
		}

		return count;
	}

}

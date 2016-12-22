using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour
{

	private Location[] locations;
	private int occupiedCount;

	// Use this for initialization
	void Start ()
	{
		this.locations = FindObjectsOfType<Location> ();
		this.ResetCount ();
	}

	void OnEnable ()
	{
		EventManager eventManager = EventManager.intance;

		if (eventManager) {
			eventManager.RegisterAction ((int)EventType.LOCATION_OCCUPIED, this.UpdateOccupied);
		}
	}

	void OnDisable ()
	{
		EventManager eventManager = EventManager.intance;

		if (eventManager) {
			eventManager.DeRegisterAction ((int)EventType.LOCATION_OCCUPIED, this.UpdateOccupied);
		}
	}

	void ResetCount ()
	{
		this.occupiedCount = 0;
	}

	public void UpdateOccupied ()
	{
		int count = 0;

		foreach (Location location in this.locations) {
			if (location.IsOccupied) {
				count++;
			}
		}

		this.occupiedCount = count;

		if (this.OccupiedCount == this.Count) {
			this.AllLocationsOccupied ();
		}
	}

	public int Count {
		get {
			if (this.locations != null) {
				return this.locations.Length;
			} else {
				return 0;
			}
		}
	}

	public int OccupiedCount {
		get {
			return this.occupiedCount;
		}
	}

	private void AllLocationsOccupied ()
	{
		EventManager eventManager = EventManager.intance;

		if (eventManager) {
			eventManager.TriggerEvent ((int)EventType.ALL_LOCATIONS_OCCUPIED);
		}
	}
}

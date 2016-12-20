using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour
{

	public string ignoreTag = "Player";
	private bool isOccupied = false;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (!collider.CompareTag (this.ignoreTag)) {
			StartCoroutine (this.SetOccupied (collider));
		} else {
			Debug.Log (string.Format ("Ignoring GameObject with Tag {0}", this.ignoreTag));
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (!collider.CompareTag (this.ignoreTag)) {
			this.isOccupied = false;
			this.LocationUnOccupied ();
		} else {
			Debug.Log (string.Format ("Ignoring GameObject with Tag {0}", this.ignoreTag));
		}
	}

	public bool IsOccupied {
		get {
			return this.isOccupied;
		}
	}

	private IEnumerator SetOccupied (Collider2D collider)
	{
		Movable movable = collider.GetComponent<Movable> ();
		Vector2 myPosition = this.gameObject.transform.position;
		Vector2 movablePosition;

		if (movable != null) {
			while (movable.IsMoving ()) {
				movablePosition = collider.transform.position;
				if (myPosition.Equals (movablePosition)) {
					break;
				}

				yield return null;
			}

			movablePosition = collider.transform.position;
			if (myPosition.Equals (movablePosition)) {
				this.isOccupied = true;
				this.LocationOccupied ();
			}
		}
	}

	private void LocationOccupied ()
	{
		EventManager eventManager = EventManager.intance;
		if (eventManager) {
			eventManager.TriggerEvent ((int)EventType.LOCATION_OCCUPIED);
		}
	}

	private void LocationUnOccupied ()
	{
		EventManager eventManager = EventManager.intance;
		if (eventManager) {
			eventManager.TriggerEvent ((int)EventType.LOCATION_UNOCCUPIED);
		}
	}
}

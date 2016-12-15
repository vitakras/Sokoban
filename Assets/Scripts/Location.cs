using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour {

	public bool isOccupied = false;
	public string ignoreTag = "Player";

	void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.CompareTag(this.ignoreTag)) {
			StartCoroutine(this.SetOccupied(collider));
		} else {
			Debug.Log("Player Entered Location");
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (!collider.CompareTag(this.ignoreTag)) {
			this.isOccupied = false;
		} else {
			Debug.Log("Ingoring Player");
		}
	}

	public bool IsOccupied(){
		return this.isOccupied;
	}
		
	private IEnumerator SetOccupied(Collider2D collider) {
		Movable movable = collider.GetComponent<Movable>();
		Vector2 myPosition = this.gameObject.transform.position;
		Vector2 movablePosition;

		if (movable != null) {
			while(movable.IsMoving()) {
				movablePosition = collider.transform.position;
				if (myPosition.Equals(movablePosition)) {
					break;
				}

				yield return null;
			}

			movablePosition = collider.transform.position;
			if (myPosition.Equals(movablePosition)) {
				this.isOccupied = true;
			}
		}
	}
}

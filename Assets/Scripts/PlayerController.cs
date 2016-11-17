using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Movable))]
public class PlayerController : MonoBehaviour {

	// public
	public int distanceMoveBy = 1;

	// private
	private new Movable movable;

	// Use this for initialization
	void Awake () {
		this.movable = this.gameObject.GetComponent<Movable>();
	}
	
	// Update is called once per frame
	void Update () {
		this.Move();
	}

	/// <summary>
	/// Moves this instance based on Horizontal or Vertical.
	/// </summary>
	private void Move() {
		if (this.movable.IsMoving()) return ;
		float x = Input.GetAxis("Horizontal");

		if (x < 0) { // left
			this.movable.Move( -1 * this.distanceMoveBy, 0);
		} else if( x > 0) { // right
			this.movable.Move(this.distanceMoveBy, 0);
		} else {
			float y = Input.GetAxis("Vertical");
			if (y < 0) { // down
				this.movable.Move(0, -1 * this.distanceMoveBy);
			} else if (y > 0) { // up
				this.movable.Move(0, this.distanceMoveBy);
			}
		}
	}
}

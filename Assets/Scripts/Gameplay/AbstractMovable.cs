using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class AbstractMovable : MonoBehaviour, Movable {

	// Public Variables
	public float moveTime = 0.1f;
	public int collisionLayer = 1;

	// Private Variables
	private float inverseMoveTime;
	public bool isMoving = false;
	private new Collider2D collider;
	private int lastMoveX = 0;
	private int lastMoveY = 0;


	// Use this for initialization
	void Start () {
		this.inverseMoveTime = 1f / moveTime;
		this.isMoving = false;
		this.collider = GetComponent<Collider2D>();
		Debug.Log(this.collider);
	}

	public bool IsMoving() {
		return this.isMoving;
	}

	public bool Move(int xDir, int yDir) {
		this.lastMoveX = xDir;
		this.lastMoveY = yDir;

		Vector2 start = this.transform.position;
		Vector2 end = start + new Vector2(xDir, yDir);

		if (this.CanMove(start, end)) {
			Debug.Log(string.Format("Moving Object {0} to position {1}", this.name, end));
			StartCoroutine(this.SmoothMovement(end));
			return true;
		}

		Debug.Log(string.Format("Unable to Move Object: {0}", this.gameObject.name));
		return false;
	}

	protected bool CanMove(Vector2 start, Vector2 end) {
		this.collider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast(start, end, this.collisionLayer);
		this.collider.enabled = true;

		if (hit.transform != null) {
			Movable hitMovable = hit.transform.GetComponent<Movable>();

			if (hitMovable != null) {
				return hitMovable.Move(this.lastMoveX, this.lastMoveY);
			}
			return false;
		}

		return true;
	}

	private IEnumerator SmoothMovement(Vector3 end) {
		float sqrtRemainingDistance = (this.transform.position - end).sqrMagnitude;
		this.isMoving = true;

		// really small amount
		while (sqrtRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards(this.transform.position, end, this.inverseMoveTime * Time.deltaTime);
			this.transform.position = newPosition;
			sqrtRemainingDistance = (this.transform.position - end).sqrMagnitude;
			yield return null;
		}

		this.isMoving = false;
	}
}

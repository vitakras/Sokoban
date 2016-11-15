using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, Movable {

	public float moveTime = 0.1f;


	private float inverseMoveTime;
	public bool isMoving = false;

	// Use this for initialization
	void Start () {
		this.inverseMoveTime = 1f / moveTime;
		this.isMoving = false;
		Move(1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(!isMoving) {
			//Move(1,0);
		}
	}

	private IEnumerator SmoothMovement(Vector3 end) {
		float sqrtRemainingDistance = (this.transform.position - end).sqrMagnitude;
		isMoving = true;
		Debug.Log(sqrtRemainingDistance);
		// really small amount
		while (sqrtRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards(this.transform.position, end, 1f * Time.deltaTime);
			this.transform.position = newPosition;
			sqrtRemainingDistance = (this.transform.position - end).sqrMagnitude;
			yield return null;
			//Debug.Log(sqrtRemainingDistance);
		}
		Debug.Log("here");
		//isMoving = false;
	}
		
	public bool Move(int xDir, int yDir) {
		Vector3 end = this.transform.position + new Vector3(xDir, yDir, 0);
		Debug.Log(end);
		IEnumerator coroutine = SmoothMovement(end);

		StartCoroutine(coroutine);

		return true;
	}
}

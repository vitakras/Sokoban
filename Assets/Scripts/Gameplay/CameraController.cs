using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	private GameObject player;
	private Vector3 offset;
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (this.player) {
			this.transform.position = player.transform.position + offset;
		}
	}

	public void Init ()
	{
		this.player = GameObject.FindGameObjectWithTag ("Player");
		if (this.player) {
			this.offset = new Vector3(0,0, this.transform.position.z - player.transform.position.z);
		}
	}

}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public TextAsset filename;
	private BoardManager boardManager;
	public CameraController cameraController;

	// Use this for initialization
	void Start ()
	{
		this.boardManager = GetComponent<BoardManager> ();
		this.boardManager.SetupScene (filename);
		cameraController.Init();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public TextAsset filename;
	private BoardManager boardManager;

	// Use this for initialization
	void Start ()
	{
		this.boardManager = GetComponent<BoardManager> ();
		this.boardManager.SetupScene (filename);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

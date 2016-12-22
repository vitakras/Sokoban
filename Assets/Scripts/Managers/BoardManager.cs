using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{

	public GameObject player;
	public GameObject wall;
	public GameObject ground;
	public GameObject location;
	public GameObject crate;

	private Transform boardHolder;
	private int rows;
	private int columns;

	void BoadSetup (TextAsset textAsset)
	{
		this.boardHolder = new GameObject ("Board").transform;

		LevelReader levelReader = new LevelReader ();
		TileType[][] grid = levelReader.Load (textAsset);

		this.rows = grid.Length;
		this.columns = grid [0].Length;

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = ObjectToInstantiate (grid [y] [x]);

				GameObject background = Instantiate (this.ground, new Vector3 (x, y, 1f), Quaternion.identity) as GameObject;
				background.transform.SetParent (this.boardHolder);

				if (toInstantiate != null) {
					//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

					//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
					instance.transform.SetParent (boardHolder);
				}
			}
		}

	}

	GameObject ObjectToInstantiate (TileType type)
	{
		GameObject gameObject = null;

		switch (type) {
		case TileType.CRATE:
			gameObject = this.crate;
			break;
		case TileType.LOCATION:
			gameObject = this.location;
			break;
		case TileType.PLAYER:
			gameObject = this.player;
			break;
		case TileType.WALL:
			gameObject = this.wall;
			break;
		}

		return gameObject;
	}

	public void SetupScene (TextAsset filename)
	{
		BoadSetup (filename);
	}
}

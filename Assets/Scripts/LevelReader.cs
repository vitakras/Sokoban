using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelReader {

	public TileType[][] Load(TextAsset textAsset){
		string text = textAsset.text;
		string[] lines = Regex.Split(text, "\n");
		int rows = lines.Length;

		TileType[][] levelBase = new TileType[rows][];
		for (int i = 0; i < rows; i++)  {
			string[] stringsOfLine = Regex.Split(lines[i], " ");
			levelBase[rows - i - 1] = this.ParseRow(stringsOfLine); // To Read it in top to bottom
		}


		return levelBase;
	}

	private TileType[] ParseRow(string [] row) {
		TileType [] tileRow = new TileType[row.Length];

		for (int i = 0; i < row.Length; i++) {
		//	Debug.Log(row[i]);
			tileRow[i] = (TileType) int.Parse(row[i]);
		}

		return tileRow;
	}
}

﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadGame() {
		SceneManager.LoadScene(0);
	}
}

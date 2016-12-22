using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OnLevelComplete : MonoBehaviour
{

	void OnEnable ()
	{
		EventManager eventManager = EventManager.intance;

		if (eventManager) {
			eventManager.RegisterAction ((int)EventType.ALL_LOCATIONS_OCCUPIED, this.LevelComplete);
		}
	}

	void OnDisable ()
	{
		EventManager eventManager = EventManager.intance;

		if (eventManager) {
			eventManager.DeRegisterAction ((int)EventType.ALL_LOCATIONS_OCCUPIED, this.LevelComplete);
		}
	}

	private void LevelComplete ()
	{
		SceneManager.LoadScene (0);
	}
}

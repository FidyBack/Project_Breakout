using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnSomeStates : MonoBehaviour 
{
	public GameManager.GameState[] activeStates;
	GameManager gm;

	void Start() {
		gm = GameManager.GetInstance();
		GameManager.changeStateDelegate += UpdateVisibility;
		UpdateVisibility();
	}

	void UpdateVisibility() {
		if (activeStates.Contains(gm.gameState)) {
			gameObject.SetActive(true);
		}
		else {
			gameObject.SetActive(false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour {
	
    GameManager gm;

	private void OnEnable() {
		gm = GameManager.GetInstance();
	}

	public void Retornar() {
		gm.changeState(GameManager.GameState.GAME);
	}

	public void Inicio() {
		gm.changeState(GameManager.GameState.MENU);
	}
}

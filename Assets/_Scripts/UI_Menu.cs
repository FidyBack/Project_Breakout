using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
    GameManager gm;

	private void OnEnable() {
		gm = GameManager.GetInstance();
	}

	public void Iniciar() {
		gm.changeState(GameManager.GameState.GAME);
	}
}

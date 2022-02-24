using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour {
	
	private GameObject Bola;
    GameManager gm;

	private void OnEnable() {
		gm = GameManager.GetInstance();
	}

	public void Retornar() {
		gm.changeState(GameManager.GameState.GAME);
	}

	public void Inicio() {
		GameObject.Find("Raquete").GetComponent<Rigidbody2D>().position = new Vector2(0, -5.25f);;
		gm.changeState(GameManager.GameState.MENU);
	}
}

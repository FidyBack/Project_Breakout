using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
	public GameObject Bloco;
	GameManager gm;

	void Start() {
		gm = GameManager.GetInstance();
		GameManager.changeStateDelegate += Construir;
		Construir();
	}

	void Construir() {
		if (gm.gameState == GameManager.GameState.GAME && gm.lastState != GameManager.GameState.PAUSE || gm.gameState == GameManager.GameState.MENU) {
			foreach(Transform child in transform) {
				GameObject.Destroy(child.gameObject);
			}

			for(int i=0; i<9; i++) {
				for(int j=0; j<4; j++) {
					Vector3 posicao = new Vector3(-7.0f + 1.75f * i, 4.5f - 0.75f * j);
					Instantiate(Bloco, posicao, Quaternion.identity, transform);
				}
			}
		}
	}

	void Update() {
		if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME) {
			gm.changeState(GameManager.GameState.ENDGAME);
		}
	}
}

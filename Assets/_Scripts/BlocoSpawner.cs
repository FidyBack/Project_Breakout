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
		if (gm.gameState == GameManager.GameState.GAME) {
			foreach(Transform child in transform) {
				GameObject.Destroy(child.gameObject);
			}
			for(int i=0; i<13; i++) {
				for(int j=0; j<5; j++) {
					Vector3 posicao = new Vector3(-9.3f + 1.55f * i, 4 - 0.55f * j);
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

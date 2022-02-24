// https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/ -> Mudança de sprites
// https://youtu.be/RYG8UExRkhA?t=3535 -> Estado e pontuação dos blocos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{	
	public GameObject Bloco;
	GameManager gm;

	public SpriteRenderer spriteRenderer;
	public Sprite[] states;

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

					Bloco bloco = Bloco.GetComponent<Bloco>();
					bloco.vida = j+1;

					if (bloco.vida == 1) {
						spriteRenderer.sprite = states[0];
					}
					else if (bloco.vida == 2) {
						spriteRenderer.sprite = states[1];
					}
					else if (bloco.vida == 3) {
						spriteRenderer.sprite = states[2];
					}
					else if (bloco.vida == 4) {
						spriteRenderer.sprite = states[3];
					}

					Vector3 posicao = new Vector3(-7.0f + 1.75f * i, 2.0f + 0.75f * j);
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

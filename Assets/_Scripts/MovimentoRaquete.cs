// https://youtu.be/Cry7FOHZGN4?t=241 -> Lidar com o movimento da raquete usando velocidade ao invés de força ou posição (O movimento fica mais smooth e evita bugs de colisão com a parede)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour {

	GameManager gm;
	public Rigidbody2D rb;
	public float velocidadeRaquete = 9.5f;

	void Start() {
		gm = GameManager.GetInstance();
	}

	void Update() {
		if(gm.gameState == GameManager.GameState.PAUSE || gm.gameState == GameManager.GameState.ENDGAME || gm.gameState == GameManager.GameState.MENU) {
			rb.velocity = new Vector2 (0, 0);
			return;
		}
		
		float inputx = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(inputx,0) * velocidadeRaquete;
	}
}

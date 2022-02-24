using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour {

	public Text message;
	GameManager gm;

	void OnEnable() {
		gm = GameManager.GetInstance();

		if(gm.vidas > 0) {
			message.text = "Você Ganhou!!!";
		}
		else {
			message.text = "Você Perdeu :(";
		}
	}

	public void Voltar() {
		GameObject.Find("Raquete").GetComponent<Rigidbody2D>().position = new Vector2(0, -5.25f);;
		gm.changeState(GameManager.GameState.GAME);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

	public enum GameState { MENU, GAME, PAUSE, ENDGAME };
	public GameState gameState { get; private set; }
	public GameState lastState { get; private set; } // Não deletar, quebra o spawn de blocos

	public delegate void ChangeStateDelegate();
	public static ChangeStateDelegate changeStateDelegate;

	public int vidas, pontos;
	private static GameManager _instance;
	public GameObject Bola;
	Vector3 oldVelocity;

	private GameManager() {
		vidas = 3;
		pontos = 0;
		gameState = GameState.MENU;
		Bola = GameObject.Find("Bola");
	}

	public static GameManager GetInstance() {
		if(_instance == null) {
			_instance = new GameManager();
		}

		return _instance;
	}

	public void changeState(GameState nextState) {
		lastState = gameState;

		if (nextState == GameState.MENU) {
			Bola.GetComponent<Rigidbody2D>().position = new Vector2(0, -4.75f);
			Bola.GetComponent<MovimentoBola>().multpVelocity = 0.0f;
			Reset();
		} 
		else if (gameState == GameState.GAME && nextState == GameState.PAUSE) {
			oldVelocity = Bola.GetComponent<Rigidbody2D>().velocity;
			Bola.GetComponent<MovimentoBola>().multpVelocity = 0.0f;
		}
		else if (gameState == GameState.PAUSE && nextState == GameState.GAME) {
			Bola.GetComponent<MovimentoBola>().StartLinearMov(oldVelocity);
		}
		else if (nextState == GameState.ENDGAME) {
			Bola.GetComponent<MovimentoBola>().multpVelocity = 0.0f;
		}
		else if (gameState == GameState.ENDGAME && nextState == GameState.GAME) {
			Reset();
			Bola.GetComponent<Rigidbody2D>().position = new Vector2(0, -4.75f);
			Bola.GetComponent<MovimentoBola>().StartMov();

		}
		else if (nextState == GameState.GAME) {
			Bola.GetComponent<MovimentoBola>().StartMov();
		}

		// Debug.Log();
		gameState = nextState;
		changeStateDelegate();
	}

	private void Reset() {
		vidas = 3;
		pontos = 0;
	}
}

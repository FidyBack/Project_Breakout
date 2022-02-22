using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

	public enum GameState { MENU, GAME, PAUSE, ENDGAME };
	public GameState gameState { get; private set; }

	public delegate void ChangeStateDelegate();
	public static ChangeStateDelegate changeStateDelegate;

	public int vidas, pontos;
	private static GameManager _instance;

	private GameManager() {
		vidas = 3;
		pontos = 0;
		gameState = GameState.MENU;
	}

	public static GameManager GetInstance() {
		if(_instance == null) {
			_instance = new GameManager();
		}

		return _instance;
	}

	public void changeState(GameState nextState) {
		if (nextState == GameState.GAME) Reset();
		gameState = nextState;
		changeStateDelegate();
	}

	private void Reset() {
		vidas = 3;
		pontos = 0;
	}
}

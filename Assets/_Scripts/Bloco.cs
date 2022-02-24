// https://youtu.be/RYG8UExRkhA?t=3535 -> Estado e pontuação dos blocos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour {
	
	public int vida, pontos = 0;
	private GameObject Spawner;
	public SpriteRenderer spriteRenderer;
	GameManager gm;

	private void OnCollisionEnter2D(Collision2D obj) {
		vida--;
		pontos++;
		Spawner = GameObject.Find("BlocoPool");
		gm = GameManager.GetInstance();

		if (vida > 0) {
			this.spriteRenderer.sprite = Spawner.GetComponent<BlocoSpawner>().states[vida-1];
		} else {
			gm.pontos += 5*pontos;
			Destroy(this.gameObject);
		}
	}
}

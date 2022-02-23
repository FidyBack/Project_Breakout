// https://youtu.be/RYG8UExRkhA?t=2293 -> Movimento da Bola usando o Rigidbody2D
// https://youtu.be/RYG8UExRkhA?t=2728 -> Implementação de ângulos entre a raquete e a bola
// https://answers.unity.com/questions/1446967/how-can-i-change-velocity-from-a-different-script.html -> Parar a raquete no game over

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoBola : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 velocidadeBola;
	public float multpVelocity = 8.0f;
	public float anguloSaidaMaximo = 75f;

	GameManager gm;
	public GameObject Player;

	void Start(){
		Player = GameObject.Find("Raquete");
		gm = GameManager.GetInstance();
	}

	public void StartMov(){
		multpVelocity = 8.0f;
		velocidadeBola.x = Random.Range(-0.4f, 0.4f);
		velocidadeBola.y = 1.0f;
		rb.velocity = velocidadeBola * multpVelocity;
	}

	public void StartLinearMov(Vector3 vel){
		multpVelocity = 8.0f;
		rb.velocity = vel;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
			gm.changeState(GameManager.GameState.PAUSE);
		}

		// Limita a velocidade máxima da bola
		if (rb.velocity.x > multpVelocity){
			rb.velocity = new Vector2(multpVelocity, rb.velocity.y);
		}
		else if (rb.velocity.x < -multpVelocity){
			rb.velocity = new Vector2(-multpVelocity, rb.velocity.y);
		}
		if (rb.velocity.y > multpVelocity){
			rb.velocity = new Vector2(rb.velocity.x, multpVelocity);
		}
		else if (rb.velocity.y < -multpVelocity){
			rb.velocity = new Vector2(rb.velocity.x, -multpVelocity);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

		Collider2D collider = collision.collider;

		if (collider.gameObject.CompareTag("Player")) {
			gm.pontos ++;

			Vector3 posicaoRaquete = Player.transform.position;
			Vector2 pontoContato = collision.GetContact(0).point;

			float offset = posicaoRaquete.x - pontoContato.x;
			float larguraRaquete = collider.bounds.size.x / 2;

			// Corrige bug de as vezes o offset ser maior que a Largura, por algum motivo
			if (offset > larguraRaquete){
				offset = larguraRaquete;
			}

			float anguloBola = Vector2.SignedAngle(Vector2.up, rb.velocity);
			float anguloSaida = (offset/larguraRaquete) * anguloSaidaMaximo;
			float novoAngulo = Mathf.Clamp(anguloBola + anguloSaida, -anguloSaidaMaximo, anguloSaidaMaximo);

			Quaternion rotation = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
			rb.velocity = rotation * Vector2.up * rb.velocity.magnitude;
		}

		if (collider.gameObject.CompareTag("Brick")) {
			gm.pontos += 5;
		}

		if (collider.name == "ParedeBaixo") {
			Reset();
		}
	}

	private void Reset() {
		gm.vidas--;

		if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME) {
			gm.changeState(GameManager.GameState.ENDGAME);
			return;
		}

		Vector3 playerPosition = Player.transform.position;
		transform.position = playerPosition + new Vector3(0, 0.5f, 0);
	}
}
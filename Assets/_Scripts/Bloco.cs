using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{

	private void OnCollisionEnter2D(Collision2D obj) {
		Destroy(this.gameObject);
	}

}

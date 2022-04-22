using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour {

	private float velocidad;
	private Vector2 posInicial;
	private float posx;
	private float posy;
	private float limite;

	// Use this for initialization
	void Start () {
		velocidad = Random.Range (1,5);

		posx = transform.position.x;
		posy = transform.position.y;
		if (posy > 2f) {
			limite = Random.Range (0f,5f);
		} else {
			limite = Random.Range (- 7f,-1f);
		}

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y + (-1f * velocidad * Time.deltaTime));
		if(transform.position.y < limite ){
			transform.position = new Vector2 (posx , posy);
			velocidad = Random.Range (1,5);
			if (posy > 2f) {
				limite = Random.Range (0f,5f);
			} else {
				limite = Random.Range (- 7f,-1f);
			}
		}
	}
}

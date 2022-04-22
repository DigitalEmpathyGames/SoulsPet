using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float velocidad;

	void Update () {
		float rotador = Time.deltaTime * velocidad;
		transform.Rotate (0, 0, rotador);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utils : MonoBehaviour {

	public static Utils instance = null;

	void Awake(){

		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	public Sprite traerSprite (string nombre){
		return Resources.Load <Sprite> (Constantes.fldrSprites + nombre);
	}

	public GameObject traerGameObject(string nombre){
		return Resources.Load<GameObject> (Constantes.fldrGO + nombre);
	}

	public void cambiarTexto(Text texto, string str){
		texto.text = str;
	}



	public void rellenaImage(Image image, float cant, float total){
		image.fillAmount = cant/total;
	}



}

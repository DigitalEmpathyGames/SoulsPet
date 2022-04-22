using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarTextos : MonoBehaviour {
	
	public static CargarTextos instance = null;

	private bool TestCargado = false;
	private bool activado = true;
	public GameObject textoTest;

	private int largoLinea = 30;



	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}

		cargarTest ();

	}

	private void cargarTest(){
		int idioma = PlayerPrefs.GetInt ("idioma");
		string nombreGameObject;
		if (idioma == 0) {
			nombreGameObject = "Textos/Textos_ES";
		} else {
			nombreGameObject = "Textos/Textos_EN";
		}
		GameObject TextGameObject = Resources.Load <GameObject> (nombreGameObject);
		GameObject TextoIdioma = Instantiate (TextGameObject, transform.position, Quaternion.identity) as GameObject;
		TextoIdioma.transform.parent = textoTest.transform;
		TestController.instance.setActivado (true);

	}

	public string[] obtenerLineas(string texto){
		string textAux = texto;
		float largo = textAux.Length;
		string[] retorno = new string[50];
		bool sepLineas = true;
		int numLinea = 0;
		if(textAux.Length > 0){
			if (!(largoLinea < largo)) {
				retorno = new string[1];
				retorno [numLinea] = textAux;
			} else {
				while(sepLineas){
					string linea;
					bool cutLimit = true;
					bool buscSpc = true;
					int indcSpc = largoLinea - 1;
					linea = textAux.Substring (0, largoLinea);
					if(textAux.Substring (0, largoLinea + 1).Equals(" ")){
						buscSpc = false;
					}
					while(buscSpc){
						if(linea.Substring(indcSpc,1).Equals(" ")){
							linea = linea.Substring (0,indcSpc);
							cutLimit = false;
							buscSpc = false;
						}
						if (indcSpc < 1) {
							buscSpc = false;
						}
						indcSpc = indcSpc - 1;
					}
					int cortador;
					if(cutLimit){
						cortador = largoLinea;
					}else{
						cortador = indcSpc;
					}

					retorno [numLinea] = linea;
					textAux = textAux.Substring (cortador + 1);
					numLinea = numLinea + 1;

					if(textAux.Length < largoLinea){
						
						linea = textAux.Substring (0);
						retorno [numLinea] = linea;
						sepLineas = false;
					}
				}
			}
		}
		return retorno;
	}
	
	// Update is called once per frame
	void Update () {


			

	}
}

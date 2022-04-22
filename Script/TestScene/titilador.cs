using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titilador : MonoBehaviour {

	public static titilador instance = null;

	public float velocidad;
	Renderer rend;
	public float limiteBajo;
	public float limiteAlto;


	private bool aclarar = true;
	private bool activado = true;
	private bool terminoPres = false;

	private string modo = "espera";

	private int contPres = 1;
	private int presents = 1;

	private float intensidad = 0f;
	private float factorVelocidad = 3f;
	private float factorAlto = 4f;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
			switch(modo){
			case "espera":
				ejeEspera ();
				break;
			case "presentacion":
				ejePres ();
				break;
			default:
				break;
			}
		}

	}

	private void ejeEspera(){
		if (aclarar) {
			intensidad = intensidad + (Time.deltaTime * velocidad);
			if(intensidad > limiteAlto){
				aclarar = false;
			}
		} else {
			intensidad = intensidad - (Time.deltaTime * velocidad);
			if(intensidad < limiteBajo){
				aclarar = true;
			}
		}
		rend.material.color =  new Color (rend.material.color.r, rend.material.color.g, rend.material.color.b, intensidad);
	}

	private void ejePres(){
		if (aclarar) {
			intensidad = intensidad + (Time.deltaTime * (velocidad * factorVelocidad));
			if(intensidad > (limiteAlto * factorAlto)){
				aclarar = false;

			}
		} else {
			intensidad = intensidad - (Time.deltaTime * (velocidad * factorVelocidad));
			if(intensidad < limiteBajo){
				aclarar = true;
				contPres = contPres + 1;
			}
		}
		rend.material.color =  new Color (rend.material.color.r, rend.material.color.g, rend.material.color.b, intensidad);
		if(contPres > presents){
			terminoPres = true;
			contPres = 1;
		}
	}

	public void setActivado(bool permiso){
		activado = permiso;
	}

	public bool getActivado(){
		return activado;
	}

	public bool getTerminoPres(){
		return terminoPres;
	}

	public void setModo(string nuevoModo){
		modo = nuevoModo;
	}

	public void setTerminoPres(bool permiso){
		terminoPres = permiso;
	}

	public string getModo(){
		return modo;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoController : MonoBehaviour {

	public static ElementoController instance = null;

	public GameObject elemento;

	private SpriteRenderer spriteR;

	private bool activado = false;
	private bool letMostrar = true;

	private int ordElemento = 1;
	private int vueltas = 5;
	private int vuelta = 1;

	private float velocidad = 50f;
	private float esperaAvance = 1f;
	private float esperaAvanceDes = 1f;


	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
		spriteR = gameObject.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
			float rotador = Time.deltaTime * velocidad;
			transform.Rotate (0, rotador, 0);
			switch(ordElemento){
			case 1:
				if (letMostrar) {
					letMostrar = false;
					string nombreSprite = "Sprites/elemento_fondo";
					spriteR.sprite = Resources.Load <Sprite> (nombreSprite);
					mostrarRol ();
				}
				break;
			case 2:
				if (letMostrar) {
					letMostrar = false;
					mosrtarClass ();
				}
				break;
			case 3:
				if (letMostrar) {
					letMostrar = false;

					mosrtarElement ();
					TestController.instance.cambiarBoton1 (34);
				}
				break;
			case 4:
				if (letMostrar) {
					letMostrar = false;

					mosrtarElement ();
					TestController.instance.setTermino (true);
					TestController.instance.cambiarBoton1 (35);

					string info;
					string[] lineas;

					info = Test_ES.instance.obtenerInfo (2);
					lineas = CargarTextos.instance.obtenerLineas (info);
					TestController.instance.cambiarPregunta (lineas);

				}
				break;
			default:
				titilador.instance.setModo ("espera");
				activado = false;
				break;
			}

		}
	}

	private void mostrarRol(){
		string rol;
		string nombreSprite;
		string info;
		string[] lineas;
		int valInfo;

		rol = TestController.instance.getRolResult ();
		nombreSprite = "Sprites/elemento_" + rol;
		elemento.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite> (nombreSprite);

		valInfo = TestController.instance.getInfoRol ();
		info = Test_ES.instance.obtenerInfo (valInfo);
		lineas = CargarTextos.instance.obtenerLineas (info);
		TestController.instance.cambiarPregunta (lineas);

	}

	private void mosrtarClass (){
		string clase;
		string nombreSprite;
		string info;
		string[] lineas;
		int valInfo;
		clase = TestController.instance.getClassResult();
		nombreSprite = "Sprites/elemento_" + clase;
		elemento.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite> (nombreSprite);

		valInfo = TestController.instance.getInfoClass();
		info = Test_ES.instance.obtenerInfo (valInfo);
		lineas = CargarTextos.instance.obtenerLineas (info);
		TestController.instance.cambiarPregunta (lineas);
	}

	private void mosrtarElement(){
		string eleStr;
		string nombreSprite;
		string info;
		string[] lineas;
		int valInfo;
		eleStr = TestController.instance.getEleRsult();
		nombreSprite = "Sprites/elemento_" + eleStr;
		elemento.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite> (nombreSprite);

		valInfo = TestController.instance.getInfoElement();
		info = Test_ES.instance.obtenerInfo (valInfo);
		lineas = CargarTextos.instance.obtenerLineas (info);
		TestController.instance.cambiarPregunta (lineas);
	}

	public void setActivado(bool permiso){
		activado = permiso;
	}

	public void setMostrar(bool permiso){
		letMostrar = permiso;
	}

	public void sumarOrdElem(){
		ordElemento = ordElemento + 1;
	}



}

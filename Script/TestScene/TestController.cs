using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestController : MonoBehaviour {

	public static TestController instance = null;

	public Canvas canvasLoad;
	public Canvas canvasTest;

	public GameObject destello;
	public GameObject presMascota;

	public Button boton1;
	public Button boton2;
	public Button boton3;
	public Button boton4;
	public Button boton5;

	public Text txtPregunta;
	public Text txtRespuesta1;
	public Text txtRespuesta2;
	public Text txtRespuesta3;
	public Text txtRespuesta4;
	public Text txtRespuesta5;

	private AsyncOperation operacion;

	private SpriteRenderer spriteR;
	private Sprite colorBoton;

	private bool activado = false;
	private bool pasarPregunta = true;
	private bool letResul = true;
	private bool modoInfo = true;
	private bool terminarTest = false;
	private bool bienvenida = true;
	private bool esperarResultado = false;
	private bool cambioScen = false;

	private float tiempoEspera = 2f;

	private int cantPreguntas;

	private int sumPoint = 10;
	private int resPoint = 2;

	private int prgActual = 0;
	private int elementalActual = 0;

	private int tnkPoint = 0;
	private int healPoint = 0;
	private int dpsPoint = 0;
	private int infoRol;

	private int warriorPoint = 0;
	private int archerPoint = 0;
	private int wizardPoint = 0;
	private int infoClass = 0;

	private int firePoint = 0;
	private int waterPoint = 0;
	private int metalPoint = 0;
	private int tierraPoint = 0;
	private int maderaPoint = 0;
	private int infoElement = 0;

	private ObjectColor color;
	private string rol = "";
	private string clase = "";
	private string elemento = "";

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		boton2.gameObject.SetActive (false);
		boton3.gameObject.SetActive (false);
		boton4.gameObject.SetActive (false);
		boton5.gameObject.SetActive (false);
		cambiarBoton1 (34);
		darBienvenida ();
	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
			if (esperarResultado) {
				tiempoEspera = tiempoEspera - Time.deltaTime;
				if(tiempoEspera < 0f){
					esperarResultado = false;
					boton1.gameObject.SetActive (true);
					ElementoController.instance.setActivado (true);
					tiempoEspera = 2f;

				}
			} else {
				if(!bienvenida){
					if(prgActual > cantPreguntas){
						pasarPregunta = false;
						if(letResul){
							letResul = false;
							mostrarResultados ();
							modoInfo = true;
							cambiarBoton1 (34);
						}

					}
					if(pasarPregunta){
						pasarPregunta = false;
						if(prgActual > 5 && !((prgActual + 1) > cantPreguntas)){
							boton4.gameObject.SetActive (true);
							boton5.gameObject.SetActive (true);
						}
						cargarPregunta ();
						cargarRespuestas ();
						prgActual = prgActual + 1;
					}
				}
			}

			if(cambioScen){
				canvasLoad.gameObject.SetActive (true);
				tiempoEspera -= Time.deltaTime;
				if(tiempoEspera < 0f){
					irACasa ();
				}

			}
		}
	}

	public void cambiarBoton1(int respuesta){
		string texto;
		if (PlayerPrefs.GetInt ("idioma") == 0) {
			texto = Test_ES.instance.obtenerRespuesta(respuesta);
		} else {
			texto = Test_EN.instance.obtenerRespuesta(respuesta);
		}
		txtRespuesta1.text = texto;
	}

	public void setCantPregntas(int nuevaCant){
		cantPreguntas = nuevaCant;
	}

	public ObjectColor getColor(){
		return color;
	}

	public int getInfoRol(){
		return infoRol;
	}

	public int getInfoClass(){
		return infoClass;
	}

	public int getInfoElement(){
		return infoElement;
	}

	public void cambiarPregunta (string[] nuevaPregunta){
		txtPregunta.text = lineasToText(nuevaPregunta);
	}


	public void mostrarResultados(){
		esperarResultado = true;
		Destroy (presMascota);
		boton1.gameObject.SetActive (false);
		string info;
		string[] lineas;
		info = Test_ES.instance.obtenerInfo (1);
		lineas = CargarTextos.instance.obtenerLineas (info);
		cambiarPregunta (lineas);
	}

	public string getRolResult(){
		
		int mayor;
		int resultado;
		mayor = Mathf.Max(tnkPoint, healPoint);
		resultado = Mathf.Max(mayor, dpsPoint);
		if(resultado == tnkPoint){
			rol = Constantes.rol_tnk;
			infoRol = 3;
		}else if(resultado == healPoint){
			rol = Constantes.rol_san;
			infoRol = 4;
		}else{
			rol = Constantes.rol_dan;
			infoRol = 5;
		}
		return rol;
	}

	public string getClassResult(){
		
		int mayor;
		int resultado;
		mayor = Mathf.Max(warriorPoint, archerPoint);
		resultado = Mathf.Max(mayor, wizardPoint);
		if(resultado == warriorPoint){
			clase = Constantes.class_gue;
			infoClass = 6;
		}else if(resultado == archerPoint){
			clase = Constantes.class_arc;
			infoClass = 7;
		}else{
			clase = Constantes.class_mag;
			infoClass = 8;
		}
		return clase;
	}

	public string getEleRsult(){
		
		int mayor;
		int mayor1;
		int mayor2;
		int resultado;
		mayor = Mathf.Max(firePoint, waterPoint);
		mayor1 = Mathf.Max(metalPoint, tierraPoint);
		mayor2 = Mathf.Max(mayor, mayor1);

		resultado = Mathf.Max(mayor2, maderaPoint);

		if (resultado == firePoint) {
			elemento = Constantes.elemento_fue;
			infoElement = 11;
		} else if (resultado == waterPoint) {
			elemento = Constantes.elemento_agu;
			infoElement = 9;
		} else if (resultado == metalPoint) {
			elemento = Constantes.elemento_met;
			infoElement = 13;
		} else if (resultado == tierraPoint) {
			elemento = Constantes.elemento_tie;
			infoElement = 12;
		} else {
			elemento = Constantes.elemento_mad;
			infoElement = 10;
		}
		return elemento;
	}

	public void cargarPregunta(){
		int idioma = PlayerPrefs.GetInt ("idioma");
		if (idioma == 0) {
			cargarPreguntaES();
		} else {
			cargarPreguntaEN();
		}
	}

	public void cargarRespuestas(){
		int idioma = PlayerPrefs.GetInt ("idioma");
		if (idioma == 0) {
			cargarRespuestasES();
		} else {
			cargarRespuestasEN();
		}
	}

	public void respElementalesES(){
		string texto;
		string[] lineas;
		string texto1;
		string texto2;
		string texto3;
		string texto4;
		string texto5;

		texto = Test_ES.instance.obtenerRespuesta ((elementalActual * 5) + 18);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		texto1 = lineasToText (lineas);

		texto = Test_ES.instance.obtenerRespuesta (((elementalActual * 5) + 18) + 1);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		texto2 = lineasToText (lineas);

		texto = Test_ES.instance.obtenerRespuesta (((elementalActual * 5) + 18) + 2);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		texto3 = lineasToText (lineas);

		texto = Test_ES.instance.obtenerRespuesta (((elementalActual * 5) + 18) + 3);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		texto4 = lineasToText (lineas);


		texto = Test_ES.instance.obtenerRespuesta (((elementalActual * 5) + 18) + 4);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		texto5 = lineasToText (lineas);

		txtRespuesta1.text = texto1;
		txtRespuesta2.text = texto2;
		txtRespuesta3.text = texto3;
		txtRespuesta3.text = texto3;
		txtRespuesta4.text = texto4;
		txtRespuesta5.text = texto5;
		elementalActual = elementalActual + 1;
	}

	public void cargarRespuestasES(){
		string texto;
		string[] lineas;
		string texto1;
		string texto2;
		string texto3;
		switch(prgActual){
		case 6:
			respElementalesES ();
			break;
		case 7:
			respElementalesES ();
			break;
		case 8:
			respElementalesES();
			break;
		case 9:
			respColores();
			break;
		case 10:
			respMascota();
			break;
		default:
			texto = Test_ES.instance.obtenerRespuesta (prgActual * 3);
			lineas = CargarTextos.instance.obtenerLineas (texto);
			texto1 = lineasToText (lineas);

			texto = Test_ES.instance.obtenerRespuesta ((prgActual * 3) + 1);
			lineas = CargarTextos.instance.obtenerLineas (texto);
			texto2 = lineasToText (lineas);

			texto = Test_ES.instance.obtenerRespuesta ((prgActual * 3) + 2);
			lineas = CargarTextos.instance.obtenerLineas (texto);
			texto3 = lineasToText (lineas);

			txtRespuesta1.text = texto1;
			txtRespuesta2.text = texto2;
			txtRespuesta3.text = texto3;


			break;
		}
		
	}

	public void respMascota(){
		string texto;
		string[] lineas;
		texto = Test_ES.instance.obtenerRespuesta (33);
		lineas = CargarTextos.instance.obtenerLineas (texto);
		txtRespuesta1.text = lineasToText (lineas);
		boton2.gameObject.SetActive (false);
		boton3.gameObject.SetActive (false);
		boton4.gameObject.SetActive (false);
		boton5.gameObject.SetActive (false);
		PresentacionMascota.instance.setIniciar (true);
	}

	public void respColores(){
		txtRespuesta1.text = "";
		txtRespuesta2.text = "";
		txtRespuesta3.text = "";
		txtRespuesta4.text = "";
		txtRespuesta5.text = "";
		boton1.image.sprite = Resources.Load <Sprite> ("Sprites/color_amarillo");
		boton2.image.sprite = Resources.Load <Sprite> ("Sprites/color_azul");
		boton3.image.sprite = Resources.Load <Sprite> ("Sprites/color_morado");
		boton4.image.sprite = Resources.Load <Sprite> ("Sprites/color_rojo");
		boton5.image.sprite = Resources.Load <Sprite> ("Sprites/color_verde");


	}

	public void cargarRespuestasEN(){
	}


	public void cargarPreguntaES(){
		string texto = Test_ES.instance.obtenerPregunta (prgActual);
		string [] lineas = CargarTextos.instance.obtenerLineas (texto);
		txtPregunta.text = lineasToText (lineas);

	}

	public void cargarPreguntaEN(){
		string texto = Test_EN.instance.obtenerPregunta (prgActual);
		string [] lineas = CargarTextos.instance.obtenerLineas (texto);
		txtPregunta.text = lineasToText (lineas);

	}


	public void setActivado(bool nuevoPermiso){
		activado = nuevoPermiso;
	}

	public void setTermino(bool permiso){
		terminarTest = permiso;
	}

	private void darBienvenida(){
		string info;
		string[] lineas;
		info = Test_ES.instance.obtenerInfo (0);
		lineas = CargarTextos.instance.obtenerLineas (info);
		cambiarPregunta (lineas);
	}

	public void respuesta1(){
		if(modoInfo){
			if (!terminarTest) {
				if(bienvenida){
					bienvenida = false;
					modoInfo = false;
					boton2.gameObject.SetActive(true);
					boton3.gameObject.SetActive(true);
				}else{
					ElementoController.instance.sumarOrdElem ();
					ElementoController.instance.setMostrar (true);
				}


			} else {
				grabarTest ();
				cambioScen = true;
				//irACasa ();
			}

		}else{
			adminRespuesta (1);
			pasarPregunta = true;
		}

	}

	public void irACasa(){
		SceneManager.LoadScene ("Home");


		//StartCoroutine (empezarLoad("Home"));
	}

	private IEnumerator empezarLoad(string nombreEscena){
		operacion = SceneManager.LoadSceneAsync (nombreEscena);
		while(!operacion.isDone){
			yield return null;
		}
		operacion = null;
		canvasLoad.gameObject.SetActive (false);

	}

	public void grabarTest(){
		ObjectUsuario usuario = new ObjectUsuario();
		usuario.setIdUsuario("Usuario_4513hasdtu");
		usuario.setCantidad (1);//Creartrigger
		usuario.setNombre("Javito");
		usuario.setTestRealizado (true);//Crear trigger

		ObjectMascota mascota = new ObjectMascota ();
		mascota.setNombre ("Nekomata");//Cambiar cuando exista seleccion de mascota
		mascota.setNivel(1);//Crear trigger
		mascota.setColor(color);
		mascota.setNumero (1);// evaluar posible trigger
		mascota.setTipo(1);//  -- GATO  --  Cambiar cuando exista seleccion de mascota
		mascota.setRol(rol);
		mascota.setClase (clase);
		mascota.setElemento (elemento);


		//Trigear todo lo siguiente
		ObjectStatMascota stats = new ObjectStatMascota ();
		stats.setFuerza (1);
		stats.setAgilidad (1);
		stats.setInteligencia (1);
		stats.setVitalidad (1);
		stats.setDestreza (1);
		stats.setSuerte (1);
		stats.setActXtra(0);
		stats.setNxtXtra (9);
		stats.setActFrz (0);
		stats.setNxtFrz (9);
		stats.setActAgi (0);
		stats.setNxtAgi (9);
		stats.setActInt (0);
		stats.setNxtInt (9);
		stats.setActVit (0);
		stats.setNxtVit (9);
		stats.setActDes (0);
		stats.setNxtDes (9);


		Database.instance.insertarTest (usuario,mascota, stats);
	}

	public void respuesta2(){
		adminRespuesta (2);
		pasarPregunta = true;
	}

	public void respuesta3(){
		adminRespuesta (3);
		pasarPregunta = true;
	}

	public void respuesta4(){
		adminRespuesta (4);
		pasarPregunta = true;
	}

	public void respuesta5(){
		adminRespuesta (5);
		pasarPregunta = true;
	}

	public void adminRespuesta (int alternativa){
		if ((prgActual - 1) < 3) {
			puntosRol (alternativa);
		} else if ((prgActual - 1) < 6) {
			puntosClass (alternativa);
		} else if ((prgActual - 1) < 9) {
			puntosElemental (alternativa);
		} else if ((prgActual - 1) < 10) {
			setColor (alternativa);
		} else {
		}
		
	}

	public void setColor(int alternativa){
		SpriteRenderer sprtRender;
		sprtRender = destello.GetComponent<SpriteRenderer> ();
		switch(alternativa){
		case 1:
			color = new ObjectColor (255f,248f,0f,255f);
			sprtRender.color = new Color(255,248,0,255);
			break;
		case 2:
			color = new ObjectColor (0f,0f,255f,255f);
			sprtRender.color = new Color(0,0,255,255);
			break;
		case 3:
			color = new ObjectColor (175f,0f,195f,255f);
			sprtRender.color = new Color(175,0,195,255);
			break;
		case 4:
			color = new ObjectColor (255f,0f,0f,255f);
			sprtRender.color = new Color(255,0,0,255);
			break;
		case 5:
			color = new ObjectColor (0f,255f,0f,255f);
			sprtRender.color = new Color(0,255,0,255);
			break;
		default:
			break;
		}

		boton1.image.sprite = Resources.Load <Sprite> ("Sprites/CuadrosTextos_etc");
		boton2.image.sprite = Resources.Load <Sprite> ("Sprites/CuadrosTextos_etc");
		boton3.image.sprite = Resources.Load <Sprite> ("Sprites/CuadrosTextos_etc");
		boton4.image.sprite = Resources.Load <Sprite> ("Sprites/CuadrosTextos_etc");
		boton5.image.sprite = Resources.Load <Sprite> ("Sprites/CuadrosTextos_etc");

	}

	public void puntosElemental(int alternativa){
		switch(prgActual - 1){
		case 6:
			switch(alternativa){
			case 1:
				waterPoint = waterPoint + sumPoint;
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				break;
			case 2:
				firePoint = firePoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				break;
			case 3:
				metalPoint = metalPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 4:
				tierraPoint = tierraPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 5:
				maderaPoint = maderaPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 7:
			switch(alternativa){
			case 1:
				firePoint = firePoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				break;
			case 2:
				waterPoint = waterPoint + sumPoint;
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				break;
			case 3:
				tierraPoint = tierraPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 4:
				maderaPoint = maderaPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 5:
				metalPoint = metalPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 8:
			switch(alternativa){
			case 1:
				metalPoint = firePoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 2:
				tierraPoint = waterPoint + sumPoint;
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				break;
			case 3:
				firePoint = firePoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				break;
			case 4:
				maderaPoint = maderaPoint + sumPoint;
				if(waterPoint < 1){
					waterPoint = waterPoint - resPoint;
				}
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			case 5:
				waterPoint = waterPoint + sumPoint;
				if(metalPoint < 1){
					metalPoint = metalPoint - resPoint;
				}
				if(maderaPoint < 1){
					maderaPoint = maderaPoint - resPoint;
				}
				if(tierraPoint < 1){
					tierraPoint = tierraPoint - resPoint;
				}
				if(firePoint < 1){
					firePoint = firePoint - resPoint;
				}
				break;
			default:
				break;
			}


			break;
		default:
			break;
		}
	}

	public void puntosClass(int alternativa){
		switch(prgActual - 1){
		case 3:
			switch(alternativa){
			case 1:
				archerPoint = archerPoint + sumPoint;
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				break;
			case 2:
				wizardPoint = wizardPoint + sumPoint;
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				break;
			case 3:
				warriorPoint = warriorPoint + sumPoint;
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 4:

			switch(alternativa){
			case 1:
				warriorPoint = warriorPoint + sumPoint;
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				break;
			case 2:
				wizardPoint = wizardPoint + sumPoint;
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				break;
			case 3:
				archerPoint = archerPoint + sumPoint;
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 5:
			switch(alternativa){
			case 1:
				warriorPoint = warriorPoint + sumPoint;
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				break;
			case 2:
				archerPoint = archerPoint + sumPoint;
				if(wizardPoint < 1){
					wizardPoint = wizardPoint - resPoint;
				}
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				break;
			case 3:
				wizardPoint = wizardPoint + sumPoint;
				if(warriorPoint < 1){
					warriorPoint = warriorPoint - resPoint;
				}
				if(archerPoint < 1){
					archerPoint = archerPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		default:
			break;
		}
	}

	public void puntosRol(int alternativa){
		switch(prgActual - 1){
		case 0:
			switch(alternativa){
			case 1:
				tnkPoint = tnkPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				break;
			case 2:
				dpsPoint = dpsPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			case 3:
				healPoint = healPoint + sumPoint;
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 1:

			switch(alternativa){
			case 1:
				dpsPoint = dpsPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			case 2:
				tnkPoint = tnkPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				break;
			case 3:
				healPoint = healPoint + sumPoint;
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		case 2:
			switch(alternativa){
			case 1:
				healPoint = healPoint + sumPoint;
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			case 2:
				dpsPoint = dpsPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(tnkPoint < 1){
					tnkPoint = tnkPoint - resPoint;
				}
				break;
			case 3:
				tnkPoint = tnkPoint + sumPoint;
				if(healPoint < 1){
					healPoint = healPoint - resPoint;
				}
				if(dpsPoint < 1){
					dpsPoint = dpsPoint - resPoint;
				}
				break;
			default:
				break;
			}
			break;
		default:
			break;
		}



	}

	private string lineasToText(string[] lineasInput){
		bool crearTexto = true;
		int numLinea = 0;
		string retorno = "";

		while (crearTexto){
			if (numLinea < lineasInput.Length) {
				string linea = lineasInput [numLinea];
				if (linea != null) {
					if (linea.Trim ().Length > 0) {
						retorno = retorno + linea.Trim() + "\n";
					} else {
						crearTexto = false;
					}
				} else {
					crearTexto = false;
				}
			} else {
				crearTexto = false;
			}
			numLinea = numLinea + 1;
		}

		return retorno;
	}

}

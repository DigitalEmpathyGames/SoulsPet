using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movilidad : MonoBehaviour {

	public static Movilidad instance = null;

	private bool activado = false;
	private bool permitirParametros = true;
	private bool permitirDeambular = true;
	private bool oscilarArriba = true;
	private float tiempoDeambulo = 0f;
	private float aDeambularX = 0f;
	private float aDeambularY = 0f;
	private float esperarDeambulo = 0f;
	private float tiempoAccion = 0f;
	private float tiempoGuino = 1f;
	private float velOsci = 0.5f;
	private float longOsci = 0.2f;
	private int cantAccion = 1;
	private int nuevaVelocidad = 0;
	private int nivelActualMascota = 1;
	private string accion;

	public GameObject mascota;


	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}




	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
			if (permitirDeambular) {
				deambular ();
			} else {
				if (!(nivelActualMascota > 50)) {
					oscilar ();
				}
				esperarNuevoDeambulo ();
			}

		}
	}

	public void cargarMascota (ObjectMascota mscta){
		Debug.Log ("Hola");
		int etapa = traerEtapa (mscta.getNivel());
		string nombreGameObject = "GameObject/mascota_1_" + etapa;
		GameObject mascotaDinGO = Resources.Load <GameObject> (nombreGameObject);
		SpriteRenderer sr =  mascotaDinGO.GetComponent<SpriteRenderer> ();
		ObjectColor color = mscta.getColor ();
		sr.color = new Color (color.getR(),color.getG(),color.getB(),color.getA());
		GameObject mascotaDinamica = Instantiate (mascotaDinGO, transform.position, Quaternion.identity) as GameObject;
		mascotaDinamica.transform.parent = mascota.transform;
	}

	private int traerEtapa(int nivel){
		int etapa;
		if(!(nivel > 10)){
			etapa = 1;
		}else if((nivel > 50)){
			etapa = 2;
		}else {
			etapa = 3;
		}
		return etapa;
	}

	public void oscilar(){
		if (oscilarArriba) {
			Vector2 destino = new Vector2 (aDeambularX, aDeambularY + longOsci);
			float velocidadDeambular = Time.deltaTime * velOsci;
			transform.position = Vector3.MoveTowards (transform.position, destino, velocidadDeambular);
			if(transform.position.y.Equals(destino.y)){
				oscilarArriba = false;
			}
		} else {
			Vector2 destino = new Vector2 (aDeambularX, aDeambularY - longOsci);
			float velocidadDeambular = Time.deltaTime * velOsci;
			transform.position = Vector3.MoveTowards (transform.position, destino, velocidadDeambular);
			if(transform.position.y.Equals(destino.y)){
				oscilarArriba = true;
			}
		}
	}

	public void setActivado(bool permiso){
		activado = permiso;
	}

	public bool getActivado(){
		return activado;
	}

	public void esperarNuevoDeambulo(){
		esperarDeambulo = esperarDeambulo - Time.deltaTime;
		if (esperarDeambulo < 0f) {
			permitirDeambular = true;
			permitirParametros = true;
		} else {
			realizarAccion ();
		}
	}

	public void realizarAccion(){
		if(tiempoDeambulo < ((float)cantAccion * tiempoAccion)){
			cantAccion = cantAccion - 1;
		}
		switch(accion){
		case "guino":
			if (cantAccion > 0) {
				tiempoAccion = tiempoAccion - Time.deltaTime;

				if (tiempoAccion > (tiempoGuino / 2f)) {
					RostroMascotaScript.instance.cambiarSprite (0);
				} else if (tiempoAccion > 0f) {
					RostroMascotaScript.instance.cambiarSprite (1);
				} else {
					cantAccion = cantAccion - 1;
					tiempoAccion = tiempoGuino;
				}
			} else {
				RostroMascotaScript.instance.cambiarSprite (0);
			}
			break;
		default:
			break;
		}
	}

	public void deambular(){
		if(permitirParametros){
			permitirParametros = false;
			tiempoDeambulo = Random.Range (1f, 10.0f);
			aDeambularX = Random.Range (-3f, 3f);
			aDeambularY = Random.Range (-4f, 4f);
			nuevaVelocidad = Random.Range (1, 10);
			int numeroSprite;
			bool guino = hacerGuino ();
			if (aDeambularX > transform.position.x) {
				numeroSprite = 2;
				if (guino) {
					numeroSprite = 3;
				}
				RostroMascotaScript.instance.cambiarSprite (numeroSprite);
			} else if (aDeambularX < transform.position.x) {
				numeroSprite = 4;
				if (guino) {
					numeroSprite = 5;
				}
				RostroMascotaScript.instance.cambiarSprite (numeroSprite);
			} else {
				numeroSprite = 0;
				if (guino) {
					numeroSprite = 1;
				}
				RostroMascotaScript.instance.cambiarSprite (numeroSprite);
			}
				
		}
		Vector2 destino = new Vector2 (aDeambularX, aDeambularY);
		float velocidadDeambular = Time.deltaTime * nuevaVelocidad;
		transform.position = Vector3.MoveTowards(transform.position, destino, velocidadDeambular);

		if(aDeambularX.Equals(transform.position.x) && aDeambularY.Equals(transform.position.y)){
			esperarDeambulo = Random.Range (1f, 10f);
			tiempoDeambulo = esperarDeambulo;
			permitirDeambular = false;
			accion = obtenerAccion ();
			RostroMascotaScript.instance.cambiarSprite (0);
		}
	}

	public bool hacerGuino(){
		bool permiso = false;
		int indGuino = Random.Range (1, 20);
		if(!(indGuino > 3)){
			permiso = true;
		}
		return permiso;
	}

	public string obtenerAccion(){
		string retorno = "nada";
		tiempoAccion = esperarDeambulo;
		cantAccion = 1;
		if(hacerGuino()){
			cantAccion = Random.Range (1, 4);
			tiempoAccion = tiempoGuino;
			retorno = "guino";
		}
		return retorno;
	}

}

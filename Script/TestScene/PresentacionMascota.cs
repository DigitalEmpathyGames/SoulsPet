using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentacionMascota : MonoBehaviour {

	public static PresentacionMascota instance = null;

	private int nivelMascota = 0;
	private int mascotaActual = 1;

	private string nombreAnterior = "";

	private bool iniciar = false;

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
		if(iniciar){
			iniciar = false;
			sumarNivel ();
			cargarMascota ();
		}
	}

	public void setIniciar(bool permiso){
		iniciar = permiso;
	}

	public void sumarNivel(){
		nivelMascota = nivelMascota + 1;
		if (nivelMascota > 3) {
			nivelMascota = 1;
		}
	}

	public void cargarMascota (){
		if(!nombreAnterior.Equals("")){
			Destroy (GameObject.Find(nombreAnterior));
		}
		string nombreGameObject = "GameObject/presentacion_" + mascotaActual +"_" + nivelMascota;
		nombreAnterior = "presentacion_" + mascotaActual +"_" + nivelMascota + "(Clone)";
		GameObject mascotaDinGO = Resources.Load <GameObject> (nombreGameObject);
		GameObject mascotaDinamica = Instantiate (mascotaDinGO, transform.position, Quaternion.identity) as GameObject;
		mascotaDinamica.transform.parent = mascota.transform;
	}

}

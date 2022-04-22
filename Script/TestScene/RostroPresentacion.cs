using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RostroPresentacion : MonoBehaviour {

	private bool activado = true;
	private Sprite[] rostroSprite;
	private int nivelActualMascota = 1;
	private SpriteRenderer spriteR;
	private Transform spriteT;

	public int numMascota;
	public int nivelHasta;
	public int cantSprites;

	private bool hacerGuino = false;
	private float tiempoMascota = 1f;
	private float tiempoMascotaDsc = 1f;


	void Awake(){
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		spriteT = gameObject.GetComponent<Transform>();
		rostroSprite = new Sprite[cantSprites];
		cargarSprites ();
	}

	// Use this for initialization
	void Start () {
		cambiarSprite(0);
	}

	// Update is called once per frame
	void Update () {
		if(activado){
				tiempoMascotaDsc = tiempoMascotaDsc - Time.deltaTime;
				if (tiempoMascotaDsc < 0.5f && tiempoMascotaDsc > 0.3) {
					hacerGuino = true;
				} else {
					hacerGuino = false;
					cambiarSprite (0);
				}
				if(hacerGuino){
					hacerGuino = false;
					cambiarSprite (1);
				}
				if(tiempoMascotaDsc < 0f){	
					PresentacionMascota.instance.sumarNivel ();
					PresentacionMascota.instance.cargarMascota();
				}
		}
	}

	public void setActivado(bool permiso){
		activado = permiso;
	}

	public bool getActivado(){
		return activado;
	}

	public void cambiarSprite(int sprite){
		spriteR.sprite = rostroSprite[sprite];
	}

	private void cargarSprites(){
		for(int i = 0; i < cantSprites; i++){
			string nombreSprite = "Sprites/Rostro_" + numMascota + "_" + nivelHasta + "_" + i;
			rostroSprite [i] = Resources.Load <Sprite> (nombreSprite);
		}
	}
}

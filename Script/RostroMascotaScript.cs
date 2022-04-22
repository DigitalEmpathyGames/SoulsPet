using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RostroMascotaScript : MonoBehaviour {
	
	public static RostroMascotaScript instance = null;
	private bool activado = true;
	private Sprite[] rostroSprite;
	private int nivelActualMascota = 1;
	private SpriteRenderer spriteR;
	private Transform spriteT;


	void Awake(){
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		spriteT = gameObject.GetComponent<Transform>();
		spriteT.localScale = new Vector3 (0.45f, 0.45f, 1);
		if(!(nivelActualMascota > 10)){
			rostroSprite = new Sprite[6];
			cargarSprites (6,10);

		}else if((nivelActualMascota > 50)){
		}else {
		}
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		cambiarSprite(0);
		Movilidad.instance.setActivado (true);
	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
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

	private void cargarSprites(int cantidad, int lvlHasta){
		for(int i = 0; i < cantidad; i++){
			string nombreSprite = "Sprites/Rostro_" + lvlHasta + "_" + i;
			rostroSprite [i] = spriteR.sprite = Resources.Load <Sprite> (nombreSprite);
		}
	}
}

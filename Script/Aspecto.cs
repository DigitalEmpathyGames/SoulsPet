using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspecto : MonoBehaviour {
	private bool activado = true;
	private bool oscilarArriba = true;
	private bool permitir = true;
	private bool permitirColor = true;

	private float longOsci = 0.3f;
	private float velOsci = 0.5f;
	private float posXini;
	private float posYini;


	public string accion;
	public float valor;
	public string escena;

	// Use this for initialization
	void Start () {
		posXini = transform.position.x;
		posYini = transform.position.y;
		ejecApariencia ();
	}
	
	// Update is called once per frame
	void Update () {
		if(activado){
			ejecAccion ();
		}
	}

	public void ejecApariencia(){
		switch(accion){
		case "transparencia":
			transparentar ();
			break;
		case "transparencia_color":
			cambiarColor ();
			transparentar ();
			break;
		case "color":
			cambiarColor ();
			break;
		default:
			break;
		}
	}

	public void ejecAccion(){
		switch(accion){
		case "oscilar":
			oscilar ();
			break;
		case "transparencia_oscilar":
			oscilar ();
			transparentar ();
			break;
		default:
			break;
		}
	}
		
	public void cambiarColor(){
		if (permitirColor) {
			permitirColor = false;
			ObjectColor color = traeColor ();

			SpriteRenderer sprtRender;
			sprtRender = GetComponent<SpriteRenderer> ();
			sprtRender.color = new Color(color.getR(),color.getG(),color.getB(),color.getA());
		}
	}

	private ObjectColor traeColor(){
		ObjectColor color = new ObjectColor();
		switch(escena){
		case Constantes.esc_test:
			color = TestController.instance.getColor ();
			break;
		case Constantes.esc_home:
			color = FireBaseDAO.instance.getMascotaDAO ().getColor ();
			break;
		default:
			break;
		}

		return color;
	}

	public void transparentar(){
		if(permitir){
			permitir = false;
			SpriteRenderer sprtRender;
			sprtRender = GetComponent<SpriteRenderer> ();
			sprtRender.color = new Color(sprtRender.color.r,sprtRender.color.g,sprtRender.color.b,valor);
		}
	}

	public void oscilar(){
		if (oscilarArriba) {
			Vector2 destino = new Vector2 (posXini, posYini + longOsci);
			float velocidadDeambular = Time.deltaTime * velOsci;
			transform.position = Vector3.MoveTowards (transform.position, destino, velocidadDeambular);
			if(!(transform.position.y < destino.y)){
				oscilarArriba = false;
			}
		} else {
			Vector2 destino = new Vector2 (posXini, posYini - longOsci);
			float velocidadDeambular = Time.deltaTime * velOsci;
			transform.position = Vector3.MoveTowards (transform.position, destino, velocidadDeambular);
			if(!(transform.position.y > destino.y)){
				oscilarArriba = true;
			}
		}
	}
}

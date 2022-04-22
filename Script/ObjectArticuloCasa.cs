using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectArticuloCasa {

	public string nombre;
	public string tipo;
	public float posX;
	public float posY;

	public ObjectArticuloCasa(){
	}

	public void setNombre(string nuevoNombre){
		nombre = nombre;
	}

	public string getNombre(){
		return nombre;
	}

	public void setTipo(string nuevoTipo){
		tipo = nuevoTipo;
	}

	public string getTipo(){
		return tipo;
	}

	public void setPosX(float nuevaPosX){
		posX = nuevaPosX;
	}

	public float getPosX(){
		return posX;
	}

	public void setPosY(float nuevaPosY){
		posY = nuevaPosY;
	}

	public float getPosY(){
		return posY;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["nombre"] = nombre;
		result["tipo"] = tipo;
		result["posX"] = posX;
		result["posY"] = posY;
		return result;
	}
}

using System.Collections.Generic;
using UnityEngine;

public class MascotaObject {

	public int nivel;
	public string nombre;

	public MascotaObject(){
	}

	public void setNivel(int nuevoNivel){
		nivel = nuevoNivel;
	}

	public int getNivel(){
		return nivel;
	}

	public void setNombre(string nuevoNombre){
		nombre = nuevoNombre;
	}

	public string getNombre(){
		return nombre;
	}


	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["nivel"] = nivel;
		result["nombre"] = nombre;
		return result;
	}

}

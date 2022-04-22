using System.Collections.Generic;
using UnityEngine;


public class ObjectUsuario {

	public string idUsuario;
	public string nombre;
	public int cantMascota;
	public bool testRealizado;

	public ObjectUsuario(){
	}

	public void setTestRealizado(bool realizado){
		testRealizado = realizado;
	}

	public bool getTestRealizado(){
		return testRealizado;
	}

	public void setIdUsuario(string nuevoID){
		idUsuario = nuevoID;
	}

	public string getIdUsuario(){
		return idUsuario;
	}

	public void setNombre(string nuevoNombre){
		nombre = nuevoNombre;
	}

	public string getNombre(){
		return nombre;
	}

	public void setCantidad(int nuevaCantidad){
		cantMascota = nuevaCantidad;
	}

	public int getCantidad(){
		return cantMascota;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["testRealizado"] = testRealizado;
		result["idUsuario"] = idUsuario;
		result["nombre"] = nombre;
		result["cantMascota"] = cantMascota;
		return result;
	}

}

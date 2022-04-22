using System.Collections.Generic;
using UnityEngine;


public class ObjectMascota{

	public string rol;
	public string clase;
	public string elemento;
	public string nombre;
	public ObjectColor color;
	public int tipo;
	public int nivel;
	public int numero;

	public ObjectMascota(){
	}

	public void setRol(string nuevoRol){
		rol = nuevoRol;
	}

	public string getRol(){
		return rol;
	}

	public void setClase(string nuevaClase){
		clase = nuevaClase;
	}

	public string getClase(){
		return clase;
	}
	public void setElemento( string nuevoelemento){
		elemento = nuevoelemento;
	}

	public string getElemento(){
		return elemento;
	}

	public void setNumero(int nuevoNumero){
		numero = nuevoNumero;
	}

	public int getNumero(){
		return numero;
	}

	public void setNombre(string nuevoNombre){
		nombre = nuevoNombre;
	}

	public string getNombre(){
		return nombre;
	}

	public void setColor(ObjectColor nuevoColor){
		color = nuevoColor;
	}

	public ObjectColor getColor(){
		return color;
	}

	public void setTipo(int nuevoTipo){
		tipo = nuevoTipo;
	}

	public int getTipo(){
		return tipo;
	}

	public void setNivel(int nuevoNivel){
		nivel = nuevoNivel;
	}

	public int getNivel(){
		return nivel;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["rol"] = rol;
		result["clase"] = clase;
		result["elemento"] = elemento;
		result["nombre"] = nombre;
		result["color"] = color;
		result["tipo"] = tipo;
		result["nivel"] = nivel;
		return result;
	}



}

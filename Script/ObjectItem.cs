using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectItem {

	public string id;
	public string lugarEquipable;
	public List<ObjectStatBonus> statBonus;
	public string nombre;
	public int cantidad;
	public int rareza;
	public int nivelEquipable;
	public int masCuanto;
	public bool equipable;

	public ObjectItem(){
	}

	public void setId(string nuevoId){
		id = nuevoId;
	}

	public string getId(){
		return id;
	}

	public void setLugarEquipable(string nuevoLugarEquipable){
		lugarEquipable = nuevoLugarEquipable;
	}

	public string getLugarEquipable(){
		return lugarEquipable;
	}

	public void setStatBonus(List<ObjectStatBonus> nuevoStatBonus){
		statBonus = nuevoStatBonus;
	}

	public List<ObjectStatBonus> getStatBonus(){
		return statBonus;
	}

	public void setNombre(string nuevoNombre){
		nombre = nuevoNombre;
	}

	public string getNombre(){
		return nombre;
	}

	public void setCantidad(int nuevaCantidad){
		cantidad = nuevaCantidad;
	}

	public int getCantidad(){
		return cantidad;
	}

	public void setRareza(int nuevaRareza){
		rareza = nuevaRareza;
	}

	public int getRareza(){
		return rareza;
	}

	public void setNivelEquipable(int nuevoNivelEquipable){
		nivelEquipable = nuevoNivelEquipable;
	}

	public int getNivelEquipable(){
		return nivelEquipable;
	}

	public void setMasCuanto(int nuevoMasCuanto){
		masCuanto = nuevoMasCuanto;
	}

	public int getMasCuanto(){
		return masCuanto;
	}

	public void setEquipable(bool nuevoEquipable){
		equipable = nuevoEquipable;
	}

	public bool getEquipable(){
		return equipable;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["id"] = id;
		result["lugarEquipable"] = lugarEquipable;
		result["statBonus"] = statBonus;
		result["nombre"] = nombre;
		result["cantidad"] = cantidad;
		result["rareza"] = rareza;
		result["nivelEquipable"] = nivelEquipable;
		result["masCuanto"] = masCuanto;
		result["equipable"] = equipable;
		return result;
	}

}

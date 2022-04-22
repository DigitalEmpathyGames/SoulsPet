using System.Collections.Generic;
using UnityEngine;

public class ObjectInventarioMascota {

	public int cantMax;
	public List<ObjectItem> inventario;


	public ObjectInventarioMascota(){
	}

	public void setCantMax(int nuevaCantMax){
		cantMax = nuevaCantMax;
	}

	public int getCantMax(){
		return cantMax;
	}

	public void setInventario(List<ObjectItem> nuevoInventario){
		inventario = nuevoInventario;
	}

	public List<ObjectItem> getInventario(){
		return inventario;
	}
	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["cantMax"] = cantMax;
		result["inventario"] = inventario;
		return result;
	}



}

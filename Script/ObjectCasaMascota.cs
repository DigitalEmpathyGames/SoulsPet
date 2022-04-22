using System.Collections.Generic;
using UnityEngine;

public class ObjectCasaMascota {

	public int cantMax;
	public List<ObjectArticuloCasa> articulos;

	public ObjectCasaMascota(){
	}

	public void setCantMax(int nuevaCantMax){
		cantMax = nuevaCantMax;
	}

	public int getCantMax(){
		return cantMax;
	}

	public void setArticulos(List<ObjectArticuloCasa> nuevosArticulos){
		articulos = nuevosArticulos;
	}

	public List<ObjectArticuloCasa> getArticulos(){
		return articulos;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["cantMax"] = cantMax;
		result["articulos"] = articulos;
		return result;
	}
}

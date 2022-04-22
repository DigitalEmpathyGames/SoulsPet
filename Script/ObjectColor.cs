using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectColor{

	public float r;
	public float g;
	public float b;
	public float a;

	public ObjectColor(){
	}

	public ObjectColor(float nR,float nG, float nB, float nA){
		r = nR;
		g = nG;
		b = nB;
		a = nA;
	}

	public void setR(float tone){
		r = tone;
	}
	public void setG(float tone){
		g = tone;
	}
	public void setB(float tone){
		b = tone;
	}
	public void setA(float tone){
		a = tone;
	}

	public float getR(){
		return r;
	}
	public float getG(){
		return g;
	}
	public float getB(){
		return b;
	}
	public float getA(){
		return a;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["r"] = r;
		result["g"] = g;
		result["b"] = b;
		result["a"] = a;
		return result;
	}

}

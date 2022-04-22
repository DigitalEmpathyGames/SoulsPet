using System.Collections.Generic;
using UnityEngine;

public class ObjectStatMascota {

	public int fuerza;
	public int agilidad;
	public int vitalidad;
	public int inteligencia;
	public int destreza;
	public int defensa;
	public int suerte;
	public int actXtra;
	public int nxtXtra;
	public int actFrz;
	public int nxtFrz;
	public int actAgi;
	public int nxtAgi;
	public int actVit;
	public int nxtVit;
	public int actInt;
	public int nxtInt;
	public int actDes;
	public int nxtDes;



	public ObjectStatMascota(){
	}

	public void setFuerza(int nuevaFuerza){
		fuerza = nuevaFuerza;
	}

	public int getFuerza(){
		return fuerza;
	}

	public void setAgilidad(int nuevaAgilidad){
		agilidad = nuevaAgilidad;
	}

	public int getAgilidad(){
		return agilidad;
	}

	public void setVitalidad(int nuevaVitalidad){
		vitalidad = nuevaVitalidad;
	}

	public int getVitalidad(){
		return vitalidad;
	}

	public void setInteligencia(int nuevaInteligencia){
		inteligencia = nuevaInteligencia;
	}

	public int getInteligencia(){
		return inteligencia;
	}

	public void setDestreza(int nuevaDestreza){
		destreza = nuevaDestreza;
	}

	public int getDestreza(){
		return destreza;
	}

	public void setSuerte(int nuevasuerte){
		suerte = nuevasuerte;
	}

	public int getSuerte(){
		return suerte;
	}

	public void setActXtra(int nuevosXtra){
		actXtra = nuevosXtra;
		
	}

	public int getActXtra(){
		return actXtra;
	}

	public void setNxtXtra(int valor){
		nxtXtra = valor;
	}

	public int getNxtXtra(){
		return nxtXtra;
	}

	public void setActFrz(int valor){
		actFrz = valor;
	}

	public int getActFrz(){
		return actFrz;
	}

	public void setNxtFrz(int valor){
		nxtFrz = valor;
	}

	public int getNxtFrz(){
		return nxtFrz;
	}

	public void setActAgi(int valor){
		actAgi = valor;
	}

	public int getActAgi(){
		return actAgi;
	}

	public void setNxtAgi(int valor){
		nxtAgi = valor;
	}

	public int getNxtAgi(){
		return nxtAgi;
	}

	public void setActVit(int valor){
		actVit = valor;
	}

	public int getActVit(){
		return actVit;
	}

	public void setNxtVit(int valor){
		nxtVit = valor;
	}

	public int getNxtVit(){
		return nxtVit;
	}


	public void setActInt(int valor){
		actInt = valor;
	}

	public int getActInt(){
		return actInt;
	}

	public void setNxtInt(int valor){
		nxtInt = valor;
	}

	public int getNxtInt(){
		return nxtInt;
	}

	public void setActDes(int valor){
		actDes = valor;
	}

	public int getActDes(){
		return actDes;
	}

	public void setNxtDes(int valor){
		nxtDes = valor;
	}

	public int getNxtDes(){
		return nxtDes;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["fuerza"] = fuerza;
		result["agilidad"] = agilidad;
		result["vitalidad"] = vitalidad;
		result["inteligencia"] = inteligencia;
		result["destreza"] = destreza;
		result["suerte"] = suerte;
		result["actXtra"] = actXtra;
		result["nxtXtra"] = nxtXtra;
		result["actFrz"] = actFrz;
		result["nxtFrz"] = nxtFrz;
		result["actAgi"] = actAgi;
		result["nxtAgi"] = nxtAgi;
		result["actVit"] = actVit;
		result["nxtVit"] = nxtVit;
		result["actInt"] = actInt;
		result["nxtInt"] = nxtInt;
		result["actDes"] = actDes;
		result["nxtDes"] = nxtDes;
		return result;
	}
}
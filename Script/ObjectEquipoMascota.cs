using System.Collections.Generic;
using UnityEngine;

public class ObjectEquipoMascota {

	public ObjectItem cabeza;
	public ObjectItem ojos;
	public ObjectItem boca;
	public ObjectItem under;
	public ObjectItem top;
	public ObjectItem pantalon;
	public ObjectItem zapato;
	public ObjectItem manoDerecha;
	public ObjectItem manoIzquierda;

	public ObjectEquipoMascota(){
	}

	public void setCabeza(ObjectItem nuevaCabeza){
		cabeza = nuevaCabeza;
	}

	public ObjectItem getCabeza(){
		return cabeza;
	}

	public void setOjos( ObjectItem nuevosOjos){
		ojos = nuevosOjos;
	}

	public ObjectItem getOjos(){
		return ojos;
	}

	public void setBoca( ObjectItem nuevaBoca){
		boca = nuevaBoca;
	}

	public ObjectItem getBoca(){
		return boca;
	}

	public void setTop(ObjectItem nuevoTop){
		top = nuevoTop;
	}

	public ObjectItem getTop(){
		return top;
	}

	public void setUnder(ObjectItem nuevoUnder){
		under = nuevoUnder;
	}

	public ObjectItem getUnder(){
		return under;
	}

	public void setPantalon(ObjectItem nuevoPantalon){
		pantalon = nuevoPantalon;
	}

	public ObjectItem getPantalon(){
		return pantalon;
	}

	public void setZapato(ObjectItem nuevoZapato){
		zapato = nuevoZapato;
	}

	public ObjectItem getZapato(){
		return zapato;
	}

	public void setManoIzquierda(ObjectItem nuevaManoizquierda){
		manoIzquierda = nuevaManoizquierda;
	}

	public ObjectItem getManoIzquierda(){
		return manoIzquierda;
	}

	public void setManoDerecha(ObjectItem nuevaManoDerecha){
		manoDerecha = nuevaManoDerecha;
	}

	public ObjectItem getManoDerecha(){
		return manoDerecha;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["cabeza"] = cabeza;
		result["ojos"] = ojos;
		result["boca"] = boca;
		result["under"] = under;
		result["top"] = top;
		result["pantalon"] = pantalon;
		result["zapato"] = zapato;
		result["manoDerecha"] = manoDerecha;
		result["manoIzquierda"] = manoIzquierda;
		return result;
	}

}

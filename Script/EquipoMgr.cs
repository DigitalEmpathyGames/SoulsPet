using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipoMgr : MonoBehaviour {

	public static EquipoMgr instance = null;

	private Sprite colorRareza;

	public Image rarezaMD;
	public Image itemMD;
	public Image rarezaMI;
	public Image itemMI;
	public Image rarezaGo;
	public Image itemGo;
	public Image rarezaOj;
	public Image itemOj;
	public Image rarezaBo;
	public Image itemBo;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	void Start () {
		colorRareza = Utils.instance.traerSprite (Constantes.fldrItems + Constantes.imgRareza);
	}

	private void setearItem(Image rareza, Image imgItem,ObjectItem itemObj, Sprite foto){
		rareza.gameObject.SetActive (true);
		rareza.sprite = colorRareza;
		imgItem.sprite = foto;
		FireBaseDatabase.instance.guardarEquipo();
	}

	public void equiparItem(ObjectItem item, Sprite foto){
		ObjectEquipoMascota equipEn = FireBaseDAO.instance.getEquipoDAO ();
		switch(item.getLugarEquipable()){
		case Constantes.manoDerecha:
			equipEn.setManoDerecha (item);
			setearItem (rarezaMD,itemMD, item, foto);
			break;
		case Constantes.manoIzquierda:
			equipEn.setManoIzquierda(item);
			setearItem (rarezaMI,itemMI, item, foto);
			break;
		case Constantes.cabeza:
			equipEn.setCabeza (item);
			setearItem (rarezaGo,itemGo, item, foto);
			break;
		case Constantes.ojos:
			equipEn.setOjos (item);
			setearItem (rarezaOj,itemOj, item, foto);
			break;
		case Constantes.boca:
			equipEn.setBoca (item);
			setearItem (rarezaBo,itemBo, item, foto);
			break;
		default:
			break;
		}
	}

	public void dibujarEquipo(ObjectEquipoMascota equipo){
		Sprite foto;
		ObjectItem eqpCab = equipo.getCabeza ();
		ObjectItem eqpOjo = equipo.getOjos ();
		ObjectItem eqpBca = equipo.getCabeza ();
		ObjectItem eqpMD = equipo.getManoDerecha();
		ObjectItem eqpMI = equipo.getManoIzquierda ();
		if(eqpCab.getCantidad() > 0){
			foto = Utils.instance.traerSprite (Constantes.fldrItems + eqpCab.getId());
			dibujarItemEquipo (eqpCab, foto);
		}
		if(eqpOjo.getCantidad() > 0){
			foto = Utils.instance.traerSprite (Constantes.fldrItems + eqpOjo.getId());
			dibujarItemEquipo (eqpOjo, foto);
		}
		if(eqpBca.getCantidad() > 0){
			foto = Utils.instance.traerSprite (Constantes.fldrItems + eqpBca.getId());
			dibujarItemEquipo (eqpBca, foto);
		}
		if(eqpMD.getCantidad() > 0){
			foto = Utils.instance.traerSprite (Constantes.fldrItems + eqpMD.getId());
			dibujarItemEquipo (eqpMD, foto);
		}
		if(eqpMI.getCantidad() > 0){
			foto = Utils.instance.traerSprite (Constantes.fldrItems + eqpMI.getId());
			dibujarItemEquipo (eqpMI, foto);
		}

	}

	private void dibujarItemEquipo(ObjectItem item, Sprite foto){
		switch(item.getLugarEquipable()){
		case Constantes.manoDerecha:
			setearItem (rarezaMD,itemMD, item, foto);
			break;
		case Constantes.manoIzquierda:
			setearItem (rarezaMI,itemMI, item, foto);
			break;
		case Constantes.cabeza:
			setearItem (rarezaGo,itemGo, item, foto);
			break;
		case Constantes.ojos:
			setearItem (rarezaOj,itemOj, item, foto);
			break;
		case Constantes.boca:
			setearItem (rarezaBo,itemBo, item, foto);
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}

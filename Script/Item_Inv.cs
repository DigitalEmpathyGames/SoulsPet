using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Inv : MonoBehaviour {

	public Text txtNombre;
	public Text txtCantidad;
	public Image foto;
	public GameObject fotoRareza;
	public ObjectItem item;
	public Button btnEquipar;

	void Start () {
		item = InventarioMgr.instance.getInventarioMap () [transform.name.Replace ("(Clone)", "")];
		setNombre (item);
		setCantidad (item);
		setFoto (item);
		activarEquipar (item);
	}

	// Update is called once per frame
	void Update () {

	}

	public void activarEquipar(ObjectItem item){
		if(!item.getEquipable()){
			btnEquipar.gameObject.SetActive (false);
		}
	}

	public void equiparItem(){
		EquipoMgr.instance.equiparItem (item, foto.sprite);
	}

	public void botarItem(){
		InventarioMgr.instance.botarItem(item);
	}

	private void setNombre(ObjectItem item){
		string nomItem = item.getNombre();
		int masCuanto = item.getMasCuanto ();
		if( masCuanto > 0){
			nomItem = nomItem + Constantes.simbMasCuanto + masCuanto;
		}
		txtNombre.text = nomItem;
	}
	private void setCantidad (ObjectItem item){
		int cantidad = item.getCantidad ();
		txtCantidad.text = Constantes.simbCantidad + cantidad; 
	}

	private void setFoto (ObjectItem item){
		foto.sprite = Utils.instance.traerSprite (Constantes.fldrItems + item.getId());
	}


}

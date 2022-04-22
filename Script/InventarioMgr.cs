using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioMgr : MonoBehaviour {

	public static InventarioMgr instance = null;
	public GameObject content;
	public GameObject inptCantidad;

	private bool activado = false;
	private bool cargarItems = true;
	private float sepItems = Constantes.sepItems;
	private float altItem = Constantes.altItem;
	private Dictionary<string, ObjectItem> inventarioMap = new Dictionary<string, ObjectItem>();
	private ObjectItem itemBotar;
	private ObjectInventarioMascota inventario;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(activado){
			actualizarItems ();
		}
	}


	private void dibujarInventario(){
		lmprItems ();
		sizeCntndr ();
		agregarItems ();
		mostrarItems ();
	}

	private void lmprItems(){
		int items = content.transform.childCount;
		for(int i = 0;i < items;i++){
			GameObject.Destroy(content.transform.GetChild (i).gameObject);
		}
	}

	private void mostrarItems(){
		foreach(KeyValuePair<string, ObjectItem> itemMap in inventarioMap){
			ObjectItem item = itemMap.Value;
			GameObject itemGO = Utils.instance.traerGameObject (Constantes.nomObjInv);
			itemGO.transform.name = item.getId();
			GameObject itemDin = Instantiate (itemGO, content.transform.position, Quaternion.identity);
			itemDin.transform.SetParent (content.transform,false);
		}
			
	}

	private void sizeCntndr(){
		RectTransform rt = content.GetComponent<RectTransform> ();
		int items = FireBaseDAO.instance.getInventarioDAO().getInventario().Count;
		float altContent =  (float)items*(altItem + sepItems);
		rt.sizeDelta = new Vector2(0,altContent);
	}

	private void agregarItems(){
		inventario = FireBaseDAO.instance.getInventarioDAO ();
		List<ObjectItem> items = inventario.getInventario ();
		int cantMax = inventario.getCantMax ();
		for(int i = 0;i<items.Count;i++){
			if (cantMax > i) {
				inventarioMap [items [i].getId ()] = items [i];
			} 

		}
	}

	private void actualizarItems(){
		if (cargarItems) {
			cargarItems = false;
			dibujarInventario ();
		} else {
			
		}
	}

	private void descontarCantidad(string cantidad){
		int canInt = int.Parse (cantidad);
		int nvaCnt = itemBotar.getCantidad () - canInt;
		if (nvaCnt > 0) {
			itemBotar.setCantidad (nvaCnt);
			inventarioMap[itemBotar.getId()] = itemBotar;
		} else {
			inventarioMap.Remove (itemBotar.getId());
		}
		cargarItems = true;
	}

	private void actlzrInvtr(){
		List<ObjectItem> items = new List<ObjectItem> ();
		foreach(KeyValuePair<string, ObjectItem> itemMap in inventarioMap){
			items.Add (itemMap.Value);
		}
		ObjectInventarioMascota nuevoInventario = new ObjectInventarioMascota ();
		nuevoInventario.setCantMax (inventario.getCantMax());
		nuevoInventario.setInventario (items);
		FireBaseDAO.instance.setInventarioDAO (nuevoInventario);
	}

	public void activar(bool permiso){
		activado = permiso;
	}



	public Dictionary<string, ObjectItem> getInventarioMap(){
		return inventarioMap;
	}

	public void botarItem (ObjectItem item){
		inptCantidad.SetActive (true);
		itemBotar = item;
	}

	public void aceptarCantidad(string cantidad){
		Debug.Log (cantidad);
		if (cantidad.Length > 0) {
			descontarCantidad (cantidad);
			actlzrInvtr ();
		}
		inptCantidad.SetActive (false);
	}



}

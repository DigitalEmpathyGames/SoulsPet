using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseDAO : MonoBehaviour {

	public static FireBaseDAO instance = null;

	private ObjectInventarioMascota inventarioDAO = null;
	private ObjectEquipoMascota equipoDAO = null;
	private ObjectMascota mascotaDAO = null;
	private ObjectStatMascota statDAO = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	public void setInventarioDAO(ObjectInventarioMascota nuevoInventario){
		inventarioDAO = nuevoInventario;
	}

	public void setStatDAO(ObjectStatMascota stat){
		statDAO = stat;
	}

	public void setMascotaDAO(ObjectMascota mascota){
		mascotaDAO = mascota;
	}

	public void setEquipoDAO(ObjectEquipoMascota equipo){
		equipoDAO = equipo;
	}

	public ObjectInventarioMascota getInventarioDAO(){
		return inventarioDAO;
	}

	public ObjectEquipoMascota getEquipoDAO(){
		return equipoDAO;
	}

	public ObjectMascota getMascotaDAO(){
		return mascotaDAO;
	}

	public ObjectStatMascota getStatDAO(){
		return statDAO;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}

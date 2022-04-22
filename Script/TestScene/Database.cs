using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

using System.Threading.Tasks;



public class Database : MonoBehaviour {

	public static Database instance = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mascotas-9341a.firebaseio.com/");
	}
		
	public void insertarTest(ObjectUsuario usuario, ObjectMascota mascota, ObjectStatMascota stat){
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		string usuarioJSon = JsonUtility.ToJson (usuario);
		string mascotaJSon = JsonUtility.ToJson (mascota);
		string statMascotaJSon = JsonUtility.ToJson (stat);
		string idUsuario;
		int numeroMascota;
		//Trigear lo necesario que haya que agregarle
		idUsuario = usuario.getIdUsuario ();
		numeroMascota = mascota.getNumero ();
		reference.Child (Constantes.usuarios + Constantes.separador + idUsuario + Constantes.separador + Constantes.datos).SetRawJsonValueAsync (usuarioJSon);
		reference.Child (Constantes.usuarios + Constantes.separador + idUsuario + Constantes.separador + Constantes.mascota).SetRawJsonValueAsync (mascotaJSon);
		reference.Child (Constantes.usuarios + Constantes.separador + idUsuario + Constantes.separador + Constantes.stat).SetRawJsonValueAsync (statMascotaJSon);
	}
}

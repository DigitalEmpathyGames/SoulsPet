using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

using System.Threading.Tasks;

using UnityEngine.UI;

public class FireBaseDatabase : MonoBehaviour {

	static string idusuario = "Usuario_4513hasdtu";
	DatabaseReference reference;
	public static FireBaseDatabase instance = null;
	private bool oneTime = true;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}


	void Start() {
		if(oneTime){
			oneTime = false;
			// Set this before calling into the realtime database.
			FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mascotas-9341a.firebaseio.com/");
			reference = FirebaseDatabase.DefaultInstance.RootReference;
			// Get the root reference location of the database.
			cargarMascota();
			cargarItems();
			cargarStats ();
			cargarEquipo ();
		}


	}

	void Update() {
		
	}

	private void cargarEquipo(){
		ObjectEquipoMascota equipo = FireBaseDAO.instance.getEquipoDAO ();
		obtenerEquipo (equipo);
	}

	private void cargarMascota(){
		Debug.Log ("Esto creo se llama 1 vz");
		ObjectMascota mascota = FireBaseDAO.instance.getMascotaDAO ();
		obtenerMascota (mascota);

	}

	private void cargarStats(){
		ObjectStatMascota stat = FireBaseDAO.instance.getStatDAO ();
		obtenerStat (stat);
	}

	private void cargarItems(){
		ObjectInventarioMascota inventario = FireBaseDAO.instance.getInventarioDAO ();
		obtenerItems (inventario);
	}

	private void obtenerEquipo(ObjectEquipoMascota equipo){
		string loc = Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador + Constantes.equipo;
		FirebaseDatabase.DefaultInstance.GetReference (loc).GetValueAsync ()
			.ContinueWith (
				task => {
					if (task.IsFaulted) {
						//ha fallado
					}else if (task.IsCompleted) {
						DataSnapshot snapshot = task.Result;
						equipo = JsonUtility.FromJson<ObjectEquipoMascota>(snapshot.GetRawJsonValue());
						FireBaseDAO.instance.setEquipoDAO(equipo);
						if(equipo != null){
							dibujarEquipo(equipo);
						}else{
							Debug.Log("No encontré referencia de equipo");
						}

					}else{
						//No se completó
					}
				}
			);
	}

	private void dibujarEquipo(ObjectEquipoMascota equipo){
		EquipoMgr.instance.dibujarEquipo (equipo);
	}

	private void obtenerMascota(ObjectMascota mascota){
		Debug.Log ("Acá probando cuantas veces blablabla");
		string loc = Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador+ Constantes.mascota;
		FirebaseDatabase.DefaultInstance.GetReference (loc).GetValueAsync ()
			.ContinueWith (
				task => {
					if (task.IsFaulted) {
						//ha fallado
					}else if (task.IsCompleted) {
						DataSnapshot snapshot = task.Result;
						mascota = JsonUtility.FromJson<ObjectMascota>(snapshot.GetRawJsonValue());
						FireBaseDAO.instance.setMascotaDAO(mascota);
						if(mascota != null){
							StatMgr.instance.activar (true);
							Movilidad.instance.cargarMascota(mascota);
						}else{
							Debug.Log("No encontré referencia de mascota");
						}

					}else{
						//No se completó
					}
				}
			);
	}

	private void obtenerItems (ObjectInventarioMascota inventario){
		string loc = Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador+ Constantes.inventario;
		FirebaseDatabase.DefaultInstance.GetReference (loc).GetValueAsync ()
			.ContinueWith (
				task => {
					if (task.IsFaulted) {
						//ha fallado
					}else if (task.IsCompleted) {
						DataSnapshot snapshot = task.Result;
						inventario = JsonUtility.FromJson<ObjectInventarioMascota>(snapshot.GetRawJsonValue());
						FireBaseDAO.instance.setInventarioDAO(inventario);
						if(inventario != null){
							InventarioMgr.instance.activar(true);
						}else{
							Debug.Log("No encontré referencia de inventario");
						}

					}else{
						//No se completó
					}
				}
			);
	}

	private void obtenerStat(ObjectStatMascota stat){
		string loc = Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador + Constantes.stat;
		FirebaseDatabase.DefaultInstance.GetReference (loc).GetValueAsync ()
			.ContinueWith (
				task => {
					if (task.IsFaulted) {
						//ha fallado
					}else if (task.IsCompleted) {
						DataSnapshot snapshot = task.Result;
						stat = JsonUtility.FromJson<ObjectStatMascota>(snapshot.GetRawJsonValue());
						FireBaseDAO.instance.setStatDAO(stat);
						if(stat != null){
							
						}else{
							Debug.Log("No encontré referencia de stat");
						}

					}else{
						//No se completó
					}
				}
			);
	}

	public void probarLoad(){
		FirebaseDatabase.DefaultInstance.GetReference ("niveles/2").GetValueAsync ()
			.ContinueWith (
				task => {
					Debug.Log("llegue de buscar");
					if (task.IsFaulted) {
						//ha fallado
					}else if (task.IsCompleted) {
						DataSnapshot snapshot = task.Result;
						Debug.Log(task.Result.GetRawJsonValue());
						ObjectNivel nivel = new ObjectNivel();
						nivel = JsonUtility.FromJson<ObjectNivel>(snapshot.GetRawJsonValue());
						if(nivel != null){
							Debug.Log( "exp necesaria = " + nivel.getExp() );
						}else{
							Debug.Log("No encontré nada");
						}
							
					}else{
						//No se completó
					}
				}
		);
		
	}

	public void probarEditar(){
		MascotaObject mascota = new MascotaObject ();
		mascota.setNivel (5);
		mascota.setNombre ("holaGato");
		Dictionary<string, object> valoresMascota = mascota.ToDictionary();
		Dictionary<string, object> actualizadorMascota = new Dictionary<string, object>();
		actualizadorMascota["mascota"] = valoresMascota;
		reference.UpdateChildrenAsync(actualizadorMascota);
	}

	public void probarBorrarElemento(){
		reference.Child ("mascota/nivel").RemoveValueAsync();
	}

	public void guardarItems(){
		ObjectInventarioMascota inventario = FireBaseDAO.instance.getInventarioDAO ();
		string inventarioJSON = JsonUtility.ToJson (inventario);
		reference.Child (Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador+ Constantes.inventario).SetRawJsonValueAsync (inventarioJSON);
	}

	public void guardarMascota(){
		ObjectMascota mascota = FireBaseDAO.instance.getMascotaDAO ();
		string mascotaJSON = JsonUtility.ToJson (mascota);
		reference.Child (Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador+ Constantes.mascota).SetRawJsonValueAsync (mascotaJSON);
	}

	public void guardarEquipo(){
		ObjectEquipoMascota equipo = FireBaseDAO.instance.getEquipoDAO ();
		string equipoJSON = JsonUtility.ToJson (equipo);
		reference.Child (Constantes.usuarios + Constantes.separador + idusuario + Constantes.separador + Constantes.equipo).SetRawJsonValueAsync (equipoJSON);
	}

	public void probarInsertar(){

		Debug.Log ("voy a insertar");
		string IdUsuario = "Usuario_4513hasdtu2";

		ObjectUsuario usuario = new ObjectUsuario ();
		ObjectMascota mascota = new ObjectMascota ();
		ObjectStatMascota statMascota = new ObjectStatMascota ();
		ObjectEquipoMascota equipoMascota = new ObjectEquipoMascota ();
		ObjectInventarioMascota inventarioMascota = new ObjectInventarioMascota ();
		ObjectCasaMascota casaMascota = new ObjectCasaMascota ();

		casaMascota.setCantMax (10);
		List<ObjectArticuloCasa> articulosCasa = new List<ObjectArticuloCasa> ();
		ObjectArticuloCasa articulo = new ObjectArticuloCasa ();
		articulosCasa.Add (articulo);
		casaMascota.setArticulos (articulosCasa);

		string usuarioJSon = JsonUtility.ToJson (usuario);
		string mascotaJSon = JsonUtility.ToJson (mascota);
		string statMascotaJSon = JsonUtility.ToJson (statMascota);
		string equipoMascotaJSon = JsonUtility.ToJson (equipoMascota);
		string inventarioMascotaJSon = JsonUtility.ToJson (inventarioMascota);
		string casaMascotaJSon = JsonUtility.ToJson (casaMascota);



		string articulosCasaJSon = JsonUtility.ToJson (articulosCasa);

		Debug.Log ("usuarioJSon    " + usuarioJSon);
		Debug.Log ("mascotaJSon    " + mascotaJSon);
		Debug.Log ("statMascotaJSon    " + statMascotaJSon);
		Debug.Log ("equipoMascotaJSon    " + equipoMascotaJSon);
		Debug.Log ("inventarioMascotaJSon    " + inventarioMascotaJSon);
		Debug.Log ("casaMascotaJSon    " + casaMascotaJSon);


		Debug.Log ("articulosCasaJSon    " + articulosCasaJSon);
		Debug.Log ("articulosCasa Size    " + articulosCasa.Count);



		reference.Child ("Usuarios/" + IdUsuario + "/Datos").SetRawJsonValueAsync (usuarioJSon);
		reference.Child ("Usuarios/" + IdUsuario + "/Mascota").SetRawJsonValueAsync (mascotaJSon);

		reference.Child ("Usuarios/" + IdUsuario + "/StatMascota").SetRawJsonValueAsync (statMascotaJSon);
		reference.Child ("Usuarios/" + IdUsuario + "/EquipoMascota").SetRawJsonValueAsync (equipoMascotaJSon);
		reference.Child ("Usuarios/" + IdUsuario + "/InventarioMascota").SetRawJsonValueAsync (inventarioMascotaJSon);
		reference.Child ("Usuarios/" + IdUsuario + "/CasaMascota").SetRawJsonValueAsync (casaMascotaJSon);
	}
	

}

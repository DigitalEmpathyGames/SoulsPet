using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMgr : MonoBehaviour {
	private bool crgrMas1 = true;
	private bool activado = false;
	private bool crgrStat1 = true;

	public Text nombre;
	public Text nivel;
	public Text txtFrz;
	public Text txtExpFrz;
	public Text txtInt;
	public Text txtExpInt;
	public Text txtAgi;
	public Text txtExpAgi;
	public Text txtDes;
	public Text txtExpDes;
	public Text txtVit;
	public Text txtExpVit;
	public Text txtExpExt;
	public Image tipo;
	public Image clase;
	public Image rol;
	public Image elemento;
	public Image imgFrz;
	public Image imgInt;
	public Image imgAgi;
	public Image imgDes;
	public Image imgVit;
	public Image imgExt;

	public static StatMgr instance = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activado) {
			if(crgrMas1){
				crgrMas1 = false;
				cargarMascota ();
			}
			if(FireBaseDAO.instance.getStatDAO() != null && crgrStat1){
				crgrStat1 = false;
				cargarStats (FireBaseDAO.instance.getStatDAO());
			}
		}
	}

	private void cargarStats(ObjectStatMascota stat){
		Utils.instance.cambiarTexto (txtFrz,stat.getFuerza ().ToString ());
		Utils.instance.cambiarTexto (txtExpFrz,stat.getActFrz () + Constantes.sprdrSpc + stat.getNxtFrz ());
		Utils.instance.rellenaImage (imgFrz, (float)stat.getActFrz (), (float)stat.getNxtFrz ());

		Utils.instance.cambiarTexto (txtInt,stat.getInteligencia().ToString ());
		Utils.instance.cambiarTexto (txtExpInt,stat.getActInt () + Constantes.sprdrSpc + stat.getNxtInt ());
		Utils.instance.rellenaImage (imgInt, (float)stat.getActInt (), (float)stat.getNxtInt ());

		Utils.instance.cambiarTexto (txtAgi,stat.getAgilidad().ToString ());
		Utils.instance.cambiarTexto (txtExpAgi,stat.getActAgi () + Constantes.sprdrSpc + stat.getNxtAgi ());
		Utils.instance.rellenaImage (imgAgi, (float)stat.getActAgi (), (float)stat.getNxtAgi ());

		Utils.instance.cambiarTexto (txtDes,stat.getDestreza().ToString ());
		Utils.instance.cambiarTexto (txtExpDes,stat.getActDes () + Constantes.sprdrSpc + stat.getNxtDes ());
		Utils.instance.rellenaImage (imgDes, (float)stat.getActDes (), (float)stat.getNxtDes ());

		Utils.instance.cambiarTexto (txtVit,stat.getVitalidad().ToString ());
		Utils.instance.cambiarTexto (txtExpVit,stat.getActVit () + Constantes.sprdrSpc + stat.getNxtVit ());
		Utils.instance.rellenaImage (imgVit, (float)stat.getActVit (), (float)stat.getNxtVit ());

		Utils.instance.cambiarTexto (txtExpExt,stat.getActXtra() + Constantes.sprdrSpc + stat.getNxtXtra());
		Utils.instance.rellenaImage (imgExt, (float)stat.getActXtra (), (float)stat.getNxtXtra ());

	}

	private void cargarMascota(){
		ObjectMascota mascota = FireBaseDAO.instance.getMascotaDAO ();
		nombre.text = mascota.getNombre ();
		nivel.text = mascota.getNivel ().ToString();
		tipo.sprite = Utils.instance.traerSprite ( Constantes.simbolo + Constantes.tipo + mascota.getTipo());
		clase.sprite = Utils.instance.traerSprite (Constantes.simbolo + mascota.getClase ());
		rol.sprite = Utils.instance.traerSprite (Constantes.simbolo + mascota.getRol());
		elemento.sprite = Utils.instance.traerSprite (Constantes.simbolo + mascota.getElemento());
	}

	public void activar(bool permiso){
		activado = permiso;
	}
}

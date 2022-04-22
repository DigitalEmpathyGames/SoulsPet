using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaMgr : MonoBehaviour {

	private bool infoHide = true;
	private float infoHidePos = 200f;
	private float infoShowPos = 0f;

	private bool setHide = true;
	private float setHidePos = 1120f;
	private float setShowPos = 0f;

	private bool invHide = true;
	private float invHidePos = -650f;
	private float invShowPos = 0f;

	private bool statHide = true;
	private float statHidePos = -1080f;
	private float statShowPos = 0f;

	private bool skillHide = true;
	private float skillHidePos = 1120f;
	private float skillShowPos = 0f;
	private float eqpSkillHidePos = -650f;
	private float eqpSkillShowPos = 0f;


	private float velInfo = 15f;
	private float velSet = 30f;
	private float velInv = 20f;
	private float velStat = 30f;

	public GameObject infoBtns;
	public Button infoDesplBtn;

	public GameObject setGroup;
	public GameObject invGroup;
	public GameObject statGroup;
	public GameObject skillGroup;
	public GameObject eqpSkillGroup;


	void Start () {

	}

	void Update () {
		procInfo ();
		procSet ();
		procInv ();
		procStat ();
		procSkill ();
	}

	private void moverCuadroX(RectTransform rt, bool permiso, float hidePos, float showPos, float velocidad){
		Vector2 destino;
		if (permiso) {
			destino = new Vector2 (hidePos, rt.anchoredPosition.y);
		}else{
			destino = new Vector2 (showPos,rt.anchoredPosition.y);
		}
		rt.anchoredPosition = Vector3.MoveTowards (rt.anchoredPosition, destino, velocidad);
	}

	private void moverCuadroY(RectTransform rt, bool permiso, float hidePos, float showPos, float velocidad){
		Vector2 destino;
		if (permiso) {
			destino = new Vector2 (rt.anchoredPosition.x,hidePos);
		}else{
			destino = new Vector2 (rt.anchoredPosition.x,showPos);
		}
		rt.anchoredPosition = Vector3.MoveTowards (rt.anchoredPosition, destino, velocidad);
	}

	private void procSkill(){
		moverCuadroY (skillGroup.GetComponent<RectTransform>(), skillHide, skillHidePos, skillShowPos, velSet);
		moverCuadroY (eqpSkillGroup.GetComponent<RectTransform>(), skillHide, eqpSkillHidePos, eqpSkillShowPos, velInv);
	}

	private void procStat(){
		moverCuadroX (statGroup.GetComponent<RectTransform>(), statHide, statHidePos, statShowPos, velStat);
	}

	private void procInv(){
		moverCuadroY (invGroup.GetComponent<RectTransform>(), invHide, invHidePos, invShowPos, velInv);
	}

	private void procSet(){
		moverCuadroY (setGroup.GetComponent<RectTransform>(), setHide, setHidePos, setShowPos, velSet);
	}

	private void procInfo(){
		moverCuadroX (infoBtns.GetComponent<RectTransform>(), infoHide, infoHidePos, infoShowPos, velInfo);
	}

	public void moverInfo(){
		if (infoHide) {
			infoHide = false;
			infoDesplBtn.image.sprite = Utils.instance.traerSprite ("info_cerrar");
		} else {
			infoHide = true;
			infoDesplBtn.image.sprite = Utils.instance.traerSprite ("info_abrir");
		}
	}

	public void mostrarSet(){
		setHide = false;
		mostrarInv ();
	}

	public void ocultarSet(){
		setHide = true;
		ocultarInv ();
	}

	public void mostrarInv(){
		invHide = false;
	}

	public void ocultarInv(){
		invHide = true;
	}

	public void mostrarStat(){
		statHide = false;
	}

	public void ocultarStat(){
		statHide = true;
	}

	public void mostrarSkill(){
		skillHide = false;
	}

	public void ocultarSkill(){
		skillHide = true;
	}

}

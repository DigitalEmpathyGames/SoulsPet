using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EN : MonoBehaviour {

	public static Test_EN instance = null;

	private string[] preguntas;
	private string[] respuestas;
	void Start () {
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}

		cargarTextos ();
	}

	private void cargarTextos(){
		preguntas = new string[9];
		respuestas = new string[33];

		preguntas [0] = "A bet to eat the biggest sandwitch in town:";
		preguntas [1] = "You get a wound in your hand:";
		preguntas [2] = "Do you usually be concentrated?";
		preguntas [3] = "You lose a little contest:";
		preguntas [4] = "Mission: take biscuit in secret.";
		preguntas [5] = "In a party:";
		preguntas [6] = "Not being able to buy a real dinosaur:";
		preguntas [7] = "Your friend is sad:";
		preguntas [8] = "Prepare a cake:";

		//Respuestas

		respuestas [0] = "Lo intento sin pensarlo.";
		respuestas [1] = "Analizo la situación, la tomo sólo si puedo ganar.";
		respuestas [2] = "¿Puede ser en equipo, verdad?.";


		respuestas [3] = "Pido ayuda, quizá puedan aconsejarme bien.";
		respuestas [4] = "No duele, ya se recupera.";
		respuestas [5] = "Intento asistirla, una bendita, quizá.";


		respuestas [6] = "Puedo poner atención a más de una cosa.";
		respuestas [7] = "Suelo ser muy despistado.";
		respuestas [8] = "Prefiero concentrarme en un punto.";


		respuestas [9] = "'¿Para qué volver a intentarlo?'.";
		respuestas [10] = "'Al menos viví la experiencia de participar'.";
		respuestas [11] = "'Voy a intentarlo hasta ganar'.";

		respuestas [12] = "Espero a que todos se vayan y de forma rápida y segura lo hago.";
		respuestas [13] = "Espero a que todos se vayan, aún así voy con cuidado y sigilo.";
		respuestas [14] = "Con sigilo, no importa si hay alguien, no me verán.";

		respuestas [15] = "Soy el centro de atención.";
		respuestas [16] = "Me gusta quedarme conversando algo interesante.";
		respuestas [17] = "Voy de un lado a otro para estar con la mayoría.";


		respuestas [18] = "Acepto el no poder hacerlo.";
		respuestas [19] = "Me molesta el no poder hacerlo.";
		respuestas [20] = "Busco al menos una alternativa para lograrlo.";
		respuestas [21] = "Trato de buscar una respuesta de porqué no puedo.";
		respuestas [22] = "No es algo que me afecte.";

		respuestas [23] = "Lo consuelo.";
		respuestas [24] = "No es algo que me afecte.";
		respuestas [25] = "Me duele verlo así.";
		respuestas [26] = "Intento ser alegre para ayudarle.";
		respuestas [27] = "Me doy cuenta sin que me lo diga.";

		respuestas [28] = "Trato de que quede muy profesional.";
		respuestas [29] = "Cuido cada detalle, debe ser lindo también.";
		respuestas [30] = "Si veo que va quedando mal, lo convierto en otra cosa.";
		respuestas [31] = "Trato de agregarle un toque personal.";
		respuestas [32] = "Sigo una receta, debería quedar bien.";
	}

	public string obtenerPregunta(int numeroTexto){
		string retorno;
		if (numeroTexto < preguntas.Length && numeroTexto > -1) {
			retorno = preguntas [numeroTexto];
		} else {
			retorno = "";
		}
		return retorno;
	}

	public string obtenerRespuesta(int numeroTexto){
		string retorno;
		if (numeroTexto < respuestas.Length && numeroTexto > -1) {
			retorno = respuestas [numeroTexto];
		} else {
			retorno = "";
		}
		return retorno;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ES : MonoBehaviour {

	public static Test_ES instance = null;

	private string[] preguntas;
	private string[] respuestas;
	private string[] info;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}

		cargarTextos ();
	}

	private void cargarTextos(){
		preguntas = new string[11];
		respuestas = new string[36];
		info = new string[14];

		info [0] = "Gracias por estar acá, a continuación aparecerán preguntas para determinar las características de tu acompañante, responde con sinceridad.";
		info [1] = "Analizando resultados...";
		info [2] = "Ya puedes empezar.";

		info [3] = "Tu rol es Tanque: Pelear en primera liena, sin preocuparte, daño y sanador te ayudarán si lo necesitas.";
		info [5] = "Tu rol es Daño: Busca la mejor oportunidad para rematar al rival, debes estar atento para proteger a los sanadores y apoyar a los tanques.";
		info [4] = "Tu rol es Sanador: Apoyar al equipo, asistirlos cuando sea necesario y atacar cuando tengas oportunidad.";

		info [6] = "Tu Clase es Guerrero: Tu armamento es principalmente de cuerpo a cuerpo.";
		info [7] = "Tu Clase es Arquero: Tu armamento favorece el ataque a distancia.";
		info [8] = "Tu Clase es Mago: Tu arma principal es la magia.";

		info [9] = "Tu elemento es Agua: Favorece a la MADERA y destruye el FUEGO.";
		info [10] = "Tu elemento es Madera: Favorece al FUEGO y destruye la TIERRA.";
		info [11] = "Tu elemento es Fuego: Favorece a la TIERRA y destruye el METAL.";
		info [12] = "Tu elemento es Tierra: Favorece al METAL y destruye al AGUA.";
		info [13] = "Tu elemento es Metal: Favorece al AGUA y destruye la MADERA.";


		preguntas [0] = "Ante la apuesta de comer el sandwich más grande del pueblo:";
		preguntas [1] = "Te haces una herida en la mano:";
		preguntas [2] = "¿Sueles ser concentrado?";
		preguntas [3] = "Pierdes un pequeño concurso:";
		preguntas [4] = "Misión: tomar galleta en secreto.";
		preguntas [5] = "En una fiesta:";
		preguntas [6] = "No poder comprar un dinosaurio de verdad:";
		preguntas [7] = "Tu amigo está triste:";
		preguntas [8] = "Preparar un pastel:";
		preguntas [9] = "¿Color favorito?";
		preguntas [10] = "Selecciona a tu compañero";

		TestController.instance.setCantPregntas (preguntas.Length);


		respuestas [0] = "Lo intento sin pensarlo, podría ganar."; 
		respuestas [1] = "Analizo la situación, la tomo sólo si puedo ganar."; 
		respuestas [2] = "¿Puede ser en equipo, verdad?."; 


		respuestas [3] = "Pido ayuda, quizá puedan aconsejarme bien."; 
		respuestas [4] = "No duele, ya se recupera.";
		respuestas [5] = "Intento asistirla, una bendita, quizá."; 


		respuestas [6] = "Prefiero concentrarme en un punto.";
		respuestas [7] = "Puedo poner atención a más de una cosa.";
		respuestas [8] = "Suelo ser muy despistado.";




		respuestas [9] = "'¿Para qué volver a intentarlo?'."; 
		respuestas [10] = "'Al menos viví la experiencia de participar'."; 
		respuestas [11] = "'Voy a intentarlo hasta ganar'."; 

		respuestas [12] = "Espero a que todos se vayan y de forma rápida y segura lo hago."; 
		respuestas [13] = "Espero a que todos se vayan, aún así voy con cuidado y sigilo."; 
		respuestas [14] = "Con sigilo, no importa si hay alguien, no me verán."; 

		respuestas [15] = "Soy el centro de atención."; 
		respuestas [16] = "Voy de un lado a otro para estar con la mayoría.";
		respuestas [17] = "Me gusta quedarme conversando algo interesante."; 



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

		respuestas [33] = "Elegir:";
		respuestas [34] = "Siguiente.";
		respuestas [35] = "Terminar.";
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

	public string obtenerInfo(int numeroTexto){
		string retorno;
		if (numeroTexto < info.Length && numeroTexto > -1) {
			retorno = info [numeroTexto];
		} else {
			retorno = "";
		}
		return retorno;
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuOptions : MonoBehaviour
{
    // Declaramos las variables públicas para los botones, los marcos y las piezas t que se moverán
    //--botones
    public Button boton15x15;
    public Button boton20x20;
    //--marcos
    public GameObject Marco15x15;
    public GameObject Marco20x20;
    //--piezas
    public GameObject pieza1;
    public GameObject pieza2;
    public GameObject pieza3;
    public GameObject pieza4;
    
    //--texto
    // Declaramos la variable publica para el texto del temporizador como text textmashpro
    public Text textoTemporizador;
    //Declaramos la variable publica para el texto del mensaje de seleccion de marco
    public Text textoSeleccionMarco;
    // Declaramos la variable publica para el texto de victoria
    public Text textoVictoria;
    // Declaramos la variable publica para el texto de intentalo de nuevo
    public Text textoIntentaDeNuevo;
    // Declaramos la variable privada para el tiempo transcurrido
    private float tiempoTranscurrido;
    private float transcursoTiempo;
    void Start()
    {
        
        //darle setactive false a los textos
        textoVictoria.gameObject.SetActive(false);
        textoIntentaDeNuevo.gameObject.SetActive(false);
        // Asigna los métodos a los botones si son presionados
        boton15x15.onClick.AddListener(HacerVisible15x15);
        boton20x20.onClick.AddListener(HacerVisible20x20);
    }
    void HacerVisible15x15()
    {
        //se activa el marco
        Marco15x15.SetActive(true);
        //hacer visible el mesh renderer de los marcos
        Marco15x15.GetComponent<MeshRenderer>().enabled = true;
        Marco20x20.GetComponent<MeshRenderer>().enabled = true;
        //Se activan las piezas
        pieza1.SetActive(true);
        pieza2.SetActive(true);
        pieza3.SetActive(true);
        pieza4.SetActive(true);
        //hacer visible el mesh renderer de las piezas
        pieza1.GetComponent<MeshRenderer>().enabled = true;
        pieza2.GetComponent<MeshRenderer>().enabled = true;
        pieza3.GetComponent<MeshRenderer>().enabled = true;
        pieza4.GetComponent<MeshRenderer>().enabled = true;
        //se desactivan las piezas
        pieza1.SetActive(true);
        pieza2.SetActive(true);
        pieza3.SetActive(true);
        pieza4.SetActive(true);
        //se ocultan los botones
        boton15x15.gameObject.SetActive(false);
        boton20x20.gameObject.SetActive(false);
        //se oculta el texto de seleccion de marco
        textoSeleccionMarco.gameObject.SetActive(false);
        //Se reinicia el temporizador
        tiempoTranscurrido = 0;
        //se hace visible el tiempo
        textoTemporizador.gameObject.SetActive(true);
        
    }
    void HacerVisible20x20()
    {
        //se activa el marco
        Marco20x20.SetActive(true);
        //hacer visible el mesh renderer de los marcos
        Marco15x15.GetComponent<MeshRenderer>().enabled = true;
        Marco20x20.GetComponent<MeshRenderer>().enabled = true;
        //Se activan las piezas
        pieza1.SetActive(true);
        pieza2.SetActive(true);
        pieza3.SetActive(true);
        pieza4.SetActive(true);
        //hacer visible el mesh renderer de las piezas
        pieza1.GetComponent<MeshRenderer>().enabled = true;
        pieza2.GetComponent<MeshRenderer>().enabled = true;
        pieza3.GetComponent<MeshRenderer>().enabled = true;
        pieza4.GetComponent<MeshRenderer>().enabled = true;
        //se ocultan los botones
        boton15x15.gameObject.SetActive(false);
        boton20x20.gameObject.SetActive(false);
        //se oculta el texto de seleccion de marco
        textoSeleccionMarco.gameObject.SetActive(false);
        //Se reinicia el temporizador
        tiempoTranscurrido = 0;
        //se hace visible el tiempo
        textoTemporizador.gameObject.SetActive(true);

    }
    void Update()
    {
        // Actualizamos el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Formateamos el tiempo transcurrido en un formato legible (minutos:segundos)
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);

        // Actualizamos el texto del temporizador
        textoTemporizador.text = "Tiempo: " + minutos.ToString("00") + ":" + segundos.ToString("00");
        //Si el texto de intenta de nuevo esta activo se desactiva despues de 3 segundos
        if (textoIntentaDeNuevo.gameObject.activeSelf)
        {
            // Incrementamos el tiempo de transcurso 
            transcursoTiempo += Time.deltaTime;

        }
        if (transcursoTiempo >= 3)
        {
            // Desactivamos el texto de intenta de nuevo
            textoIntentaDeNuevo.gameObject.SetActive(false);
            // Reiniciamos el tiempo de transcurso
            transcursoTiempo = 0;
        }
    }
}
    
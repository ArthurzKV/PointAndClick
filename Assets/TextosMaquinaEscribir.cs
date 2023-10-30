using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextosMaquinaEscribir : MonoBehaviour
{
    private float velocidadEscritura = 20f; // Velocidad de escritura en caracteres por segundo.
    public TextMeshProUGUI textoItems;
    private TextMeshProUGUI textoMesh;
    private string textoCompleto = ""; // Texto que se muestra poco a poco.
    private int posicionActual = 0; // Posición actual en el texto.
    private bool textoCompletado = false;
    public PlayerMovement jugador;

    private float tiempoEspera = 0f; // Tiempo de espera antes de mostrar el siguiente carácter.

    private void Start()
    {
        textoMesh = GetComponent<TextMeshProUGUI>();
        ResetearAnimacion();
    }

    private void Update()
    {
        if (!textoCompletado)
        {
            tiempoEspera -= Time.deltaTime;

            if (tiempoEspera <= 0f)
            {
                if (posicionActual < textoCompleto.Length)
                {
                    textoMesh.text += textoCompleto[posicionActual];
                    posicionActual++;
                    tiempoEspera = 1f / velocidadEscritura;
                    textoItems.enabled = false;
                }
                else
                {
                    textoCompletado = true;
                    jugador.isMoving = true;
                    jugador.canMove = true;
                    textoItems.enabled = true;
                    StartCoroutine(Borrar(1.0f));
                }
            }
        }
    }

    private IEnumerator PausaEscribir(float espera)
    {
        yield return new WaitForSeconds(espera);
    }

    private IEnumerator Borrar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        textoCompleto = "";
        textoMesh.text = "";

    }

    // Función para mostrar un nuevo texto y reiniciar la animación
    public void MostrarTexto(string nuevoTexto)
    {
        textoCompleto = nuevoTexto;
        ResetearAnimacion();
    }

    // Función para reiniciar la animación
    private void ResetearAnimacion()
    {
        posicionActual = 0;
        textoMesh.text = "";
        textoCompletado = false;
        tiempoEspera = 0f;
    }
}

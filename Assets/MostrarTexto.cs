using UnityEngine;
using TMPro;

public class MostrarTexto : MonoBehaviour
{
    public TextMeshProUGUI textoParaMostrar; 

    public string textoAMostrar = "Texto que aparecerá"; 
    public string textoAMostrarDos = "Texto que aparecerá2";
    public Controlador controlador;

    private bool isMouseOver = false;

    private void OnMouseOver()
    {

        if (!isMouseOver && controlador.Usar == true)
        {
            isMouseOver = true;
            textoParaMostrar.text = textoAMostrarDos;
            Debug.Log("Cursor encima del objeto y bool activado");
        }
        else if (!isMouseOver){
            isMouseOver = true;
            textoParaMostrar.text = textoAMostrar;
            Debug.Log("Cursor encima del objeto");
        }
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        textoParaMostrar.text = string.Empty;

        if (controlador.Abrir == true){
            textoParaMostrar.text = "Abrir";
        }
        if (controlador.Cerrar == true){
            textoParaMostrar.text = "Cerrar";
        }
        if (controlador.Dar == true){
            textoParaMostrar.text = "Dar";
        }
        if (controlador.Usar == true){
            textoParaMostrar.text = "Usar";
        }
        if (controlador.Coger == true){
            textoParaMostrar.text = "Coger";
        }
        if (controlador.Pulsar == true){
            textoParaMostrar.text = "Pulsar";
        }
        if (controlador.Hablar == true){
            textoParaMostrar.text = "Hablar";
        }
        if (controlador.Leer == true){
            textoParaMostrar.text = "Leer";
        }
        if (controlador.Empujar == true){
            textoParaMostrar.text = "Empujar";
        }
    
    }
}




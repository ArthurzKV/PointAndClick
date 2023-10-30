using UnityEngine;
using TMPro;

public class Interacciones : MonoBehaviour
{


    public Controlador controlador;
    public GameObject Puerta;
    public GameObject Moneda;









    private void OnMouseDown()
    {
        if (controlador.Usar == true)
        {
            
        }

        if (controlador.Hablar == true)
        {

        }

        if (controlador.Abrir == true)
        {
            Puerta.SetActive(true);
            Moneda.SetActive(true);
            Debug.Log("Abriendo");
        }



    }

}




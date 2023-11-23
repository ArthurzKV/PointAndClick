using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class OnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string nombreDelSourceImage;
    public TextMeshProUGUI nombreTextMeshPro; // Referencia al objeto TextMeshPro
    public TextMeshProUGUI textoMaquina; // Referencia al objeto TextMeshPro
    public string LineaInteraccion;
    public TextosMaquinaEscribir LeerTextos;

    // Start is called before the first frame update
    void Start()
    {
        nombreDelSourceImage = "";
    }

    // Update is called once per frame
    void Update()
    {
        // No necesitas verificar el mouse en el Update si usas eventos de puntero
        Image sourceImage = GetComponent<Image>();

        if (sourceImage != null)
        {
            nombreDelSourceImage = sourceImage.sprite.name;
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente SourceImage.");
        }
    }

    // Evento que se llama cuando el puntero entra en el objeto
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Actualiza el TextMeshPro con el nombre del componente SourceImage
        nombreTextMeshPro.text = nombreDelSourceImage;
        Debug.Log("El puntero ha entrado en el objeto.");
    }

    // Evento que se llama cuando el puntero sale del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        // Borra el TextMeshPro si el puntero no está sobre el objeto
        nombreTextMeshPro.text = "";
    }

    // Evento que se llama cuando se hace clic en el objeto
    public void OnPointerClick(PointerEventData eventData)
    {
        // Maneja el clic del ratón y muestra un mensaje de depuración
        LeerTextos.MostrarTexto(LineaInteraccion);
    }
}

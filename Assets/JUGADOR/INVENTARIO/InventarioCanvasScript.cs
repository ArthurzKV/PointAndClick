using UnityEngine;
using UnityEngine.UI;

public class InventarioCanvasScript : MonoBehaviour
{
    public Image[] slots;

    private void Start()
    {
        // No es necesario inicializar el arreglo aquí si asignarás manualmente los objetos en el Inspector
    }

private int contador = 0;

public void AgregarAlInventario(Sprite sprite)
{
    // Si el contador es igual al número de slots, el inventario está lleno
    if (contador == slots.Length)
    {
        Debug.Log("Inventario lleno");
        return;
    }

    // Agrega el nuevo sprite al slot correspondiente
    slots[contador].sprite = sprite;
    slots[contador].enabled = true;

    // Incrementa el contador
    contador++;
}



    public void MostrarInventario()
    {
        foreach (var slot in slots)
        {
            // Realiza acciones con los elementos del inventario (por ejemplo, muestra sprites en una interfaz)
            if (slot != null)
            {
                slot.gameObject.SetActive(true);
            }
        }
    }
}

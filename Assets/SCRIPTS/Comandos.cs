using UnityEngine;
using System.Collections;
using TMPro;

public class Comandos : MonoBehaviour
{
public GameObject[] imagenes;
public GameObject imagenObjetivo;
public PlayerMovement jugador;
public Camera mainCamera;
public TextMeshProUGUI textoParaMostrar;

public float glitchDuration = 0.2f;
public float glitchAmount = 0.1f;

public void ActivarImagenObjetivo()
{
if (jugador.isMoving == false)
{
foreach (GameObject imagen in imagenes)
{
imagen.SetActive(false);
}
imagenObjetivo.SetActive(true);

StartCoroutine(DoGlitchEffect(imagenObjetivo.transform));
}
}

public void Update()
{
if (jugador.isMoving == true)
{
foreach (GameObject imagen in imagenes)
{
imagen.SetActive(false);
textoParaMostrar.text = string.Empty;
}
imagenObjetivo.SetActive(false);
}
}

private IEnumerator DoGlitchEffect(Transform target)
{
float timer = 0;
Vector3 originalPosition = target.position;

while (timer < glitchDuration)
{
float offsetX = Random.Range(-glitchAmount, glitchAmount);
float offsetY = Random.Range(-glitchAmount, glitchAmount);
target.position = originalPosition + new Vector3(offsetX, offsetY, originalPosition.z);

timer += Time.deltaTime;
yield return null;
}

target.position = originalPosition; // Restablece la posición de la imagen objetivo
}
}
using UnityEngine;
using System.Collections;
using TMPro;

public class Interacciones : MonoBehaviour
{
    public Controlador controlador;
    public GameObject Puerta;
    public GameObject Moneda;
    public PlayerMovement player;

    public bool abriendo = false;
    public bool hablando = false;
    private bool haOcurridoColision = false; // Booleano para registrar si ocurrió una colisión
    public bool isColliding = false; //
    public bool interaccionAbrir = false;
    public bool interaccionHablar = false;
    public TextMeshProUGUI[] textMeshArray;
    [SerializeField] public string[] lineasDeTexto; // Arreglo de líneas de texto
    public GameObject CanvasComandos;
    public GameObject dialogos;
    private Vector3 interactionPosition;

    private void Update()
    {
        if (isColliding == true && abriendo == true && interaccionAbrir == true){
            Puerta.SetActive(true);
            Moneda.SetActive(true);
            Debug.Log("Abriendo puerta");
            abriendo = false;
            controlador.Abrir = false;
            // player.transform.position = interactionPosition;
            
            // // player.canMove = false;
            player.isMoving = false;
            player.isMoving = true;
        }
        

        if (isColliding == true && hablando == true && interaccionHablar == true){

            //  Debug.Log("HABLANDO CON BUZON");
            hablando = false;
            controlador.Abrir = false;
            CanvasComandos.SetActive(false);
            dialogos.SetActive(true);
            // player.canMove = false;
            // player.transform.position = interactionPosition;
            for (int i = 0; i < textMeshArray.Length && i < lineasDeTexto.Length; i++) {
                if (textMeshArray[i] != null) {
                    textMeshArray[i].text = lineasDeTexto[i];
                }
            } 

            player.isMoving = false;
            
        }

    }

    private void OnMouseDown()
    {
        if (controlador.Usar == true)
        {

        }

        // else if (controlador.Hablar == true)
        if (controlador.Hablar == true)
        {
            Debug.Log("HABLANDO CON BUZON");
            hablando = true;


        }

        else if (controlador.Abrir == true)
        {
            abriendo = true;
        }
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // interactionPosition = other.transform.position;
            // player.transform.position = interactionPosition;
            
            // // player.canMove = false;
            // player.isMoving = false;
            isColliding = true;

        }
        else{
            isColliding = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
        controlador.Hablar = false;
        CanvasComandos.SetActive(true);
        dialogos.SetActive(false);

        
    
    }

    private IEnumerator AbrirPuertaConRetraso(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (abriendo == true)
        {
            Puerta.SetActive(true);
            Moneda.SetActive(true);
            Debug.Log("Abriendo puerta");
            abriendo = false;
            controlador.Abrir = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con el jugador y registra que ha ocurrido una colisión
        if (collision.gameObject.CompareTag("Player"))
        {
            haOcurridoColision = true;
        }
    }
}

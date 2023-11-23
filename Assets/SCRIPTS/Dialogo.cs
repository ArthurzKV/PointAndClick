using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    public TextMeshProUGUI textoMaquina;
    public TextosMaquinaEscribir LeerTextos;
    public GameObject Comandos;
    public GameObject Dialogos;
    public bool exit = false;
    public Animator playerAnimator;

    void Start()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Animator playerAnimator = playerMovement.playerAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (exit == false){
            Debug.Log("Holaa");
            player.isMoving = false;
            player.canMove = false;
            LeerTextos.MostrarTexto(textoMaquina.text);
            playerAnimator.SetBool("isTalking", true);
        }


        if(exit == true){
            Dialogos.SetActive(false);
            Comandos.SetActive(true);
        }

        
        
    }

}

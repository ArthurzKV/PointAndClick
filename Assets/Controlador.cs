using UnityEngine;
using System.Collections;
using TMPro;

public class Controlador : MonoBehaviour
{
    public TextMeshProUGUI textoParaMostrar;
    public Transform jugador;

    public bool Abrir = false;
    public bool Cerrar = false;
    public bool Dar = false;
    public bool Usar = false;
    public bool Coger = false;
    public bool Pulsar = false;
    public bool Hablar = false;
    public bool Leer = false;
    public bool Empujar = false;
    
    public PlayerMovement Jugador;
    

    public void AbrirM(){
        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Abrir";
            Abrir = true;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
            
        }

    }

    public void CerrarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Cerrar";
            Abrir = false;
            Cerrar = true;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }
    public void DarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Dar";
            Abrir = false;
            Cerrar = false;
            Dar = true;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }

    public void UsarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Usar";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = true;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }
    }

    public void CogerM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Coger";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = true;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }

    public void PulsarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Pulsar";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = true;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }
    public void HablarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Hablar";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = true;
            Leer = false;
            Empujar = false;
        }
        
    }

    public void LeerM(){
        
        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Leer";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = true;
            Empujar = false;
        }else{
            textoParaMostrar.text = "";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }
    public void EmpujarM(){

        if(Jugador.isMoving == false){
            textoParaMostrar.text = "Empujar";
            Abrir = false;
            Cerrar = false;
            Dar = false;
            Usar = false;
            Coger = false;
            Pulsar = false;
            Hablar = false;
            Leer = false;
            Empujar = false;
        }

    }

}



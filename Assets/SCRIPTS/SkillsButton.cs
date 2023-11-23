using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsButton : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement jugador;
    public GameObject BotonSinPresionar;
    public bool botonSinPresionarBool = false;
    public GameObject BotonPresionado;
    public bool botonPresionarBool = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {

    
        if (!botonPresionarBool){
            BotonPresionado.SetActive(true);
            BotonSinPresionar.SetActive(false);
            Debug.Log("presionado");

        }

        if (!botonSinPresionarBool){
            BotonPresionado.SetActive(false);
            BotonSinPresionar.SetActive(true);
            Debug.Log("SINPRESIONAR");
            jugador.isPunching = false;
            jugador.isDead = false;

        }
    }

    public void Punch(){
        jugador.isPunching = true;
    }

    public void Dead(){
        jugador.isDead = true;
    }

    public void Sigilo(){
        jugador.isSigilo = true;
        Debug.Log("Sigilo");
    }


}

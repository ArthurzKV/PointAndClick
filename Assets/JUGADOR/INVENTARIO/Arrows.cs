using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Arrows : MonoBehaviour
{
    public GameObject TopArrow;
    public GameObject BottomArrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Arriba(){
        TopArrow.SetActive(true);
        BottomArrow.SetActive(false);
    }

    public void Abajo(){
        TopArrow.SetActive(false);
        BottomArrow.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadoDP : MonoBehaviour
{
    public int numeroDP;
    public bool tocaMesaDP;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider dPCol)
    {
        if(dPCol.gameObject.tag == "Mesa") 
        {
            numeroDP = int.Parse(GetComponent<TextMesh> ().text);
            tocaMesaDP = true;
        }
    }
    void OnTriggerExit(Collider dPCol)
    {
            tocaMesaDP = false;
    }
    
}


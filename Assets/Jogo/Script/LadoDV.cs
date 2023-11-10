using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadoDV : MonoBehaviour
{
    public int numeroDV;
    public bool tocaMesaDV;
    public GameObject gomensDV;
    void OnTriggerEnter(Collider dVCol)
    {
        if(dVCol.gameObject.tag == "Mesa") 
        {
            numeroDV = int.Parse(GetComponent<TextMesh> ().text);
            tocaMesaDV = true;
            return;
        }

    }
    void OnTriggerExit(Collider dVCol)
    {
            tocaMesaDV = false;
            return;
    }
    
}

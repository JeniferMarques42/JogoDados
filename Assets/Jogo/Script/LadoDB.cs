using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadoDB : MonoBehaviour
{   // variável para receber o número do texto do dado
    public int numeroDB;
    // variável demonstrar se a mesa foi ou não tocada
    public bool tocaMesaDB;
    void OnTriggerEnter(Collider dBCol) //funçao do Unity para determinar o toque em um objeto em cena, nesse caso a "Mesa"
    {
    if(dBCol.gameObject.tag == "Mesa") //Se objeto em cena com a tag "mesa" for tocado faça
        {
            numeroDB = int.Parse(GetComponent<TextMesh> ().text); //receba o valor do texto dentro do dado
            tocaMesaDB = true;
        }
    }
    void OnTriggerExit(Collider dBCol)
    {
            tocaMesaDB = false;
    }
    
}


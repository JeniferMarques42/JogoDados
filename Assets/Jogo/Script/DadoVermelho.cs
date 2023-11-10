using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DadoVermelho : MonoBehaviour
{
    
    public Rigidbody dV;
    //variável inicializada para dar força a lançar dado
    float forcaDeQuicar = 8.0f;
    //variável que irá receber o valor do dado quando cair na mesa
    public int numeroAtualDV;
    //array que que ajudará a identificar o valor do dado na Unity
    public  LadoDV[] ladosDV;
    //variável booleana que determinará se o dado toqou o a superfície
    public bool tocaMesaDV;  
    
    public GameObject goLancarDadosDV, goBtDv, goBtDb, goBtDp;
    void Start()
    {
        //a variável recebe uma parte do código para depois complementar 
       dV = GetComponent <Rigidbody>();
       // complemtando no unicio do jogo deixando os objetos suspensos antes de iniciar o jogo
       dV.useGravity = false;
    }
   void NumeroDadoDV()
    {
        
        for(int i = 0; i < ladosDV.Length; i++)
            {
            if (ladosDV[i].tocaMesaDV)
                {   
                    numeroAtualDV = ladosDV[i].numeroDV;
                }
                
            }    
        Invoke("NumeroDadoDV", 0.15f);
        
        
    }
    public void ClickOnbutton()
    {   
        dV.useGravity = true;
        dV.AddForce(Vector3.up * forcaDeQuicar, ForceMode.Impulse);
        GetComponent <Rigidbody> ().rotation = Random.rotation;
        
        goLancarDadosDV.SetActive(false);
        
        goBtDv.SetActive(false);
        goBtDb.SetActive(false);
        goBtDp.SetActive(false);
        NumeroDadoDV();
    }      

    
   
}
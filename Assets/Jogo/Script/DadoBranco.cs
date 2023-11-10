using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DadoBranco : MonoBehaviour
{
    public bool parado = true;
    public Rigidbody dB;
    float forcaDeQuicar = 8.0f;
    public int numeroAtualDB;
    public  LadoDB[] ladosDB;
    public bool tocaMesaDB;
    public Text numeroDB;
    public GameObject goLancarDadosDB, goMensConfirm, goBtDv, goBtDb, goBtDp;
    
    void Start()
    {
       dB = GetComponent <Rigidbody>();
       dB.useGravity = false;
    }
    void Update()
    {
    }
    void NumeroDadoDB()
    {
        tocaMesaDB = true;
        for(int i = 0; i < ladosDB.Length; i++)
            {
            if (ladosDB[i].tocaMesaDB)
                {   
                    numeroAtualDB = ladosDB[i].numeroDB;
                   
                }
            }
    
        Invoke("NumeroDadoDB", 0.5f);
    }
    public void ClickOnbutton()
    {
        dB.useGravity = true;
        dB.AddForce(Vector3.up * forcaDeQuicar, ForceMode.Impulse);
        GetComponent <Rigidbody> ().rotation = Random.rotation;
        goLancarDadosDB.SetActive(false);
        goMensConfirm.SetActive(false);
        goBtDv.SetActive(false);
        goBtDb.SetActive(false);
        goBtDp.SetActive(false);
        NumeroDadoDB();     
    }
    
}

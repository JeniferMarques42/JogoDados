using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadoPreto : MonoBehaviour
{
    public Vector3 posicaoInicialDP;
    public bool parado = true;
    public Rigidbody dP;
    float forcaDeQuicar = 8.0f;
    public int numeroAtualDP;
    public  LadoDP[] ladosDP;
    public bool tocaMesaDP;
    public Text numeroDP;
    public GameObject goLancarDadosDP, goMensConfirm, goBtDv, goBtDb, goBtDp;
    void Start()
    {
       dP = GetComponent <Rigidbody>();
       dP.useGravity = false;
    }
    void Update()
    {
    }
    void NumeroDadoDP()
    {
        tocaMesaDP = true;
        for(int i = 0; i < ladosDP.Length; i++)
            {
            if (ladosDP[i].tocaMesaDP)
                {   
                    numeroAtualDP = ladosDP[i].numeroDP;
                }
            }
    
        Invoke("NumeroDadoDP", 0.5f);
    }
    public void ClickOnbutton()
    {
         
        dP.useGravity = true;
        dP.AddForce(Vector3.up * forcaDeQuicar, ForceMode.Impulse);
        GetComponent <Rigidbody> ().rotation = Random.rotation;
        goLancarDadosDP.SetActive(false);
        goMensConfirm.SetActive(false);
        goBtDv.SetActive(false);
        goBtDb.SetActive(false);
        goBtDp.SetActive(false);
        NumeroDadoDP();
    }
}

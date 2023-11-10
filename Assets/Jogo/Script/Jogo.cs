using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Jogo : MonoBehaviour
{
    //Receber um valor inputFiel no script 
    public InputField aposta;
    public GameObject goDadoVermelho, goBtDv;
    public GameObject goDadoBranco, goBtDb;
    public GameObject goDadoPreto, goBtDp;
    public GameObject goTextConfAposta, goNaoPerm, goLançarDados, goNovaAposta, goPergunta, goInputField, goBtConfirmar, goTextSaldoP, goTextSaldoStart, goCredito;
    public Text textNaoPermitido, textSaldoP, textSaldoPStart;
    string valor;
    int vlrAposta, saldoP = 100, num, numeroAtualDV, numeroAtualDP, numeroAtualDB, saldoPStart = 0; 
    public LadoDV[] ladosDV;
    public LadoDP[] ladosDP;
    public LadoDB[] ladosDB;
    int dadoDV, dadoDP, dadoDB, jogada = 0;
    [SerializeField] private string credito;

    Vector3 novaPosicaoDv = new Vector3 (6.18f, -8.72f, 5.41f);
    void Start()
    {
      
    }
    //Função recebe o valor apostado
    public void ReceberVlrAposta()
    {
        saldoP = 100;
        textSaldoPStart.text = saldoPStart.ToString();
        goDadoBranco.SetActive(true);
        goDadoPreto.SetActive(true);
        goDadoVermelho.SetActive(true);

        goNovaAposta.SetActive(false);
        goPergunta.SetActive(true);
        goBtConfirmar.SetActive(true);
        goInputField.SetActive(true);
        valor = aposta.text; 
        vlrAposta = int.Parse(valor);
        
        transform.position = novaPosicaoDv;
        ConfirmarAposta();
    }
    void ConfirmarAposta()
    {
       
        if(jogada <= 2)
        {
        if((vlrAposta > 0) && (vlrAposta <= saldoP))
        {
            goBtDv.SetActive(true);
            goBtDb.SetActive(true);
            goBtDp.SetActive(true);
            dadoDB = 0;
            dadoDV = 0; 
            dadoDP = 0; 
            jogada ++;
            return;
        }
        else if((vlrAposta < 0) && (vlrAposta > saldoP))
        {
            jogada --;
            textNaoPermitido.text = "Não permitido! O valor tem que ser menor que seu saldo e maior que 1. Tente novamente.";
            goNaoPerm.SetActive(true);
            return;
        }    
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        goTextSaldoP.SetActive(false);   
        goTextSaldoStart.SetActive(true);
    }
    //escolher dado e só atiava após a aposta ter uma valor a
    public void ClickOnbuttonDV()
    {
        if((vlrAposta > 0) && (vlrAposta <= saldoP))
        {
            goPergunta.SetActive(false);
            goInputField.SetActive(false);
            goBtConfirmar.SetActive(false);
            goNaoPerm.SetActive(false);
            goDadoBranco.SetActive(false);
            goDadoPreto.SetActive(true);
            goLançarDados.SetActive(true);
            goDadoVermelho.SetActive(true);
            
            SelecaoDB();
            SelecaoDV();
            SelecaoDP();
        }

    }
    public void ClickOnbuttonDB()
    {
        if((vlrAposta > 0) && (vlrAposta <= saldoP))
        {
            goPergunta.SetActive(false);
            goInputField.SetActive(false);
            goBtConfirmar.SetActive(false);
            goNaoPerm.SetActive(false);
            goDadoPreto.SetActive(false);
            goDadoVermelho.SetActive(true);
            goDadoBranco.SetActive(true);
            goLançarDados.SetActive(true);
            transform.position = novaPosicaoDv;
            SelecaoDB();
            SelecaoDV();
            SelecaoDP();
        }  
    }
    public void ClickOnbuttonDP()
    {
       if((vlrAposta > 0) && (vlrAposta <= saldoP))
       {
            goPergunta.SetActive(false);
            goInputField.SetActive(false);
            goBtConfirmar.SetActive(false);
            goNaoPerm.SetActive(false);
            goDadoVermelho.SetActive(false);
            goDadoBranco.SetActive(true);
            goDadoPreto.SetActive(true);
            goLançarDados.SetActive(true);
            transform.position = novaPosicaoDv;
            SelecaoDP();
            SelecaoDB();
            SelecaoDV();
       }
        
    }  
    public void SelecaoDV()
    {   
        if(goDadoVermelho){
        for(int i = 0; i < ladosDV.Length; i++)
            {
            if (ladosDV[i].tocaMesaDV)
                {   
                    numeroAtualDV = ladosDV[i].numeroDV;
                    dadoDV = numeroAtualDV;
                    Debug.Log(dadoDV);
                    Invoke("Vitoria",0.10f);
                    
                    goNovaAposta.SetActive(true);
                    aposta.text = 0.ToString();
                    return;
                }
                    
            }
              
        }
        Invoke("SelecaoDV", 0.5f);  
    }
    public void SelecaoDB()
    { 
        if(goDadoBranco)
        {
            for(int i = 0; i < ladosDB.Length; i++)
            {
            if (ladosDB[i].tocaMesaDB)
                {   
                    numeroAtualDB = ladosDB[i].numeroDB;
                    dadoDB = numeroAtualDB;
                    Debug.Log(dadoDB);
                    Invoke("Vitoria",0.10f);
                    goNovaAposta.SetActive(true);
                    return;
                }
            }   
        }
        Invoke("SelecaoDB", 0.5f); 
           
    }
    public void SelecaoDP()
    {   
        if(goDadoPreto)
        {
            for(int i = 0; i < ladosDP.Length; i++)
            {
            if (ladosDP[i].tocaMesaDP)
                {   
                    numeroAtualDP = ladosDP[i].numeroDP;
                    dadoDP = numeroAtualDP;
                    Debug.Log(dadoDP);
                    Invoke("Vitoria",0.10f);
                    goNovaAposta.SetActive(true);
                    return;
                }
            }   
        }
        Invoke("SelecaoDP", 0.5f); 
    }
    void Vitoria()
    {   
        if((dadoDV != 0 && dadoDP !=0) || (dadoDP != 0 && dadoDB != 0) || (dadoDB != 0 && dadoDV != 0 ) )
        {   
            if((dadoDV > dadoDP && dadoDB == 0) || (dadoDP > dadoDB && dadoDV == 0) || (dadoDB > dadoDV && dadoDP == 0))
            {
                saldoP += (vlrAposta * 2);
                saldoPStart = saldoP;
                textSaldoPStart.text = saldoPStart.ToString();               
                return;
            }
            else
            {
                 
                saldoP -= vlrAposta;
                saldoPStart = saldoP;
                textSaldoPStart.text = saldoPStart.ToString();
                 return;
                
            }
        }          
    } 
     
    public void ExitGame()
    {
        
        Application.Quit();
    }

    public void Credito()
    {
        goCredito.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}

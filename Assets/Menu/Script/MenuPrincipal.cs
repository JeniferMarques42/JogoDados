using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string nomeJogo;
    [SerializeField] private GameObject menuInicial;
    [SerializeField] private GameObject tutorial;
  public void Play()
  {
    SceneManager.LoadScene(nomeJogo);
  }
  public void ExitGame()
  {
    Application.Quit();
  }
  public void AbrirTutorial()
  {
    menuInicial.SetActive(false);
    tutorial.SetActive(true);
  }
   public void FecharTutorial()
  {
    tutorial.SetActive(false);
    menuInicial.SetActive(true);
  }


}

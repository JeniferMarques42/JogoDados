using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credito : MonoBehaviour
{
    // [SerializeField] private string nomeTela;

    public void Menu()
    {
        Debug.Log("entrou");
        SceneManager.LoadScene("Menu");
    }

    public void Teste()
    {
        Debug.Log("entrou");
    }
}

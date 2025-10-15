using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDeGameOver : MonoBehaviour
{
    public string nomeDoMenu;
   public void CarregarMenu()
    {
        SceneManager.LoadScene(nomeDoMenu);
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarDeFase : MonoBehaviour
{
    public Animator oAnimatorDeTransicao;  
    public string faseParaCarregar;
    public float tempoParaEsperar;
    

    private IEnumerator CarregarNovaFase()
    {
        oAnimatorDeTransicao.Play("Imagem Escurecendo");

        yield return new WaitForSeconds(tempoParaEsperar);

        SceneManager.LoadScene(faseParaCarregar);
    }
         
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          StartCoroutine(CarregarNovaFase());
        }
    }
}

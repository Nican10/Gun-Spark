using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    public Animator oAnimatorDaPorta;
    public Collider2D colisorDaPorta;

    public bool portaNormal;
    public bool portaPrateada;
    public bool portaDourada;

    public bool portaFechada;
     
    

    // Start is called before the first frame update
    void Start()
    {
        portaFechada = true;
    }
        
    private void AbrirPorta ()
    {
        oAnimatorDaPorta.SetTrigger("Porta Abrindo");
        portaFechada = false;
        colisorDaPorta.enabled = false;
    }

     private void FecharPorta()
    {
        oAnimatorDaPorta.SetTrigger("Porta Fechando");
        portaFechada = true;
        colisorDaPorta.enabled = true;
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(portaFechada == true)
            {
                if(portaNormal == true)
                {
                    AbrirPorta();
                }

                if(portaPrateada == true)
                {
                    if(GameManager.Instance.temChavePrateada == true)
                    {
                        AbrirPorta();
                    }
                }

                if(portaDourada == true)
                {
                    if(GameManager.Instance.temChaveDourada == true)
                    {
                        AbrirPorta();
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(portaFechada == false)
            {
                FecharPorta();
            }
        }

    }

}

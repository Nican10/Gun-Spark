using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;

    public Text textoDeVidaDoJogador;

    // Start is called before the first frame update
    void Start()
    {
        textoDeVidaDoJogador.text = "VIDA\n" + vidaAtualDoJogador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachucarJogador(int danoParaReceber)
    {
        if(GameManager.Instance.jogadorEstaVivo == true)
        {
            vidaAtualDoJogador -= danoParaReceber;
            OsEfeitosSonoros.instance.TocarDanoDoJogador();
            textoDeVidaDoJogador.text = "VIDA\n" + vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public void GanharVida(int vidaParaReceber)
    {
        if(vidaAtualDoJogador + vidaParaReceber < vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        textoDeVidaDoJogador.text = "VIDA\n" + vidaAtualDoJogador;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidadeDoInimigo;
    public Transform[] pontosParaCaminhar;
    public int pontoAtual;

    public Transform localDoDisparo;
    public GameObject projetilDoInimigo;
    public Animator oAnimator;

    public float distanciaParaAtacar;
    public float tempoEntreOsAtaques;

    public bool inimigoEstaVivo;
    public bool inimigoPodeAndar;

    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;

    public float tempoEntreOsPontos;
    public float tempoAtual;
    public float posicaoDoRaio;

    public bool inimigoJaAtacou;
    public bool podeAtacar;
    // Start is called before the first frame update
    void Start()
    {
        inimigoEstaVivo = true;
        inimigoPodeAndar = true;
        inimigoJaAtacou = false;
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
        
        transform.position = pontosParaCaminhar[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.jogadorEstaVivo == true)
        {
            MovimentarInimigo();
            VerificarDistancia();
        }
        
        
    }

    private void MovimentarInimigo()
    {
        if (inimigoEstaVivo == true)
        {
            if(inimigoPodeAndar == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, pontosParaCaminhar[pontoAtual].position, velocidadeDoInimigo * Time.deltaTime);
                transform.position += new Vector3(0f, 0f, -0.7f);

                if(transform.position.y != pontosParaCaminhar[pontoAtual].position.y)
                {
                    oAnimator.SetTrigger("Andando");
                }

                if (transform.position.y == pontosParaCaminhar[pontoAtual].position.y)
                {
                    oAnimator.SetTrigger("Parar");
                    EsperarAntesDeCaminhar();
                    
                }
                if (pontoAtual == pontosParaCaminhar.Length)
                {
                    pontoAtual = 0;
                }
            }
        }
    }

    private void EsperarAntesDeCaminhar ()
    {
        //inimigoPodeAndar = false;

        tempoAtual -= Time.deltaTime;

        if(tempoAtual <= 0)
        {// ou, pontoAtual += 1; é a msm coisa
            inimigoPodeAndar |= true;
            pontoAtual++;
            tempoAtual = tempoEntreOsPontos;
        }
    }

    public void VerificarDistancia ()
    {
        if(Vector3.Distance(transform.position, ControleDoJogador.Instance.transform.position) < distanciaParaAtacar)
        {
            AtacarJogador();
        }
        else
        {
            inimigoPodeAndar = true;
        }
    }

    private void AtacarJogador()
    {
        if (podeAtacar)
        {
            Vector3 posicaoDoRaio = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);

            RaycastHit2D localAtingido = Physics2D.Raycast(posicaoDoRaio, transform.forward, distanciaParaAtacar);

            if (localAtingido.collider != null)
            {
                if (localAtingido.transform.gameObject.layer != 6)
                {
                    if (inimigoJaAtacou == false)
                    {
                        inimigoPodeAndar = false;
                        oAnimator.SetTrigger("Atacando");
                        OsEfeitosSonoros.instance.TocarAtaqueDoInimigo();
                        Instantiate(projetilDoInimigo, localDoDisparo.position, localDoDisparo.rotation);

                        inimigoJaAtacou = true;
                        Invoke(nameof(ResetarAtaqueDoInimigo), tempoEntreOsAtaques);
                    }
                }
                   
            }
        }
    }

    private void ResetarAtaqueDoInimigo()
    {
        inimigoJaAtacou = false;
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        if (inimigoEstaVivo == true)
        {
            vidaAtualDoInimigo -= danoParaReceber;
            OsEfeitosSonoros.instance.TocarDanoDoInimigo();
            oAnimator.SetTrigger("Dano");

            if(vidaAtualDoInimigo <= 0)
            {
                inimigoEstaVivo = false;
                inimigoPodeAndar = false;

                OsEfeitosSonoros.instance.TocarInimigoDerrotado();
                oAnimator.SetTrigger("Derrotado");

                                
            }
        }
    }

    public void DerrotarInimigo()
    {
        Destroy(this.gameObject);
    }

}

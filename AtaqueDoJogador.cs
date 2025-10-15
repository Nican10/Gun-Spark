using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueDoJogador : MonoBehaviour
{
    public Camera cameraDoJogo;
    public GameObject efeitoDeImpacto;
    public Animator animatorDaArma;
    public Text textoDaMunicao;

    public int municaoMaxima;
    public int municaoAtual;
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        textoDaMunicao.text = "MUNIÇÃO\n" + municaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.jogoPausado == false && GameManager.Instance.jogadorEstaVivo == true)
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (municaoAtual > 0)
            {   
                Ray raio = cameraDoJogo.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit localAtingido;
                
                if (Physics.Raycast(raio, out localAtingido))
                {
                    Instantiate(efeitoDeImpacto, localAtingido.point, localAtingido.transform.rotation);
                    Debug.Log("Estou olhando para: " + localAtingido.transform.name);

                    if(localAtingido.transform.gameObject.CompareTag("Inimigo"))
                    {
                        localAtingido.transform.gameObject.GetComponentInParent<Inimigo>().MachucarInimigo(danoParaDar);
                    }
                }
                else
                {
                    Debug.Log("Não estou olhando nada");
                }

                municaoAtual -= 1;
                OsEfeitosSonoros.instance.TocarAtaqueDoJogador();
                textoDaMunicao.text = "MUNIÇÃO\n" + municaoAtual;
                animatorDaArma.SetTrigger("Arma Atirando");
            }
            else
            {
                OsEfeitosSonoros.instance.TocarSomSemMunição();
                Debug.Log("Sem munição");
            }
        }
    }

    public void GanharMunicao (int municaoParaReceber)
    {
        if(municaoAtual + municaoParaReceber < municaoMaxima)
        {
            //municaoAtual = municaoAtual + municaoParaReceber;
            municaoAtual += municaoParaReceber;
        }
        else
        {
            municaoAtual = municaoMaxima;
        }

        textoDaMunicao.text = "MUNIÇÃO\n" + municaoAtual;
    }
}

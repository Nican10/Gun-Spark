using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public static ControleDoJogador Instance;

    public Rigidbody2D oRigidbody2D;
    public Animator animatorDoPainelDaArma;

    public float velocidadeDoJogador;
    public float sensibilidadeDoMouse;
  
    private Vector2 comandoDoTeclado;
    private Vector2 movimentoDoMouse;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.jogoPausado == false && GameManager.Instance.jogadorEstaVivo == true)
        {
            MovimentarJogador();
            GirarCamera();
        }
    }

    private void MovimentarJogador()
    {
        comandoDoTeclado = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 movimentoHorizontal = transform.up * -comandoDoTeclado.x;
        Vector3 movimentoVertical = transform.right * comandoDoTeclado.y;

        oRigidbody2D.velocity = (movimentoHorizontal + movimentoVertical) * velocidadeDoJogador;
        //corrige o movimento na diagonal que faz o jogador se mover mais rapido
        oRigidbody2D.velocity.Normalize();

        if(oRigidbody2D.velocity.magnitude == 0)
        {
            animatorDoPainelDaArma.Play("Jogador Parado");
        }
        else
        {
            animatorDoPainelDaArma.Play("Jogador Andando");
        }
    }

    private void GirarCamera ()
    {
        movimentoDoMouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * sensibilidadeDoMouse);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - movimentoDoMouse.x);
    }

}

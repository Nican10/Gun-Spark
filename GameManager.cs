using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool jogadorEstaVivo;
    public bool jogoPausado;

    public bool temChavePrateada;
    public bool temChaveDourada;

    public GameObject painelDePause;
    public GameObject painelDeGameOver;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        jogadorEstaVivo = true;
        jogoPausado = false;
        temChavePrateada = false;
        temChaveDourada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(jogoPausado == false)
            {
                PausarJogo();
            }
            else
            {
                DespausarJogo();
            }
        }
    }
    public void PausarJogo()
    {
        Time.timeScale = 0f;
        painelDePause.SetActive(true);
        jogoPausado = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DespausarJogo()
    {
        Time.timeScale = 1f;
        painelDePause.SetActive(false);
        jogoPausado = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver()
    {
        painelDeGameOver.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        jogadorEstaVivo = false;
        FindObjectOfType<Musicas>().TocarMusicaDeGameOver();
        Debug.Log("Game Over");
    }
       

}

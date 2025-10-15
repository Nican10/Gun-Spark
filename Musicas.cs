using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioSource musicaDaFase;
    public AudioSource musicaDeGameOver;

    // Start is called before the first frame update
    void Start()
    {
        TocarMusicaDaFase();
    }

    public  void TocarMusicaDaFase()
    {
        musicaDaFase.Play();
    }

    public void TocarMusicaDeGameOver()
    {
        musicaDaFase.Stop();
        musicaDeGameOver.Play();
    }
}

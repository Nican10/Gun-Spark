using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjetilDoInimigo : MonoBehaviour
{
    public float velocidadeDoProjetil;
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarProjetilDoInimigo();
    }

    public void MovimentarProjetilDoInimigo()
    {
        transform.Translate(Vector3.forward * velocidadeDoProjetil * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(this.gameObject);
        }
        
        

      
    }

    

}

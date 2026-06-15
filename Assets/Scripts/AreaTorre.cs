using System.Collections.Generic;
using UnityEngine;

public class AreaTorre : MonoBehaviour
{
    public List<GameObject> inimigosEmArea;
    public BotaoTorreMapa botaoTorre;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inimigosEmArea = new List<GameObject>();
    }

    public void AdicionarInimigoNaLista(GameObject inimigo)
    {
        inimigosEmArea.Add(inimigo);
        //Debug.Log($"ENTROU Inimigo: {inimigo.name}");
    }

    public void RemoverInimigoDaLista(GameObject inimigo)
    {
        inimigosEmArea.Remove(inimigo);
        //Debug.Log($"SAIU Inimigo: {inimigo.name}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Inimigo")
        {
            AdicionarInimigoNaLista(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Inimigo")
        {
            RemoverInimigoDaLista(collision.gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

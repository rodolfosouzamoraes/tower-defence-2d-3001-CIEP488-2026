using UnityEngine;

public class CanvasMenuMng : MonoBehaviour
{
    private Jogador dadosJogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dadosJogador = DBMng.CarregarDadosJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

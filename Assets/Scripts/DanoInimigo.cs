using UnityEngine;
using UnityEngine.UI;

public class DanoInimigo : MonoBehaviour
{
    public float vidaInimigo;
    public int valorInimigo;
    public Slider sldVidaInimigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sldVidaInimigo.maxValue = vidaInimigo;
        sldVidaInimigo.value = vidaInimigo;
    }

    public void EfetuarDanoAoInimigo(float valorDano)
    {
        if (CanvasGameMng.PannelGamePlay.FimDeJogo == true) return;
        vidaInimigo -= valorDano;
        if (vidaInimigo <= 0) {
            DestruirInimigo();
        }
        sldVidaInimigo.value = vidaInimigo;
    }

    public void DestruirInimigo()
    {
        vidaInimigo = 0;

        //Gerar Moedas para o Player
        CanvasGameMng.PannelGamePlay.AdicionarMoedas(valorInimigo);
        CanvasGameMng.PannelGamePlay.TotalInimigosMortosPeloJogador += 1;
        CanvasGameMng.PannelGamePlay.ContarInimigoMorto();

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projetil")
        {
            float valorDano = collision.GetComponent<ProjetilControle>().Dano;
            EfetuarDanoAoInimigo(valorDano);
            Destroy(collision.gameObject);
        }
    }

    public float CalcularDanoAoJogador()
    {
        return valorInimigo * Constants.PORCENTAGEM_DANO_INIMIGO;
    }
}

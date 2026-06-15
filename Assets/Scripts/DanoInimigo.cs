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

    public void EfetuarDanoAoInimigo(int valorDano)
    {
        vidaInimigo -= valorDano;
        if (vidaInimigo <= 0) {
            vidaInimigo = 0;

            //Gerar Moedas para o Player
            CanvasGameMng.PannelGamePlay.AdicionarMoedas(valorInimigo);

            Destroy(gameObject);
        }
        sldVidaInimigo.value = vidaInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

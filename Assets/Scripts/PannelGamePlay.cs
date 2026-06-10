using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PannelGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject pnlGamePlay;
    [SerializeField] private TextMeshProUGUI txtMoedas;
    [SerializeField] private TextMeshProUGUI txtInimigos;
    [SerializeField] private Slider sldVida;
    [SerializeField] private TextMeshProUGUI txtTempo;
    [SerializeField] private int moedasAtuaisNivel;
    [SerializeField] private int totalMaximoInimigos;
    [SerializeField] private int inimigosRestantesNivel;
    private int contagemTempo;
    private int vidaAtualJogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moedasAtuaisNivel = Constants.VALOR_INICIAL_MOEDAS_NIVEL;
        inimigosRestantesNivel = totalMaximoInimigos;
        txtMoedas.text = $"${moedasAtuaisNivel}";
        txtInimigos.text = $"{inimigosRestantesNivel}/{totalMaximoInimigos}";
        contagemTempo = 0;
        vidaAtualJogador = Constants.VALOR_VIDA_JOGADOR;
        sldVida.maxValue = Constants.VALOR_VIDA_JOGADOR;
        sldVida.value = vidaAtualJogador;
        txtTempo.text = $"{contagemTempo}";
    }

    public int ObterMoedasTotais()
    {
        return moedasAtuaisNivel;
    }

    public void DebitarMoedas(int debito)
    {
        moedasAtuaisNivel -= debito;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

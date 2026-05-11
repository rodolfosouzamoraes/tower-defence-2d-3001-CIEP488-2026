using UnityEngine;

public class CanvasMenuMng : MonoBehaviour
{
    public static CanvasMenuMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private Jogador dadosJogador;
    public Jogador DadosJogador { get { return dadosJogador; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AtualizarDadosJogador();
    }

    public void AtualizarDadosJogador()
    {
        dadosJogador = DBMng.CarregarDadosJogador();

        //Atualizar os volumes do audio com os dados do jogador
        Configuracao config = dadosJogador.configuracoes;
        AudioMng.Instance.AtualizarVolumes(config.volumeMusica, config.volumeSFX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

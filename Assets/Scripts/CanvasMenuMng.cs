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
        /*Area de teste, apagar depois
        DBMng.AdicionarNivel(1);
        DBMng.AdicionarNivel(2);
        DBMng.AdicionarNivel(3);
        DBMng.AdicionarNivel(4);
        DBMng.AdicionarNivel(5);
        //Area de teste, apagar depois*/

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

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HordaInimigosControle : MonoBehaviour
{
    public CanvasMapaMng mapaMng;
    public float tempoNovoInimigo;
    public List<InimigoNivel> inimigosDoNivel;
    public GameObject hordaInicio;
    private float tempoProximoInimigo;
    private int contagemInimigosInstanciados = 0;
    private int maximoInimigosMapa = 0;

    public int MaximoInimigosMapa
    {
        get { return maximoInimigosMapa; }
    }

    public int ContagemInimigos
    {
        get { return contagemInimigosInstanciados; }
    }

    private void Awake()
    {
        contagemInimigosInstanciados = 0;
        foreach (var inimigo in inimigosDoNivel)
        {
            maximoInimigosMapa += inimigo.quantidade;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoProximoInimigo = Time.timeSinceLevelLoad + tempoNovoInimigo + Constants.TEMPO_ESPERA_INICIAL_GAMEPLAY;
        CanvasGameMng.PannelGamePlay.AtualizarInimigoUI(contagemInimigosInstanciados, maximoInimigosMapa);
    }

    // Update is called once per frame
    void Update()
    {
        //Lógica do instanciamento dos inimigos
        if (Time.timeSinceLevelLoad > tempoProximoInimigo && inimigosDoNivel.Count>0) {
            tempoProximoInimigo = Time.timeSinceLevelLoad + tempoNovoInimigo;

            var inimigoId = new System.Random().Next(0, inimigosDoNivel.Count);
            inimigosDoNivel[inimigoId].totalInstanciados++;
            var novoInimigo = Instantiate(inimigosDoNivel[inimigoId].inimigo);
            novoInimigo.GetComponent<InimigoIA>().DefinirNovoDestino(mapaMng.primeiroDestino);
            novoInimigo.transform.position = hordaInicio.transform.position;
            contagemInimigosInstanciados++;
            CanvasGameMng.PannelGamePlay.AtualizarInimigoUI(contagemInimigosInstanciados, maximoInimigosMapa);
            if (inimigosDoNivel[inimigoId].quantidade == inimigosDoNivel[inimigoId].totalInstanciados)
            {
                inimigosDoNivel.Remove(inimigosDoNivel[inimigoId]);
            }
        }
    }
}

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoProximoInimigo = Time.timeSinceLevelLoad + tempoNovoInimigo;
        foreach(var inimigo in inimigosDoNivel)
        {
            maximoInimigosMapa += inimigo.quantidade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Lógica do instanciamento dos inimigos
        if (Time.timeSinceLevelLoad > tempoProximoInimigo) {
            tempoProximoInimigo = Time.timeSinceLevelLoad + tempoProximoInimigo;

            var inimigoId = new System.Random().Next(0, inimigosDoNivel.Count);
            inimigosDoNivel[inimigoId].totalInstanciados++;
            var novoInimigo = Instantiate(inimigosDoNivel[inimigoId].inimigo);
            novoInimigo.GetComponent<InimigoIA>().DefinirNovoDestino(mapaMng.primeiroDestino);
            novoInimigo.transform.position = hordaInicio.transform.position;
            contagemInimigosInstanciados++;
            if (inimigosDoNivel[inimigoId].quantidade == inimigosDoNivel[inimigoId].totalInstanciados)
            {
                inimigosDoNivel.Remove(inimigosDoNivel[inimigoId]);
            }
        }
    }
}

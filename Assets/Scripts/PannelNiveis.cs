using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PannelNiveis : MonoBehaviour
{
    public TextMeshProUGUI txtNomeNivel;
    public Image imgNivel;
    public GameObject levelCompletado;
    public NivelSO[] niveis;
    public GameObject btnIniciar;
    public GameObject btnEsquerda;
    public GameObject btnDireita;
    private int idNivelAtual;
    private List<NivelSO> listaNiveis = new List<NivelSO>(); 

    private void OnEnable()
    {
        //limpar a lista de niveis para atualizar com novos valores
        listaNiveis.Clear();

        //Pegar os niveis completados do jogador.
        Nivel[] niveisJogador = CanvasMenuMng.Instance.DadosJogador.niveisCompletados.ToArray();

        for(int i = 0; i < niveis.Length; i++) //Percorrendo todos os níveis SO
        {
            for(int j = 0; j < niveisJogador.Length; j++) //Percorrer todos os níveis que o jogador já completou
            {
                if (niveis[i].nivel.id == niveisJogador[j].id) //Comparar com o nivel SO com o que o jogador já jogou
                {                    
                    niveis[i].nivel.completado = true;//Marcar como habilitado o nivel
                    listaNiveis.Add(niveis[i]); //Adicionar nivel que o jogador já jogou
                    break;
                }
            }
        }

        if(listaNiveis.Count == 0) // Verificar se não tem nenhum nivel completado
        {
            idNivelAtual = niveis[0].nivel.id;
            txtNomeNivel.text = niveis[0].nivel.nome;
            imgNivel.sprite = niveis[0].icone;
            levelCompletado.SetActive(false);
        }
        else if (listaNiveis.Count == niveis.Length) // verificar se já desbloqueou todos os niveis
        {
            idNivelAtual = niveis[listaNiveis.Count-1].nivel.id;
            txtNomeNivel.text = niveis[listaNiveis.Count-1].nivel.nome;
            imgNivel.sprite = niveis[listaNiveis.Count-1].icone;
            levelCompletado.SetActive(true);
        }
        else // Mostra o proximo nível
        {
            idNivelAtual = niveis[listaNiveis.Count].nivel.id;
            txtNomeNivel.text = niveis[listaNiveis.Count].nivel.nome;
            imgNivel.sprite = niveis[listaNiveis.Count].icone;
            levelCompletado.SetActive(false);
        }
        
    }
    
    public void NivelAnterior()
    {
        if(idNivelAtual-1 > 0)
        {
            idNivelAtual--;
            txtNomeNivel.text = listaNiveis[idNivelAtual - 1].nivel.nome;
            imgNivel.sprite = listaNiveis[idNivelAtual - 1].icone;
            levelCompletado.SetActive(listaNiveis[idNivelAtual - 1].nivel.completado);
            //Habilitar o botão posterior
            btnDireita.SetActive(true);
            if(idNivelAtual == 1)
            {
                btnEsquerda.SetActive(false);
            }
        }
    }

    public void NivelPosterior()
    {

    }
}

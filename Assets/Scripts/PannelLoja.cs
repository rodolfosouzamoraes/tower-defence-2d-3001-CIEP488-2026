using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PannelLoja : MonoBehaviour
{
    public PoderSO[] poderes;
    public TorreSO[] torres;
    public GameObject itemPoder;
    public GameObject itemTorre;
    public Transform contentTorre;
    public Transform contentPoder;
    public TextMeshProUGUI txtMoedas;
    public GameObject pnlCompraTorre;
    private List<GameObject> listaTorres = new List<GameObject>(); //Referencia dos itens no content
    private List<GameObject> listaPoderes = new List<GameObject>();
    private int moedasJogador;
    private void OnEnable()
    {
        AtualizarMoedas();
        //Verificar se a lista de torres e poderes já foi preenchida
        if (listaTorres.Count > 0)
        {
            // Se a lista tiver preenchida, eu devo apagar todos os elementos e inserir novamente
            foreach (GameObject item in listaTorres)
            {
                Destroy(item);
            }
            listaTorres.Clear();
        }

        if (listaPoderes.Count > 0)
        {
            foreach (GameObject item in listaPoderes)
            {
                Destroy(item);
            }
            listaPoderes.Clear();
        }

        //preencher a lista com os dados atualizados
        foreach (TorreSO torreSO in torres)
        {
            GameObject item = Instantiate(itemTorre, contentTorre);
            item.GetComponent<ItemTorre>().Init(torreSO.torre, torreSO.icone);
            listaTorres.Add(item);
        }

        foreach (PoderSO poderSO in poderes)
        {
            GameObject item = Instantiate(itemPoder, contentPoder);
            item.GetComponent<ItemPoder>().Init(poderSO.poder, poderSO.icone);
            listaPoderes.Add(item);
        }
    }

    public void ComprarTorre(Torre novaTorre)
    {
        pnlCompraTorre.SetActive(true);
        pnlCompraTorre.GetComponent<PannelCompraTorre>().Init(novaTorre);
    }

    public void AtualizarMoedas()
    {
        CanvasMenuMng.Instance.AtualizarDadosJogador();
        moedasJogador = CanvasMenuMng.Instance.DadosJogador.totalMoedas;
        txtMoedas.text = $"${moedasJogador}";
    }
}

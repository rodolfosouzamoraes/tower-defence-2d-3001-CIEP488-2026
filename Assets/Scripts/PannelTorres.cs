using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PannelTorres : MonoBehaviour
{
    public Transform contentTorres;
    public TextMeshProUGUI txtQtdTorresAtivas;
    public GameObject itemUpgradeTorre;
    public TextMeshProUGUI txtMoedas;
    private List<GameObject> listaTorres = new List<GameObject>();
    int totalTorresAtivas;
    int totalMoedas;
    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        //Configura a informação das torres ativas
        totalTorresAtivas = DBMng.TotalTorresAtivas();
        txtQtdTorresAtivas.text = $"{totalTorresAtivas}/{Constants.limiteMaximoTorresAtivas}";

        //Configura a informação das moedas
        totalMoedas = DBMng.ObterMoedasPlayer();
        txtMoedas.text = $"${totalMoedas}";

        //Limpar a lista de torres para poder atualizar
        foreach(GameObject item in listaTorres)
        {
            Destroy(item);
        }
        listaTorres.Clear();

        //Configura a lista de torres que o jogador possui
        List<Torre> listaTorresPlayer = DBMng.ObterTorresPlayer();
        foreach (Torre torre in listaTorresPlayer)
        {
            GameObject item = Instantiate(itemUpgradeTorre, contentTorres);
            TorreSO torreSO = CanvasMenuMng.Instance.torres.ToList().Find(torreSO => torreSO.torre.id == torre.id);
            Sprite icone = torreSO.icone;

            item.GetComponent<ItemUpgradeTorre>().Init(torre, icone);
            listaTorres.Add(item);
        }
    }
}

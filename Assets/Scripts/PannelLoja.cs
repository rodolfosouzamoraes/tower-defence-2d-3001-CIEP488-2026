using System.Collections.Generic;
using UnityEngine;

public class PannelLoja : MonoBehaviour
{
    public PoderSO[] poderes;
    public TorreSO[] torres;
    public GameObject itemPoder;
    public GameObject itemTorre;
    public Transform contentTorre;
    public Transform contentPoder;
    private List<GameObject> listaTorres = new List<GameObject>(); //Referencia dos itens no content
    private List<GameObject> listaPoderes = new List<GameObject>();

    private void OnEnable()
    {
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
}

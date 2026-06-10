using UnityEngine;
using UnityEngine.UI;

public class BotaoTorreMapa : MonoBehaviour
{
    public int id;
    public Image iconeTorre;
    public GameObject txtPlus;
    private Torre torreAtiva;
    private bool estaComTorre;

    public void AbrirSelecaoTorres()
    {
        CanvasMapaMng.Instance.ExibirTorresDisponiveis(id);
    }

    public void DefinirTorre(Torre novaTorre)
    {
        torreAtiva = novaTorre;
        iconeTorre.sprite = GameManager.GameData.torres.Find(
            torreSO => torreSO.torre.id == novaTorre.id
        ).icone;
        estaComTorre = true;
        txtPlus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

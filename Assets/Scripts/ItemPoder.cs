using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPoder : MonoBehaviour
{
    public Image imgIcone;
    public TextMeshProUGUI txtQtd;
    public TextMeshProUGUI txtPreco;
    private Poder poder;

    public void Init(Poder novoPoder, Sprite icone)
    {
        poder = novoPoder;
        imgIcone.sprite = icone;
        txtQtd.text = $"{poder.quantidade}/1";
        txtPreco.text = $"${poder.preco}";
    }
    
    public void Comprar()
    {

    }
}

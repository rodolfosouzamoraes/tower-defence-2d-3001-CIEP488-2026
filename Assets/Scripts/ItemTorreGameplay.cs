using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTorreGameplay : MonoBehaviour
{
    public Image imgIcone;
    public TextMeshProUGUI txtNivel;
    public TextMeshProUGUI txtNome;
    public TextMeshProUGUI txtVelocidade;
    public TextMeshProUGUI txtAtaque;
    public TextMeshProUGUI txtPreco;
    public Image imgBotaoCompra;
    public Color corOn;
    public Color corOff;
    private Torre torre;
    public Torre Torre { set { torre = value; } get { return torre; } }

    public void Init(Torre novaTorre, Sprite icone)
    {
        torre = novaTorre;
        imgIcone.sprite = icone;
        txtNivel.text = $"Nv. {(torre.nivel == Constants.NIVEL_MAXIMO_TORRE ? "MAX" : torre.nivel)}";
        txtNome.text = torre.nome;
        txtVelocidade.text = $"Velocidade: {(int)torre.velocidadeAtaque}";
        txtAtaque.text = $"Ataque: {(int)torre.poderAtaque}";
        txtPreco.text = $"${torre.preco}";
        //imgBotaoCompra.color =
    }
    

}

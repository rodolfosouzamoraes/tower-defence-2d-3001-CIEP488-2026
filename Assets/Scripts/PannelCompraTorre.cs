using TMPro;
using UnityEngine;

public class PannelCompraTorre : MonoBehaviour
{
    public TextMeshProUGUI txtTexto;
    public GameObject btnConfirmar;
    public GameObject btnCancelar;
    public GameObject btnOk;

    private Torre torreDesejada;
    public void Init(Torre novaTorre)
    {
        torreDesejada = novaTorre;

        txtTexto.text = $"Deseja comprar a torre {torreDesejada.nome} por ${torreDesejada.preco}?";
        btnConfirmar.SetActive(true);
        btnCancelar.SetActive(true);
        btnOk.SetActive(false);
    }

    public void ConfirmarCompra()
    {
        bool compraConfirmada = DBMng.ComprarTorre(torreDesejada);
        if (compraConfirmada == true)
        {
            AtivarMensagemConfirmacao("Torre comprada!");
            FindAnyObjectByType<PannelLoja>().AtualizarMoedas();
        }
        else
        {
            AtivarMensagemConfirmacao("Não foi possível comprar a torre, verifique o saldo!");
        }
    }

    private void AtivarMensagemConfirmacao(string mensagem)
    {
        txtTexto.text = mensagem;
        btnConfirmar.SetActive(false);
        btnCancelar.SetActive(false);
        btnOk.SetActive(true);
    }

    public void FecharPainel()
    {
        gameObject.SetActive(false);
    }
}

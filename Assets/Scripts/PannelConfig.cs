using UnityEngine;
using UnityEngine.UI;

public class PannelConfig : MonoBehaviour
{
    public Slider sldMusica;
    public Slider sldSFX;

    private void OnEnable()
    {
        Configuracao config = CanvasMenuMng.Instance.DadosJogador.configuracoes;

        sldMusica.value = config.volumeMusica;
        sldSFX.value = config.volumeSFX;
    }
    public void AlterarVolumeSliderMusica()
    {
        DBMng.SalvarVolumes(sldMusica.value, sldSFX.value);
        CanvasMenuMng.Instance.AtualizarDadosJogador();
    }
    public void AlterarVolumeSliderSFX()
    {
        DBMng.SalvarVolumes(sldMusica.value, sldSFX.value);
        CanvasMenuMng.Instance.AtualizarDadosJogador();
    }
}

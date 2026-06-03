using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public AudioSource audioMusica;
    public AudioSource audioSFX;

    public void AtualizarVolumes(float volumeMusica, float volumeSFX)
    {
        audioMusica.volume = volumeMusica;
        audioSFX.volume = volumeSFX;

        //Atualizar volumes na memoria
        DBMng.SalvarVolumes(volumeMusica, volumeSFX);
    }
}

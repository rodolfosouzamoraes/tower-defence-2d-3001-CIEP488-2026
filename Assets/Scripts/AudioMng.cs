using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

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

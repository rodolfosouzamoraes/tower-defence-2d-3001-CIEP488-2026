using UnityEngine;
using UnityEngine.UI;

public class PnlPoderes : MonoBehaviour
{
    [SerializeField] Image[] imgBtns;

    private Animator animator;
    private bool estaAberto = false;

    [SerializeField] private Poder[] poderesPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        poderesPlayer = DBMng.ObterTodosPoderesPlayer();
        for (int i = 0; i < poderesPlayer.Length; i++)
        {
            imgBtns[i].sprite = GameManager.GameData.poderes[i].icone;
        }

    }

    public void ExibirOuOcultarPainel()
    {
        if (estaAberto == false)
        {
            animator.SetBool("exibirPainel", true);
            estaAberto = true;
        }
        else
        {
            animator.SetBool("exibirPainel", false);
            estaAberto = false;
        }

    }

    public void InvocarPoder(int id)
    {
        switch (id)
        {
            case 1:
                break;
            case 2:
                CanvasGameMng.PannelGamePlay.IncrementarVidaJogador(Constants.PORCENTAGEM_RECUPERACAO_VIDA);
                break;
            case 3:
                break;
        }
    }
    
}

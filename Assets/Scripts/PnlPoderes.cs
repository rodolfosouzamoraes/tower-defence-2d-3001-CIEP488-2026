using UnityEngine;
using UnityEngine.UI;

public class PnlPoderes : MonoBehaviour
{
    [SerializeField] Image[] imgBtns;

    private Animator animator;
    private bool estaAberto = false;

    private Poder[] poderesPlayer;
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
    
}

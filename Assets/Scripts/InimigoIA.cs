using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public float velocidade;
    private Waypoint destino;
    private bool habilitaMovimentacao;
    private float velocidadeOriginal;

    private void Start()
    {
        velocidadeOriginal = velocidade;
    }

    public void DefinirNovoDestino(Waypoint novoDestino)
    {
        destino = novoDestino;
        habilitaMovimentacao = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (habilitaMovimentacao == false) return;
        transform.position = Vector2.MoveTowards(
            transform.position,
            destino.transform.position,
            velocidade * Time.deltaTime);   

        if(Vector2.Distance(transform.position,destino.transform.position) < 0.01f)
        {
            if(destino == destino.ObterProximoDestino())
            {
                habilitaMovimentacao = false;
            }
            else
            {
                destino = destino.ObterProximoDestino();
            }            
        }
    }

    public void CongelarInimigo()
    {
        velocidade = 0;
    }

    public void DescongelarInimigo()
    {
        velocidade = velocidadeOriginal;
    }
}

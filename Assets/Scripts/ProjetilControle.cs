using UnityEngine;

public class ProjetilControle : MonoBehaviour
{
    private float dano;
    public float Dano
    {
        get { return dano; }
    }

    public void Init(float porcentagemDano)
    {
        dano = Constants.VALOR_PADRAO_DANO_PROJETIL * porcentagemDano;
    }
}

using System.Collections.Generic;
using UnityEngine;

public static class DBMng
{
    //Endereço para salvar os dados
    private const string dadosJogadorChave = "DadosJogador";

    //Método para poder obter os dados do jogador
    public static Jogador CarregarDadosJogador()
    {
        //Pegar os dados salvos
        string dadosJson = PlayerPrefs.GetString(dadosJogadorChave);
        //Verificar se os dados existem, caso não exista, criar um novo objeto de jogador
        if (string.IsNullOrEmpty(dadosJson))
        {
            //Criar um novo jogador
            Jogador novoJogador = new Jogador
            {
                configuracoes = new Configuracao(),
                niveisCompletados = new List<Nivel>(),
                torresCompradas = new List<Torre>(),
                poderesComprados = new List<Poder>(),
                totalMoedas = 50000
            };
            //Configurar as variaveis com valores iniciais
            novoJogador.configuracoes.volumeMusica = 0.5f;
            novoJogador.configuracoes.volumeSFX = 1f;
            Torre torreInicial = new Torre();
            torreInicial.id = 1;
            SalvarDadosJogador(novoJogador);
        }
        //Obter novamente os dados salvos
        dadosJson = PlayerPrefs.GetString(dadosJogadorChave);
        //retornar os dados do jogador
        return JsonUtility.FromJson<Jogador>(dadosJson);
    }

    public static void SalvarDadosJogador(Jogador jogador)
    {
        //Converter o objeto jogador para JSON
        string dadosJson = JsonUtility.ToJson(jogador);
        //Salvar os dados usando PlayerPrefs
        PlayerPrefs.SetString(dadosJogadorChave, dadosJson);
        PlayerPrefs.Save();
    }

    public static void SalvarVolumes(float volumeMusica, float volumeSFX)
    {
        //Carregar os dados do jogador
        Jogador jogador = CarregarDadosJogador();
        //Atualizar os volumes na configuração do jogador
        jogador.configuracoes.volumeMusica = volumeMusica;
        jogador.configuracoes.volumeSFX = volumeSFX;
        //Salvar os dados atualizados do jogador
        SalvarDadosJogador(jogador);
    }

    public static void AdicionarNivel(int nivelId)
    {
        //Carregar os dados do jogador
        Jogador jogador = CarregarDadosJogador();
        if(jogador.niveisCompletados.Exists(nivel => nivel.id == nivelId))
        {
            Debug.LogWarning("O nível já foi completado anteriormente.");
            return; // O nível já foi completado, não precisa adicionar novamente
        }
        //Adicionar o nível completado à lista de níveis do jogador
        jogador.niveisCompletados.Add(new Nivel { id = nivelId });
        //Salvar os dados atualizados do jogador
        SalvarDadosJogador(jogador);

    }

    public static bool ComprarTorre(Torre novaTorre)
    {
        try
        {
            //Buscar os dados do jogador
            Jogador jogador = CarregarDadosJogador();
            //Verificar se a torre já foi comprada
            if (jogador.torresCompradas.Exists(torre => torre.id == novaTorre.id))
            {
                Debug.LogWarning("A torre já foi comprada anteriormente.");
                return false;
            }
            //Verificar se o jogador tem moedas suficientes para comprar a torre
            if (jogador.totalMoedas < novaTorre.preco)
            {
                Debug.LogWarning("Moedas insuficientes para comprar a torre.");
                return false;
            }
            else
            {
                jogador.totalMoedas -= novaTorre.preco; //Deduzir o preço da torre das moedas do jogador
                jogador.torresCompradas.Add(novaTorre); //Adicionar a torre comprada à lista de torres do jogador
                SalvarDadosJogador(jogador); //Salvar os dados atualizados do jogador
                return true;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Erro ao comprar torre: {ex.Message}");
            return false;
        }
    }

}

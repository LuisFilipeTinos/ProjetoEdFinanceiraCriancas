using System;
using TMPro;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider colliderFinalQuest;
    [SerializeField] private BoxCollider colliderInicialQuest;

    public GameObject[] BalaoMissoes; // Array com os bal�es de miss�o
    public GameObject BotaoContinuar;
    public GameObject BotaoSair;
    public GameObject ImagemMissao; // Imagem exibida ao sair do BalaoMissao3
    public TextMeshProUGUI MoneyText;

    private int currentBalao = 0; // �ndice do bal�o atual
    private bool missaoConcluida = false; // Estado da miss�o

    private void Start()
    {
        // Garante que todos os bal�es e a imagem de miss�o est�o escondidos no in�cio
        foreach (GameObject balao in BalaoMissoes)
        {
            balao.SetActive(false);
        }
        ImagemMissao.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoSair.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se a miss�o j� foi conclu�da
        if (missaoConcluida) return;

        if (other.gameObject.CompareTag("Casa Blue"))
        {
            MostrarBalao(0); // Mostra o BalaoMissao1
            colliderFinalQuest.enabled = true;
            colliderInicialQuest.enabled = false;
        }
        else if (other.gameObject.CompareTag("Casa Red"))
        {
            ConcluirMissaoCasaVermelha();
        }
    }

    public void MostrarBalao(int index)
    {
        // Esconde todos os bal�es
        foreach (GameObject balao in BalaoMissoes)
        {
            balao.SetActive(false);
        }

        // Ativa o bal�o correspondente
        if (index >= 0 && index < BalaoMissoes.Length)
        {
            BalaoMissoes[index].SetActive(true);
            currentBalao = index;

            // Configura os bot�es de acordo com o bal�o
            if (index == 2 || index == 5) // Bal�o 3 e 6 t�m o bot�o de sair
            {
                BotaoContinuar.SetActive(false);
                BotaoSair.SetActive(true);
            }
            else
            {
                BotaoContinuar.SetActive(true);
                BotaoSair.SetActive(false);
            }
        }
    }

    public void ContinuarMissao()
    {
        if (currentBalao + 1 < BalaoMissoes.Length)
        {
            MostrarBalao(currentBalao + 1); // Passa para o pr�ximo bal�o
        }
    }

    public void SairMissao()
    {
        // Fecha o bal�o atual
        if (currentBalao >= 0 && currentBalao < BalaoMissoes.Length)
        {
            BalaoMissoes[currentBalao].SetActive(false);
        }

        BotaoSair.SetActive(false); // Garante que o bot�o de sair seja escondido

        if (currentBalao == 2) // Caso seja o BalaoMissao3
        {
            ImagemMissao.SetActive(true); // Mostra a imagem de miss�o
        }
        else if (currentBalao == 5) // Caso seja o BalaoMissao6
        {
            Debug.Log("Miss�o encerrada.");
        }
    }

    public void ConcluirMissaoCasaVermelha()
    {
        // Atualiza o dinheiro
        int dinheiroAtual = int.Parse(MoneyText.text);
        dinheiroAtual += 50; // Incrementa o valor
        MoneyText.text = dinheiroAtual.ToString();

        // Esconde a imagem de miss�o e mostra o pr�ximo bal�o (BalaoMissao4)
        ImagemMissao.SetActive(false);
        MostrarBalao(3); // Exibe o BalaoMissao4

        // Marca a miss�o como conclu�da
        missaoConcluida = true;
    }
}

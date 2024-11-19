using System;
using TMPro;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider colliderFinalQuest;
    [SerializeField] private BoxCollider colliderInicialQuest;

    public GameObject[] BalaoMissoes; // Array com os balões de missão
    public GameObject BotaoContinuar;
    public GameObject BotaoSair;
    public GameObject ImagemMissao; // Imagem exibida ao sair do BalaoMissao3
    public TextMeshProUGUI MoneyText;

    private int currentBalao = 0; // Índice do balão atual
    private bool missaoConcluida = false; // Estado da missão

    private void Start()
    {
        // Garante que todos os balões e a imagem de missão estão escondidos no início
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
        // Verifica se a missão já foi concluída
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
        // Esconde todos os balões
        foreach (GameObject balao in BalaoMissoes)
        {
            balao.SetActive(false);
        }

        // Ativa o balão correspondente
        if (index >= 0 && index < BalaoMissoes.Length)
        {
            BalaoMissoes[index].SetActive(true);
            currentBalao = index;

            // Configura os botões de acordo com o balão
            if (index == 2 || index == 5) // Balão 3 e 6 têm o botão de sair
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
            MostrarBalao(currentBalao + 1); // Passa para o próximo balão
        }
    }

    public void SairMissao()
    {
        // Fecha o balão atual
        if (currentBalao >= 0 && currentBalao < BalaoMissoes.Length)
        {
            BalaoMissoes[currentBalao].SetActive(false);
        }

        BotaoSair.SetActive(false); // Garante que o botão de sair seja escondido

        if (currentBalao == 2) // Caso seja o BalaoMissao3
        {
            ImagemMissao.SetActive(true); // Mostra a imagem de missão
        }
        else if (currentBalao == 5) // Caso seja o BalaoMissao6
        {
            Debug.Log("Missão encerrada.");
        }
    }

    public void ConcluirMissaoCasaVermelha()
    {
        // Atualiza o dinheiro
        int dinheiroAtual = int.Parse(MoneyText.text);
        dinheiroAtual += 50; // Incrementa o valor
        MoneyText.text = dinheiroAtual.ToString();

        // Esconde a imagem de missão e mostra o próximo balão (BalaoMissao4)
        ImagemMissao.SetActive(false);
        MostrarBalao(3); // Exibe o BalaoMissao4

        // Marca a missão como concluída
        missaoConcluida = true;
    }
}

using UnityEngine;

public class ExibirBalao : MonoBehaviour
{
    public GameObject BalaoFala;        // Referência ao balão de fala
    public GameObject BalaoFala2;      // Referência ao segundo balão de fala
    public GameObject BalaoFala3;      // Referência ao terceiro balão de fala
    public GameObject BalaoFala4;      // Referência ao quarto balão de fala
    public GameObject BotaoContinuar;  // Referência ao botão de continuar
    public GameObject BotaoVoltar;     // Referência ao botão de voltar
    public GameObject BotaoSair;       // Referência ao botão de sair
    public float delay = 10f;          // Tempo de espera em segundos

    private int estadoAtual = 0;       // Controle do estado atual

    private void Start()
    {
        // Garante que todos os balões e botões estão escondidos no início
        BalaoFala.SetActive(false);
        BalaoFala2.SetActive(false);
        BalaoFala3.SetActive(false);
        BalaoFala4.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoVoltar.SetActive(false);
        BotaoSair.SetActive(false);

        // Inicia o ciclo de exibição
        Invoke("MostrarProximoBalao", delay);
    }

    private void MostrarProximoBalao()
    {
        // Esconde todos os balões e botões antes de atualizar
        BalaoFala.SetActive(false);
        BalaoFala2.SetActive(false);
        BalaoFala3.SetActive(false);
        BalaoFala4.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoVoltar.SetActive(false);
        BotaoSair.SetActive(false);

        // Verifica o estado atual e exibe os balões e botões correspondentes
        switch (estadoAtual)
        {
            case 0:
                BalaoFala.SetActive(true);
                BotaoContinuar.SetActive(true);
                break;

            case 1:
                BalaoFala2.SetActive(true);
                BotaoContinuar.SetActive(true);
                BotaoVoltar.SetActive(true);
                break;

            case 2:
                BalaoFala3.SetActive(true);
                BotaoContinuar.SetActive(true);
                BotaoVoltar.SetActive(true);
                break;

            case 3:
                BalaoFala4.SetActive(true);
                BotaoSair.SetActive(true);
                BotaoVoltar.SetActive(true);
                break;
        }
    }

    public void BotaoContinuarClicado()
    {
        if (estadoAtual < 3)
        {
            estadoAtual++;
            MostrarProximoBalao();
        }
    }

    public void BotaoVoltarClicado()
    {
        if (estadoAtual > 0)
        {
            estadoAtual--;
            MostrarProximoBalao();
        }
    }

    public void BotaoSairClicado()
    {
        BotaoContinuar.SetActive(false);
        BotaoVoltar.SetActive(false);
        BotaoSair.SetActive(false);

        // Esconde o balão de fala atual
        switch (estadoAtual)
        {
            case 0:
                BalaoFala.SetActive(false);
                break;
            case 1:
                BalaoFala2.SetActive(false);
                break;
            case 2:
                BalaoFala3.SetActive(false);
                break;
            case 3:
                BalaoFala4.SetActive(false);
                break;
        }

        Debug.Log("Balão fechado pelo botão Sair.");
    }

}

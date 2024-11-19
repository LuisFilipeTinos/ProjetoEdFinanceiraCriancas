using UnityEngine;

public class ExibirBalao : MonoBehaviour
{
    public GameObject BalaoFala;        // Refer�ncia ao bal�o de fala
    public GameObject BalaoFala2;      // Refer�ncia ao segundo bal�o de fala
    public GameObject BalaoFala3;      // Refer�ncia ao terceiro bal�o de fala
    public GameObject BalaoFala4;      // Refer�ncia ao quarto bal�o de fala
    public GameObject BotaoContinuar;  // Refer�ncia ao bot�o de continuar
    public GameObject BotaoVoltar;     // Refer�ncia ao bot�o de voltar
    public GameObject BotaoSair;       // Refer�ncia ao bot�o de sair
    public float delay = 10f;          // Tempo de espera em segundos

    private int estadoAtual = 0;       // Controle do estado atual

    private void Start()
    {
        // Garante que todos os bal�es e bot�es est�o escondidos no in�cio
        BalaoFala.SetActive(false);
        BalaoFala2.SetActive(false);
        BalaoFala3.SetActive(false);
        BalaoFala4.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoVoltar.SetActive(false);
        BotaoSair.SetActive(false);

        // Inicia o ciclo de exibi��o
        Invoke("MostrarProximoBalao", delay);
    }

    private void MostrarProximoBalao()
    {
        // Esconde todos os bal�es e bot�es antes de atualizar
        BalaoFala.SetActive(false);
        BalaoFala2.SetActive(false);
        BalaoFala3.SetActive(false);
        BalaoFala4.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoVoltar.SetActive(false);
        BotaoSair.SetActive(false);

        // Verifica o estado atual e exibe os bal�es e bot�es correspondentes
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

        // Esconde o bal�o de fala atual
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

        Debug.Log("Bal�o fechado pelo bot�o Sair.");
    }

}

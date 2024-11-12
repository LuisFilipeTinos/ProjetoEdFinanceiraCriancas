using UnityEngine;

public class ExibirBalao : MonoBehaviour
{
    public GameObject BalaoFala;     // Refer�ncia ao bal�o de fala
    public GameObject BotaoSair;     // Refer�ncia ao bot�o de sair
    public float delay = 10f;        // Tempo de espera em segundos

    private void Start()
    {
        // Garantir que ambos os objetos est�o escondidos no in�cio
        BalaoFala.SetActive(false);
        BotaoSair.SetActive(false);

        // Inicia a chamada para mostrar o bal�o e o bot�o ap�s o delay
        Invoke("MostrarBalaoEBotao", delay);
    }

    private void MostrarBalaoEBotao()
    {
        // Ativa o bal�o de fala e o bot�o de sair
        BalaoFala.SetActive(true);
        BotaoSair.SetActive(true);
    }

    public void FecharBalao()
    {
        // Desativa o bal�o de fala e o bot�o de sair
        BalaoFala.SetActive(false);
        BotaoSair.SetActive(false);
    }
}

using UnityEngine;

public class ExibirBalao : MonoBehaviour
{
    public GameObject BalaoFala;     // Referência ao balão de fala
    public GameObject BotaoSair;     // Referência ao botão de sair
    public float delay = 10f;        // Tempo de espera em segundos

    private void Start()
    {
        // Garantir que ambos os objetos estão escondidos no início
        BalaoFala.SetActive(false);
        BotaoSair.SetActive(false);

        // Inicia a chamada para mostrar o balão e o botão após o delay
        Invoke("MostrarBalaoEBotao", delay);
    }

    private void MostrarBalaoEBotao()
    {
        // Ativa o balão de fala e o botão de sair
        BalaoFala.SetActive(true);
        BotaoSair.SetActive(true);
    }

    public void FecharBalao()
    {
        // Desativa o balão de fala e o botão de sair
        BalaoFala.SetActive(false);
        BotaoSair.SetActive(false);
    }
}

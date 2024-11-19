using UnityEngine;
using System.Collections; // Necessário para usar IEnumerator

public class MissaoManager : MonoBehaviour
{
    public GameObject telaMissao; // Referência à tela de missão
    public GameObject botaoMissao; // Referência ao botão de missão

    void Start()
    {
        // Garante que o botão de missão esteja inicialmente desativado
        if (botaoMissao != null)
        {
            botaoMissao.SetActive(false);
        }

        // Inicia a corrotina para ativar o botão após 1m30s
        StartCoroutine(AparecerBotaoMissao());
    }

    // Exibe a tela de missão
    public void AbrirMissao()
    {
        telaMissao.SetActive(true);
    }

    // Fecha a tela de missão
    public void FecharMissao()
    {
        telaMissao.SetActive(false);
    }

    // Corrotina para ativar o botão de missão após 1m30s
    private IEnumerator AparecerBotaoMissao()
    {
        yield return new WaitForSeconds(30f); // Aguarda 90 segundos
        if (botaoMissao != null)
        {
            botaoMissao.SetActive(true); // Ativa o botão de missão
        }
    }
}

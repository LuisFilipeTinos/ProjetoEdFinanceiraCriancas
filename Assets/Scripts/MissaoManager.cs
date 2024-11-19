using UnityEngine;
using System.Collections; // Necess�rio para usar IEnumerator

public class MissaoManager : MonoBehaviour
{
    public GameObject telaMissao; // Refer�ncia � tela de miss�o
    public GameObject botaoMissao; // Refer�ncia ao bot�o de miss�o

    void Start()
    {
        // Garante que o bot�o de miss�o esteja inicialmente desativado
        if (botaoMissao != null)
        {
            botaoMissao.SetActive(false);
        }

        // Inicia a corrotina para ativar o bot�o ap�s 1m30s
        StartCoroutine(AparecerBotaoMissao());
    }

    // Exibe a tela de miss�o
    public void AbrirMissao()
    {
        telaMissao.SetActive(true);
    }

    // Fecha a tela de miss�o
    public void FecharMissao()
    {
        telaMissao.SetActive(false);
    }

    // Corrotina para ativar o bot�o de miss�o ap�s 1m30s
    private IEnumerator AparecerBotaoMissao()
    {
        yield return new WaitForSeconds(30f); // Aguarda 90 segundos
        if (botaoMissao != null)
        {
            botaoMissao.SetActive(true); // Ativa o bot�o de miss�o
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Referências aos elementos do Canvas
    public GameObject botaoVoltar;
    public GameObject telaCreditos;
    public GameObject fundo;
    public GameObject botaoJogar;
    public GameObject botaoCreditos;
    public GameObject botaoSair;

    void Start()
    {
        // Inicialmente, mostra o menu principal e esconde a tela de créditos e o botão de voltar
        MostrarMenuPrincipal();
    }

    // Função para exibir o menu principal
    void MostrarMenuPrincipal()
    {
        botaoVoltar.SetActive(false); // Esconde o botão "Voltar"
        telaCreditos.SetActive(false); // Esconde a tela de créditos
        fundo.SetActive(true); // Garante que o fundo permanece ativo
        botaoJogar.SetActive(true); // Mostra o botão "Jogar"
        botaoCreditos.SetActive(true); // Mostra o botão "Créditos"
        botaoSair.SetActive(true); // Mostra o botão "Sair"
        Debug.Log("Menu Principal Mostrado");
    }

    // Função para o botão "JOGAR"
    public void Jogar()
    {
        Debug.Log("Botão Jogar pressionado");
        // Carrega a cena chamada "Tela Inicial"
        SceneManager.LoadScene("Tela Inicial - Tutorial");
    }

    // Função para o botão "CRÉDITOS"
    public void MostrarCreditos()
    {
        Debug.Log("Botão Créditos pressionado");
        // Exibe a tela de créditos e o botão de voltar, e esconde os botões do menu principal
        botaoVoltar.SetActive(true); // Mostra o botão "Voltar"
        telaCreditos.SetActive(true); // Mostra a tela de créditos
        botaoJogar.SetActive(false); // Esconde o botão "Jogar"
        botaoCreditos.SetActive(false); // Esconde o botão "Créditos"
        botaoSair.SetActive(false); // Esconde o botão "Sair"
    }

    // Função para o botão "VOLTAR" no painel de créditos
    public void VoltarParaMenu()
    {
        Debug.Log("Botão Voltar pressionado");
        // Volta para o menu principal
        MostrarMenuPrincipal();
    }

    // Função para o botão "SAIR"
    public void SairDoJogo()
    {
        Debug.Log("Botão Sair pressionado");
        // Sai do jogo (só funciona em builds, não no editor)
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para o jogo no editor
#endif
    }
}

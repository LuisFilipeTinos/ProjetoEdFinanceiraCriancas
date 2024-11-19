using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    public GameObject TelaResultado; // O painel que vai mostrar o resultado
    public TextMeshProUGUI TextoResultado; // O texto que vai exibir a mensagem (GANHOU ou PERDEU)
    public TextMeshProUGUI MoneyText; // Refer�ncia ao texto que exibe o dinheiro atual

    // M�todo para exibir o resultado quando o bot�o for clicado
    public void ExibirResultado()
    {
        // Obtemos o valor do dinheiro do texto
        int dinheiroAtual = int.Parse(MoneyText.text);

        // Verificamos o valor do dinheiro e atualizamos o texto de resultado
        if (dinheiroAtual >= 150)
        {
            TextoResultado.text = "GANHOU";
        }
        else
        {
            TextoResultado.text = "PERDEU";
        }

        // Exibimos a tela de resultado
        TelaResultado.SetActive(true);
    }

    // M�todo para esconder a tela de resultado (por exemplo, se o jogador clicar em um bot�o de "Fechar")
    public void FecharResultado()
    {
        TelaResultado.SetActive(false);
    }
}

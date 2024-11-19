using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Para carregar a cena
using System.Collections;

public class DaySkipSystem : MonoBehaviour
{
    public GameObject skipButton;       // Botão de pular que aparece após 1 minuto
    public GameObject skipPanel;        // Painel com a opção de pular de dia
    public Button skipDayButton;        // Botão que vai pular para a próxima cena
    public Button cancelButton;         // Botão para cancelar o pular de dia
    public float timeToWait = 60f;      // Tempo em segundos para o botão aparecer (1 minuto)

    private void Start()
    {
        skipButton.SetActive(false);    // Inicialmente o botão de pular está oculto
        skipPanel.SetActive(false);     // Inicialmente a tela de "Pular de Dia" está oculta
        StartCoroutine(ShowSkipButtonAfterTime());
    }

    // Corrotina para esperar 1 minuto antes de mostrar o botão
    private IEnumerator ShowSkipButtonAfterTime()
    {
        yield return new WaitForSeconds(timeToWait);  // Espera 1 minuto
        skipButton.SetActive(true);    // Torna o botão de pular visível após 1 minuto
    }

    // Função chamada quando o botão de Pular de Dia é pressionado
    public void OnSkipDayButtonClicked()
    {
        skipPanel.SetActive(true);   // Exibe a tela de "Pular de Dia"
    }

    // Função chamada quando o botão de Cancelar na tela de "Pular de Dia" é pressionado
    public void OnCancelButtonClicked()
    {
        skipPanel.SetActive(false);  // Fecha a tela de "Pular de Dia"
    }

    // Função chamada quando o botão de "Pular de Dia" é pressionado
    public void OnConfirmSkipDay()
    {
        // Aqui você pode colocar a lógica para carregar a próxima cena.
        // Exemplo: Se você quiser carregar uma cena chamada "NextDayScene":
        SceneManager.LoadScene("Jogo2");
    }
}

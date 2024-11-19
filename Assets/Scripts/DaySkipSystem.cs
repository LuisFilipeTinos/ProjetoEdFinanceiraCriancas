using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Para carregar a cena
using System.Collections;

public class DaySkipSystem : MonoBehaviour
{
    public GameObject skipButton;       // Bot�o de pular que aparece ap�s 1 minuto
    public GameObject skipPanel;        // Painel com a op��o de pular de dia
    public Button skipDayButton;        // Bot�o que vai pular para a pr�xima cena
    public Button cancelButton;         // Bot�o para cancelar o pular de dia
    public float timeToWait = 60f;      // Tempo em segundos para o bot�o aparecer (1 minuto)

    private void Start()
    {
        skipButton.SetActive(false);    // Inicialmente o bot�o de pular est� oculto
        skipPanel.SetActive(false);     // Inicialmente a tela de "Pular de Dia" est� oculta
        StartCoroutine(ShowSkipButtonAfterTime());
    }

    // Corrotina para esperar 1 minuto antes de mostrar o bot�o
    private IEnumerator ShowSkipButtonAfterTime()
    {
        yield return new WaitForSeconds(timeToWait);  // Espera 1 minuto
        skipButton.SetActive(true);    // Torna o bot�o de pular vis�vel ap�s 1 minuto
    }

    // Fun��o chamada quando o bot�o de Pular de Dia � pressionado
    public void OnSkipDayButtonClicked()
    {
        skipPanel.SetActive(true);   // Exibe a tela de "Pular de Dia"
    }

    // Fun��o chamada quando o bot�o de Cancelar na tela de "Pular de Dia" � pressionado
    public void OnCancelButtonClicked()
    {
        skipPanel.SetActive(false);  // Fecha a tela de "Pular de Dia"
    }

    // Fun��o chamada quando o bot�o de "Pular de Dia" � pressionado
    public void OnConfirmSkipDay()
    {
        // Aqui voc� pode colocar a l�gica para carregar a pr�xima cena.
        // Exemplo: Se voc� quiser carregar uma cena chamada "NextDayScene":
        SceneManager.LoadScene("Jogo2");
    }
}

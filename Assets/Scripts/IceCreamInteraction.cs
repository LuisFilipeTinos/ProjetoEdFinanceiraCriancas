using UnityEngine;
using TMPro;

public class IceCreamInteraction : MonoBehaviour
{
    public GameObject purchasePanel; // Painel de compra
    public TextMeshProUGUI moneyText; // Texto com o dinheiro atual do jogador
    public int iceCreamCost = 20; // Custo do sorvete

    private void Start()
    {
        purchasePanel.SetActive(false); // Garante que a UI está oculta no início
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sorvete"))
        {
            OpenPurchasePanel(); // Abre a tela de compra ao encostar no sorvete
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sorvete"))
        {
            ClosePurchasePanel(); // Fecha a tela de compra ao sair do alcance do sorvete
        }
    }

    public void OpenPurchasePanel()
    {
        purchasePanel.SetActive(true); // Exibe a tela de compra
    }

    public void ClosePurchasePanel()
    {
        purchasePanel.SetActive(false); // Fecha a tela de compra
    }

    public void BuyIceCream()
    {
        int currentMoney = int.Parse(moneyText.text);

        if (currentMoney >= iceCreamCost)
        {
            // Subtrai o custo do dinheiro atual
            currentMoney -= iceCreamCost;
            moneyText.text = currentMoney.ToString();

            Debug.Log("Você comprou um sorvete!");
        }
        else
        {
            Debug.Log("Dinheiro insuficiente para comprar o sorvete.");
        }

        ClosePurchasePanel(); // Fecha a tela após a compra
    }
}

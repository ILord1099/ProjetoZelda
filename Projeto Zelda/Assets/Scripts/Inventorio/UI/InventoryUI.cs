using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI inventoryText; // Arraste um objeto TextMeshProUGUI do Canvas aqui

    private Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        // Inscreve o método UpdateUI no evento de mudança do inventário
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI(); // Exibe os itens iniciais
    }

    void UpdateUI()
    {
        inventoryText.text = "Itens Coletados:\n";

        List<InventorySlot> slots = inventory.GetItems();

        foreach (var slot in slots)
        {
            inventoryText.text += $"{slot.item.name}: {slot.quantity}\n";
        }
    }
}

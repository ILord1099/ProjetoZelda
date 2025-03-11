using System.Collections.Generic;
using UnityEngine;

// Este script gerencia o inventário do jogador, armazenando os itens coletados e permitindo a adição e remoção de itens.

public class Inventory : MonoBehaviour
{
    public static Inventory instance; // Instância única do inventário (Singleton)

    private void Awake()
    {
        if (instance == null)
            instance = this; // Garante que apenas uma instância do inventário exista
        else
            Destroy(gameObject); // Destroi instâncias duplicadas
    }

    public List<InventorySlot> slots = new List<InventorySlot>(); // Lista que armazena os itens no inventário

    // Adiciona um item ao inventário
    public void AddItem(Item item, int quantity)
    {
        // Procura se o item já existe no inventário
        InventorySlot slot = slots.Find(s => s.item == item);

        if (slot != null && item.isStackable)
        {
            // Se o item é empilhável e já existe, aumenta a quantidade
            slot.quantity += quantity;
        }
        else
        {
            // Caso contrário, cria um novo slot para o item
            slots.Add(new InventorySlot(item, quantity));
        }
    }

    // Remove uma quantidade específica de um item do inventário
    public bool RemoveItem(Item item, int quantity)
    {
        InventorySlot slot = slots.Find(s => s.item == item);

        if (slot != null && slot.quantity >= quantity)
        {
            // Diminui a quantidade do item
            slot.quantity -= quantity;

            if (slot.quantity <= 0)
                slots.Remove(slot); // Remove o slot se a quantidade chegar a zero

            return true; // Remoção bem-sucedida
        }
        return false; // Falha ao remover o item (quantidade insuficiente ou item não encontrado)
    }
}

// Classe que define um slot do inventário, contendo um item e sua quantidade
[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int quantity;

    public InventorySlot(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}

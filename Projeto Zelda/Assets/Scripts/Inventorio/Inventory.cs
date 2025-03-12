using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory instance; // Instância única do inventário (Singleton)

    public List<InventorySlot> slots = new List<InventorySlot>(); // Lista que armazena os itens no inventário

    public event Action onItemChangedCallback; // Evento para notificar mudanças no inventário

    private void Awake()
    {
        if (instance == null)
            instance = this; // Garante que apenas uma instância do inventário exista
        else
            Destroy(gameObject); // Destroi instâncias duplicadas
    }

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

        onItemChangedCallback?.Invoke(); // Notifica o sistema que o inventário foi atualizado
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

            onItemChangedCallback?.Invoke(); // Notifica o sistema que o inventário foi atualizado
            return true; // Remoção bem-sucedida
        }
        return false; // Falha ao remover o item
    }

    public List<InventorySlot> GetItems()
    {
        return slots;
    }
}

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

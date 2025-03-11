using System.Collections.Generic;
using UnityEngine;

// Este script gerencia o invent�rio do jogador, armazenando os itens coletados e permitindo a adi��o e remo��o de itens.

public class Inventory : MonoBehaviour
{
    public static Inventory instance; // Inst�ncia �nica do invent�rio (Singleton)

    private void Awake()
    {
        if (instance == null)
            instance = this; // Garante que apenas uma inst�ncia do invent�rio exista
        else
            Destroy(gameObject); // Destroi inst�ncias duplicadas
    }

    public List<InventorySlot> slots = new List<InventorySlot>(); // Lista que armazena os itens no invent�rio

    // Adiciona um item ao invent�rio
    public void AddItem(Item item, int quantity)
    {
        // Procura se o item j� existe no invent�rio
        InventorySlot slot = slots.Find(s => s.item == item);

        if (slot != null && item.isStackable)
        {
            // Se o item � empilh�vel e j� existe, aumenta a quantidade
            slot.quantity += quantity;
        }
        else
        {
            // Caso contr�rio, cria um novo slot para o item
            slots.Add(new InventorySlot(item, quantity));
        }
    }

    // Remove uma quantidade espec�fica de um item do invent�rio
    public bool RemoveItem(Item item, int quantity)
    {
        InventorySlot slot = slots.Find(s => s.item == item);

        if (slot != null && slot.quantity >= quantity)
        {
            // Diminui a quantidade do item
            slot.quantity -= quantity;

            if (slot.quantity <= 0)
                slots.Remove(slot); // Remove o slot se a quantidade chegar a zero

            return true; // Remo��o bem-sucedida
        }
        return false; // Falha ao remover o item (quantidade insuficiente ou item n�o encontrado)
    }
}

// Classe que define um slot do invent�rio, contendo um item e sua quantidade
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

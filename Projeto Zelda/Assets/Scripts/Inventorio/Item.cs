using UnityEngine;

// Este script define os atributos básicos de um item que pode ser usado no jogo.
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;           // Nome do item (ex: "Madeira", "Ferro")
    public string description;        // Descrição do item para exibição no inventário
    public Sprite icon;               // Ícone do item que será mostrado na UI
    public bool isStackable;          // Define se o item pode ser empilhado (ex: Madeiras podem ser empilhadas, Espadas não)
}

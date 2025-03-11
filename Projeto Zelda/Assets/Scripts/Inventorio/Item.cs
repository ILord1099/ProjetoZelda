using UnityEngine;

// Este script define os atributos b�sicos de um item que pode ser usado no jogo.
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;           // Nome do item (ex: "Madeira", "Ferro")
    public string description;        // Descri��o do item para exibi��o no invent�rio
    public Sprite icon;               // �cone do item que ser� mostrado na UI
    public bool isStackable;          // Define se o item pode ser empilhado (ex: Madeiras podem ser empilhadas, Espadas n�o)
}

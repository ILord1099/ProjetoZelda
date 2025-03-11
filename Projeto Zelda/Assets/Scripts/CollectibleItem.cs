using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectibleItem : MonoBehaviour
{
    public Item item;  // O item que será coletado (arraste o ScriptableObject aqui no Inspector)
    public int quantity = 1;  // Quantidade do item a ser coletada

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Garante que é o jogador que está coletando
        {
            Inventory.instance.AddItem(item, quantity);  // Adiciona o item ao inventário
            Debug.Log($"Você coletou {quantity}x {item.itemName}");
            Destroy(gameObject);  // Remove o objeto da cena
        }
    }
}

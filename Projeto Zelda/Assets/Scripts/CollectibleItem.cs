using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectibleItem : MonoBehaviour
{
    public Item item;  // O item que ser� coletado (arraste o ScriptableObject aqui no Inspector)
    public int quantity = 1;  // Quantidade do item a ser coletada

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Garante que � o jogador que est� coletando
        {
            Inventory.instance.AddItem(item, quantity);  // Adiciona o item ao invent�rio
            Debug.Log($"Voc� coletou {quantity}x {item.itemName}");
            Destroy(gameObject);  // Remove o objeto da cena
        }
    }
}

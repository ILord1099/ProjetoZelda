using UnityEngine;

// Este script define as receitas de crafting, especificando os ingredientes necess�rios e o item resultante.
[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Inventory/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    // Estrutura que define um ingrediente necess�rio para uma receita
    [System.Serializable]
    public struct Ingredient
    {
        public Item item;        // O item necess�rio para a receita (ex: Madeira)
        public int quantity;      // Quantidade necess�ria desse item
    }

    public Ingredient[] ingredients;   // Ingredientes necess�rios para criar o item
    public Item resultItem;             // O item resultante da receita (ex: Espada de Madeira)
    public int resultQuantity;          // Quantidade do item resultante (ex: 1 Espada)
}

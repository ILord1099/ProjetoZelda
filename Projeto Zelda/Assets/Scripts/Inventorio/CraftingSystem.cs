using System.Collections.Generic;
using UnityEngine;

// Este script gerencia o processo de crafting (fabrica��o) usando receitas conhecidas.
public class CraftingSystem : MonoBehaviour
{
    public List<CraftingRecipe> knownRecipes; // Lista de receitas que o jogador aprendeu at� agora

    // Fun��o para tentar criar um item a partir de uma receita conhecida
    public bool CraftItem(CraftingRecipe recipe)
    {
        Inventory inventory = Inventory.instance; // Refer�ncia ao invent�rio do jogador

        // Verifica se o jogador possui todos os ingredientes necess�rios
        foreach (var ingredient in recipe.ingredients)
        {
            bool hasItem = inventory.slots.Exists(slot => slot.item == ingredient.item && slot.quantity >= ingredient.quantity);

            if (!hasItem)
            {
                Debug.Log("Ingredientes insuficientes.");
                return false; // Interrompe o crafting se faltar algum ingrediente
            }
        }

        // Remove os ingredientes necess�rios do invent�rio
        foreach (var ingredient in recipe.ingredients)
        {
            inventory.RemoveItem(ingredient.item, ingredient.quantity);
        }

        // Adiciona o item fabricado ao invent�rio
        inventory.AddItem(recipe.resultItem, recipe.resultQuantity);

        Debug.Log($"Fabricou {recipe.resultItem.itemName} com sucesso!");
        return true; // Crafting bem-sucedido
    }
}

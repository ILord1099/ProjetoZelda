using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    public Item madeira;   // Arraste o item "Madeira" criado no Inspector
    public Item ferro;     // Arraste o item "Ferro" criado no Inspector
    public CraftingRecipe espadaRecipe;  // Arraste a receita "Espada" criada no Inspector

    private Inventory inventory;
    private CraftingSystem craftingSystem;

    void Start()
    {
        inventory = Inventory.instance;
        craftingSystem = GetComponent<CraftingSystem>();

        // Adiciona itens ao inventário para teste
        inventory.AddItem(madeira, 0);
        inventory.AddItem(ferro, 0);

        // Mostra os itens adicionados no Console
        Debug.Log("Itens adicionados ao inventário.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Pressione a tecla C para tentar criar o item
        {
            Creating();
        }
    }

    void Creating()
    {
        // Tenta fabricar o item usando a receita
        bool crafted = craftingSystem.CraftItem(espadaRecipe);

        if (crafted)
            Debug.Log("Espada criada com sucesso!");
        else
            Debug.Log("Falha ao criar a espada.");
    }
}

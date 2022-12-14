using UnityEngine;
using System.Linq;

//Classe permettant de sauvegarder et de charger les données du joueur, comme le nombres de tacos, son inventaire etc.
public class LoadAndSaveData : MonoBehaviour
{
     public static LoadAndSaveData instance;

    //Singelton
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de LoadAndSaveData dans la scène");
           return;
       }

       instance = this; 
   }
   
   //Procédure permettant de récupérer les tacos et items récupérés par le joueur
    void Start()
    {
        Inventory.instance.tacoCount = PlayerPrefs.GetInt("TacosCount",0);
        Inventory.instance.UpdateTextUI();

        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }

        Inventory.instance.UpdateInventoryUI();

        /*int currentHealth = PlayerPrefs.GetInt("PlayerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/
    }

    //Procédure permettant de débloquer des niveaux en fonction de l'avancée du joueur et de sauvegarder les items et tacos récupérés
    public void SaveData()
    {
        PlayerPrefs.SetInt("TacosCount", Inventory.instance.tacoCount);
        PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);

        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        //PlayerPrefs.SetInt("PlayerHealth", PlayerHealth.instance.currentHealth);

        //sauvegarde
        string itemsInInventory = string.Join(",",Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);

    }

}

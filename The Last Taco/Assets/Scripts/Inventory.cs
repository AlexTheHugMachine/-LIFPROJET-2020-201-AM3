using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//Classe permettant de gérer l'affichage de l'inventaire du joueur et ses fonctionnalités
public class Inventory : MonoBehaviour
{
   public int tacoCount;
   public Text tacosCountText;

   public List<Item> content = new List<Item>();
   private int contentCurrentIndex = 0;
   public Image itemImageUI;
   public Text itemNameUI;
   public Sprite emptyItemImage;

   public PlayerEffects playereffects;

   public static Inventory instance;


    //Singleton
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de Inventory dans la scène");
           return;
       }

       instance = this; 

   }

    //Procédure initialisation
   private void Start()
   {
       UpdateInventoryUI();
   }


   //Procédure permettant l'utilisation d'un item et sa suppression de l'inventaire
   public void ConsumeItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       Item currenItem = content[0];
       PlayerHealth.instance.HealPlayer(currenItem.hpGiven);
       playereffects.AddSpedd(currenItem.speedGiven, currenItem.speedDuration);
       content.Remove(currenItem);
       GetNextItem();
       UpdateInventoryUI();
   }

   //Procédure permettant l'affichage de l'item suivant dans l'inventaire
   public void GetNextItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       contentCurrentIndex++;
       if (contentCurrentIndex > content.Count - 1)
       {
           contentCurrentIndex = 0;
       }
       UpdateInventoryUI();
   }

   //Procédure permettant l'affichage de l'item précédent dans l'inventaire
   public void GetPreviousItem()
   {
       if (content.Count == 0)
       {
           return;
       }

       contentCurrentIndex--;
       if (contentCurrentIndex < 0)
       {
           contentCurrentIndex = content.Count - 1;
       }
       UpdateInventoryUI();
   }

   //Procédure permettant l'affichage des items de l'inventaire
   public void UpdateInventoryUI()
   {
       if (content.Count > 0)
       {
           itemImageUI.sprite = content[contentCurrentIndex].image;
           itemNameUI.text = content[contentCurrentIndex].name;
       }
       else
       {
           itemImageUI.sprite = emptyItemImage;
           itemNameUI.text = "";
       }
   }

   //Procédure permettant la mise à jour du compteur de tacos
   public void AddTacos(int count)
   {
       tacoCount += count;
       UpdateTextUI();
   }

    //Procédure permettant la mise jour du nom de l'item
   public void UpdateTextUI()
   {
       tacosCountText.text = tacoCount.ToString();
   }

   //Procédure permettant la diminution du nombre de tacos lorsque le joueur en utilise pour acheter un item par exemple
   public void RemoveTacos(int count)
   {
        tacoCount -= count;
       tacosCountText.text = tacoCount.ToString();
   }
}

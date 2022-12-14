using UnityEngine;
using UnityEngine.UI;

//Classe permettant d'acheter un item à un marchand
public class SellButtonItem : MonoBehaviour
{
   public Text itemName;
   public Image itemImage;
   public Text itemPrice;

   public Item item;

   //Procédure permettant d'ajouter l'item acheté à l'inventaire du joueur
   public void BuyItem()
   {
      Inventory inventory = Inventory.instance;

      if (Inventory.instance.tacoCount >= item.price)
      {
         inventory.content.Add(item);
         inventory.UpdateInventoryUI();
         inventory.tacoCount -= item.price;
         inventory.UpdateTextUI();
      }
   }
}

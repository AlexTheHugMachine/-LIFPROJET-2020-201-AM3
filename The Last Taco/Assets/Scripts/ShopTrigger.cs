using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
   private bool isInRange;

    private Text interractUI;

    public string pngName;
    public Item[] itemsToSell;


    //Singleton
    private void Awake() 
    {
            interractUI = GameObject.FindGameObjectWithTag("InterractUI").GetComponent<Text>();
            interractUI.enabled = false;
    }

    //Procédure mise à jour
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {          
            ShopManager.instance.OpenShop(itemsToSell,pngName);
        }
    }

    //Procédure qui détecte collision entre joueur et marchand et affiche le bouton d'interrraction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interractUI.enabled = true;
        }
    }

    //Procédureq qui ne détecte pas une  collisoon joueur et marchand 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interractUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
}

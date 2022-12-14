using UnityEngine;
using UnityEngine.UI;

//Procédure permettant de définir la possibilité au joueur de prendre un item sur le sol
public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Item item;
    public AudioClip soundToPlay;

    //Singleton
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InterractUI").GetComponent<Text>();
    }

    //Procédure permettant de prendre un item si le joueur est dans la bonne zone et si il appuie sur la touche E
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }

    //Procédure permettant de prendre un item sur le sol en l'ajoutant à l'inventaire, en jouant les sons associés et en le supprimant du sol
    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
    }

    //Procédure permettant d'afficher la possibilité d'interagir pour avoir l'item si le joueur est dans la bonne zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    //Procédure permettant de ne pas afficher la possibilité d'interagir pour avoir l'item si le joueur est trop loin de la zone d'interaction
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}

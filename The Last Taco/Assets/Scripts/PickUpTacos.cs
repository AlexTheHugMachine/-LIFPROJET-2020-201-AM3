using UnityEngine;
using UnityEngine.SceneManagement;

//Classe permettant de récupérer un tacos sur le sol et de l'ajouter au compteur de tacos de l'inventaire du joueur
public class PickUpTacos : MonoBehaviour
{
    public AudioClip sound;

    //Procédure permettant de détecter la collision du joueur avec un tacos et de l'ajouter à l'inventaire avec le son associé et en le supprimant du sol
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddTacos(1);
            CurrentSceneManager.instance.tacoPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}

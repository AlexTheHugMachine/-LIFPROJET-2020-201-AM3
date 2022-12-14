using UnityEngine;

//Classe définissant les items de coeurs ainsi que leur fonctionnalités
public class HeadPowerUp : MonoBehaviour
{
    public  int healdPoints;
    public AudioClip pickupSound;


    //Procédure détectant la collision du joueur avec le coeur et définissant l'ajout de vie et les sons associés lorsque le joueur passe dessus
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if (collision.CompareTag("Player"))
       {
           if (PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
           {
               AudioManager.instance.PlayClipAt(pickupSound, transform.position);
               PlayerHealth.instance.HealPlayer(healdPoints);
               Destroy(gameObject);
           }
       }
   }
}

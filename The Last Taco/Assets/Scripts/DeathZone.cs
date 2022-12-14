using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Classe permettant de définir des endroits dont les collisions du joueur avec ces dernières, le font se téléporter au dernier checkpoint et lui enlève de la vie
public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;

    public int damageOnCollision = 20;

    //Singleton
    private void Awake() 
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    //Procédure en cas de collision avec la zone éliminatoire
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if (collision.CompareTag("Player"))
       {
          StartCoroutine(ReplacePlayer(collision));
       }
   }

    //Coroutine qui remet le joueur au dernier checkpoint
   private IEnumerator ReplacePlayer(Collider2D collision)
   {
       fadeSystem.SetTrigger("FadeIn");
       yield return new WaitForSeconds(1f);
       collision.transform.position = CurrentSceneManager.instance.respawnPoint;
       PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
       playerHealth.TakeDamage(damageOnCollision);
   }
}

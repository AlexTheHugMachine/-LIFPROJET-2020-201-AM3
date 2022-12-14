using UnityEngine;

//Classe gérant les fonctionnalité du checkpoint : réapparaitre au checkpoint si le joueur tombe dans des pièges par exemple
public class CheckPoint : MonoBehaviour
{
    //Procédure permettant de détecter la collision du joueur avec le checkpoint pour redéfinir le lieu de spawn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

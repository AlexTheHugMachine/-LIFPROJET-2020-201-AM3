using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioClip gameOverAudio;
    public static GameOverManager instance;


    //Singleton
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de GameOverManager dans la scène");
           return;
       }

       instance = this; 
   }


    //Procédure si le joueur mort
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
        AudioManager.instance.PlayClipAt(gameOverAudio, transform.position);
    }

    //Procédure permettant de recommencer le niveau
    public void RetryButton()
    {
        //recommencre le niveau
        Inventory.instance.RemoveTacos(CurrentSceneManager.instance.tacoPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    //procédure pour afficher le menu princiapl
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuSecours");
    }

    //procédure pour quitter le jeux
    public void QuitButton()
    {
        //fermer le jeux
        Application.Quit();
    }



}

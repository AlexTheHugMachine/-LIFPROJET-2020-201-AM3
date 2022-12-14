using UnityEngine;
using UnityEngine.SceneManagement;

//Classe qui s'occupe de gérer les différentes fonctionnalités du menu pause
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    public GameObject pauseMenuUI;

    public GameObject settingsWindow;
    
    //Procédure qui va gérer  l'arrêt du jeu pendant que le joueur est dans le menu pause si la touche echap est préssée
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
    }
    
    //Procédure mettant le jeu à l'arrêt
    void Paused()
    {
        PlayerMouvement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    
    //Procédure mettant le jeu en marche
    public void Resume()
    {
        PlayerMouvement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    
    //Procédure qui va charger le menu principal et nous renvoyer sur celui ci
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenuSecours");
    }

    //Procédure qui affiche la fenêtre des paramètres modifiables
     public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        Debug.Log("open");
    }
    
    //Procédure qui ferme la fenêtre des paramètres modifiables
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}

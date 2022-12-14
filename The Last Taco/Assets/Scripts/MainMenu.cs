using UnityEngine;
using UnityEngine.SceneManagement;

//Classe correspondant aux fonctionnalités du menu principal
public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    
    public GameObject settingsWindow;
    public GameObject RulesWindow;
    
    //Procédure qui va s'occuper de lancer une partie en chargeant une scène
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
    //Procédure qui activera la fenêtre avec les règles
    public void RulesButton()
    {
        RulesWindow.SetActive(true);
    }
    
    //Procédure qui affichera la fenêtre des paramètres modifiables
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    
    //Procédure qui permet de fermer la fenêtre des règles
    public void CloseRulesWindow()
    {
        RulesWindow.SetActive(false);
    }
    
    //Procédure qui permet de fermer la fenêtredes paramètres modifiables
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    //Procédure qui permet de lancer les crédits
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    
    //Procédure qui permet de fermer la fenêtre du menu (quitter le jeu)
    public void QuitGame()
    {
        Application.Quit();
    }
    
}

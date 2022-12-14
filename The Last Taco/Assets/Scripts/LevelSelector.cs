using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Classe permettant de gérer le choix de niveau
public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    //Procédure permettant de gérer les niveaux débloqués et donc les niveaux disponibles pour jouer
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i +1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    
    //Procédure permettant de chargée la scène choisie
   public void LoadLevelPassed(string levelName)
   {
       SceneManager.LoadScene(levelName);
   }
}

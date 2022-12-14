using UnityEngine;
using UnityEngine.SceneManagement;

//Classe gérant l'affichage et les fonctionnalités des crédits
public class Credits : MonoBehaviour
{
    //Procédure permettant le retour au menu principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Procédure permettant le déroulement de l'affichage des crédits, et lorsque le ta touche échap est préssée alors on revient au menu principal
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}

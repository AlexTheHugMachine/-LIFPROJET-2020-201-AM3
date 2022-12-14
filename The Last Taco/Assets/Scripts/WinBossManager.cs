using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBossManager : MonoBehaviour
{
    public GameObject WinBossUI;
    public static WinBossManager instance;

    public string NextScene;


    //Singelton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de WinBossManager dans la scène");
            return;
        }

        instance = this;
    }

    //Charge la scène suivante
    public void NextButton()
    {
        SceneManager.LoadScene(NextScene);
        PlayerHealth.instance.Respawn();
        WinBossUI.SetActive(false);
    }



}

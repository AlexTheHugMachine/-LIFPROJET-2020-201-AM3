using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpeceficScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;

    //Singleton
    private void Awake() 
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collission)
    {
        if(collission.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    //Coroutine permttant de charger la scène suivante
    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}

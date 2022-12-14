using UnityEngine;
using UnityEngine.UI;

//Classe permettant de détecter la possibilité d'afficher les dialogues, et de les afficher
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool isInRange;

    private Text interractUI;

    public int health;


    //Singleton
    private void Awake() 
    {
            interractUI = GameObject.FindGameObjectWithTag("InterractUI").GetComponent<Text>();
            interractUI.enabled = false;
    }
    
    //Procédure permettant d'afficher le dialogue si le joueur est dans la bonne zone et si il appuie sur la touche E
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {          
            TriggerDialogue();
        }
    }

    //Procédure permettant d'afficher la possibilité d'interagir pour avoir le dialogue si le joueur est dans la bonne zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interractUI.enabled = true;
        }
    }

    //Procédure permettant de ne pas afficher la possibilité d'interagir pour avoir le dialogue si le joueur est trop loin de la zone d'interaction, et permet également de terminer le dialogue si le joueur s'éloigne trop de la zone d'interaction pendant le dialogue
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interractUI.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    //Procédure permettant de lancer un dialogue lorsque la vie du Boss atteint un certain niveau
    void TriggerDialogue()
    { 
        health = Boss.instance.health;
        DialogueManager.instance.StartDialogue(dialogue,health);
    }

}

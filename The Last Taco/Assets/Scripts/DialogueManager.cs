using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe permettant de gérer l'affichage des dialogues ainsi que l'enchainement des phrases
public class DialogueManager : MonoBehaviour {
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    public static DialogueManager instance;

    //Singleton
    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("Il n'y a plus d'une instance de DialogueManger dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string> ();
    }

    //Procédure permettant de commmencer un dialogue et de gérer l'enchainement des phrases
    public void StartDialogue (Dialogue dialogue, int _health) {
        animator.SetBool ("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear ();
        if (_health == 300)
        {
            foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue (sentence);
        }
        }
        if (_health == 200)
        {
            foreach (string sentence in dialogue.sentences2) {
            sentences.Enqueue (sentence);
        }
        }
        if (_health == 100)
        {
            foreach (string sentence in dialogue.sentences3) {
            sentences.Enqueue (sentence);
        }
        }

        DisplayNextSentence ();
    }

    //Procédure permettant de terminer un dialogue si il n'y a plus de phrases ou de continuer le dialogue
    public void DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue ();
            return;
        }

        string sentence = sentences.Dequeue ();
        StopAllCoroutines ();
        StartCoroutine (TypeSentence (sentence));
    }


    //Coroutine qui affiche la phrase lettre par lettre
    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray ()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //Procédure permettant de terminer un dialogue
    public void EndDialogue () {
        animator.SetBool ("isOpen", false);
        Boss.instance.Restart();
    }
}

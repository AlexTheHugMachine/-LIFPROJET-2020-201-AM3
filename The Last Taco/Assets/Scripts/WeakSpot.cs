﻿using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;
    public AudioClip killSound;

    private bool isAttacking2;

    //Procédure qui détecte une collision entre le joueur et l'ennemi, inflige des dégats ou ennemis éliminés 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttacking2)
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            Destroy(objectToDestroy);
        }

        isAttacking2 = false;
    }

    //Prcédure de mise à jour
     void Update() 
    {
        InputButton();
    }

    //Procédure détection bouton pressé
    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking2 = true;
        }
    }

    //Procédure remise à zéro
     private void ResetValues()
    {
        isAttacking2 = false;
    }
}

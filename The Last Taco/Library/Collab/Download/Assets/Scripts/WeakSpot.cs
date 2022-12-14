﻿using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;
    public AudioClip killSound;

    private bool isAttacking2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttacking2)
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            Destroy(objectToDestroy);
        }

        isAttacking2 = false;
    }

     void Update() 
    {
        InputButton();
    }

    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking2 = true;
        }
    }

     private void ResetValues()
    {
        isAttacking2 = false;
    }
}

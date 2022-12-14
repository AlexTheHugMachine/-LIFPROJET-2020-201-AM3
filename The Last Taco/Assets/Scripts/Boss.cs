using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe permettant de créer un Boss et définit ses fonctionnalités
public class Boss : MonoBehaviour 
{
    public Dialogue dialogue;

    public int health;
    public int ReceiveDamage;
    public int GiveDamage;
    private bool isAttacking2;
    private bool isRage = false;

    public GameObject WinUI;
    private Rigidbody2D memoire;
    public GameObject DialogueUI;
    public Transform Ninja;
    private Animator anim;
    public AudioClip DamageSound;
    public AudioClip killSound;
    public AudioClip WinSound;
    public HealthBar healthBar;
    public bool isDead;
    public bool isFlipped = false;
    public static Boss instance;

    //Singleton
     private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de Boss dans la scène");
           return;
       }

       instance = this; 
   }

    //Procédure permettant l'initialisation de la scnène du Boss avec le placement et le dialogue des personnages
    private void Start()
    {
        anim = GetComponent<Animator>();

        memoire = PlayerMouvement.instance.rb;

        anim.gameObject.GetComponent<Animator>().enabled = false;
        PlayerMouvement.instance.animator.gameObject.GetComponent<Animator>().enabled = false;
        PlayerMouvement.instance.enabled = false;
        PlayerMouvement.instance.rb.bodyType= RigidbodyType2D.Kinematic;
        PlayerMouvement.instance.rb.velocity = Vector3.zero;
        PlayerMouvement.instance.playerCollider.enabled = false;
        DialogueManager.instance.StartDialogue(dialogue,health);
    }

    private void Update()
    {
        InputButton();
    }

    //Procédure définissant la prise de dégats du héros si le Boss le touche, ainsi que la mort éventuelle du héros
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isAttacking2)
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(GiveDamage);
        }

        if (collision.CompareTag("Player") && isAttacking2)
        {
            AudioManager.instance.PlayClipAt(DamageSound, transform.position);
            TakeDamage(ReceiveDamage);
            healthBar.SetHealth(health);
        }
    }

    //Procédure définissant la prise de dégats du Boss si le héros l'attaque. Elle définit aussi l'augmentation des dégats provoqués par le boss si il le boss est dans un état de rage (lorsque sa vie a atteint un certain niveau)
    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if(health <= 0)
        {
            enabled= false;
            AudioManager.instance.PlayClipAt(WinSound, transform.position);
            anim.SetTrigger("Die");
            Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
            WinUI.SetActive(true);
        }

        if ((health == 200 || health ==100) && !isRage)
        {
            if (health == 200)
            {
                GiveDamage += 5;
            }
            if (health == 100)
            {
                GiveDamage += 5;
            }
            isRage = true;
            enabled= false;

            memoire = PlayerMouvement.instance.rb;

            anim.gameObject.GetComponent<Animator>().enabled = false;
            PlayerMouvement.instance.animator.gameObject.GetComponent<Animator>().enabled = false;
            PlayerMouvement.instance.enabled = false;
            PlayerMouvement.instance.rb.bodyType= RigidbodyType2D.Kinematic;
            PlayerMouvement.instance.rb.velocity = Vector3.zero;
            PlayerMouvement.instance.playerCollider.enabled = false;
            DialogueManager.instance.StartDialogue(dialogue,health);

        }
    }


    //Procédure permettant au boss de regarder dans la direction du héros, et de le suivre pour l'attaquer
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > Ninja.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < Ninja.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	//Procédure permettant d'activer l'attaque du joueur
     void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking2 = true;
        }
    }

    //Procédure permettant de recommencer le combat de Boss
    public void Restart()
    {
        if(health == 200)
        {
            anim.SetBool("isEnraged",true);
        }
        else if (health == 100)
        {
            anim.SetBool("isEnraged2",true);
        }
        anim.gameObject.GetComponent<Animator>().enabled = true;
        PlayerMouvement.instance.animator.gameObject.GetComponent<Animator>().enabled = true;
        PlayerMouvement.instance.enabled = true;
        PlayerMouvement.instance.rb.bodyType= RigidbodyType2D.Dynamic;
        PlayerMouvement.instance.rb.velocity = memoire.velocity;
        PlayerMouvement.instance.playerCollider.enabled = true;
        isRage = false;
    }

    
}

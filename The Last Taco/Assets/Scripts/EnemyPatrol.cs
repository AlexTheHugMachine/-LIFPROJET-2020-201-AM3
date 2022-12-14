using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private bool isAttacking;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;


    //Pocédure initialisation
    void Start()
    {
        target = waypoints[0];
    }

    //Procédure mise à jour des événements
    void Update()
    {
        InputButton();
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    //Procédure entrer en collision entre joueur et ennemis 
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")&& !isAttacking )
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }

    //Procédure détection bouton appuyé
    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking = true;
        }
    }
    
    //Procédure remise à zéro des valeurs
     private void ResetValues()
    {
        isAttacking = false;
    }
}
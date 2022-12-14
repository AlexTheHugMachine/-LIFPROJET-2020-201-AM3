using UnityEngine;
using System.Collections;

//Classe permettant le mouvement du joueur
public class PlayerMouvement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;


    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public CapsuleCollider2D playerCollider;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;



    private bool isAttacking;


    private Vector3 velocity= Vector3.zero;
    private float horizontalMovement;

    public static PlayerMouvement instance;


    //Singelton
     private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de PlayerMouvement dans la scène");
           return;
       }

       instance = this; 
   }

    //Procédure de mise à jour des frames
    void Update()
    {
        InputButton();
        
       horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;

       if (Input.GetKeyDown(SpacebarKey())&& isGrounded)
       {
           isJumping = true;
       }

       Flip(rb.velocity.x);

       float characterVelocity = Mathf.Abs(rb.velocity.x); 
       animator.SetFloat("Speed",characterVelocity);

        Attack();

        ResetValues();
    }
   
    //Procédure temps fixé 
     void FixedUpdate()
    {
       isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, collisionLayers);
       MovePlayer(horizontalMovement);
    }

    //Procédure déplacement du joueur sur l'axe horizontale
    void MovePlayer(float _horizontalMouvement)
    {
        if(isJumping)
        {
            animator.SetTrigger("NinjaJump");
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
        else
        {
            Vector3 targetVelocity = new Vector2(_horizontalMouvement,rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
        }
    }

    //Procédure attaque du joueur
    void Attack()
    {
        if(isAttacking)
        {
            animator.SetTrigger("NinjaAttack");
            rb.velocity = Vector2.zero;
        }
    }

    //Détection touche espace
    public static KeyCode SpacebarKey()
    {
    if (Application.isEditor) return KeyCode.O;
    else return KeyCode.Space;
    }

    //Procédure détection touche appuyée
    void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking = true;
        }
    }

    //Procédure permettant de changer l'image du joueur permetttant une marche avant dans la direction qu'on souhaite
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        } 
    }

    //Procédure remise à zéro des valeurs
    private void ResetValues()
    {
        isAttacking = false;
    }

    //Procédure permettant de détecter le contact entre le joueur et le sol 
      private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

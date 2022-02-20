using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("RigidBody do Player")]
    [SerializeField] private Rigidbody2D rigidbody2d;
    [Header("Animator do Player")]
    [SerializeField] private Animator animator;
    [Header("Sprite Renderer do Player")]
    [SerializeField] private SpriteRenderer sprite;
    [Header("Layer Mask do Player")]
    [SerializeField] private LayerMask chao;
    [Header("Transform do Player")]
    [SerializeField] private Transform pe;
    [Header("Força do pulo do Player")]
    [SerializeField] private float forcejump;
    float horizontal;
    [Header("Velocidade do Player")]
    [SerializeField] private float speed;
    [Header("Raio para identificar o chão do Player")]
    [SerializeField] private float raio;
    [Header("Tempo para o Player Nascer de novo")]
    [SerializeField] private float tmepoDeResncer;

    private bool Ground;
    private bool morte1;
    [Header("Nome do level")]
    [SerializeField] private string nomeDoLVL;

    [Header("Camera")]
    public Camera camera1;
    [Header("Cores do BackGround da Camera")]
    public Color cor1;
    public Color cor2;

    [Header("Coyote Time Do Player")]

    [SerializeField] private float coyoteTime;
      private float contarTempoDoCoyote;

      [Header("Jump Buffet")]
      [SerializeField] private float jumpBuffet;
      private float contarJumpBuffet;

      [Header("Fumaça")]
      [SerializeField] private GameObject smoke;
      [SerializeField] private GameObject pezinho;

    void Start()
    {
        rigidbody2d.GetComponent<Rigidbody2D>();
        sprite.GetComponent<SpriteRenderer>();
        sprite.GetComponent<Animation>();

         camera1 = Camera.main;
         camera1.clearFlags = CameraClearFlags.SolidColor;
         camera1.backgroundColor = cor1;
         
       
    }

    
    void Update()
    {
        move();
        animationDoPersonagem();
        jump();
        GroundIdetifique();
        morte(nomeDoLVL);
        coyote();
        buffet();
    }


        void move(){

            horizontal = Input.GetAxis("Horizontal");

            rigidbody2d.velocity = new Vector2(horizontal * speed, rigidbody2d.velocity.y);
        }

        void animationDoPersonagem(){
            if(horizontal < 0){
               animator.SetBool("Run",true);
               sprite.flipX = true;
            }
            else if(horizontal > 0){
                animator.SetBool("Run",true);
                sprite.flipX = false;
            }else{
                animator.SetBool("Run", false);
            }
        }

        void jump(){

            if(contarJumpBuffet > 0f && contarTempoDoCoyote > 0f ){

                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, forcejump);
                contarJumpBuffet = 0f;
                Instantiate(smoke, pezinho.transform.position,pezinho.transform.rotation);
            }  
            if(Input.GetButtonUp("Jump") && rigidbody2d.velocity.y > 0f){

                rigidbody2d.velocity = new Vector2 (rigidbody2d.velocity.x, rigidbody2d.velocity.y * 0.5f);
                contarTempoDoCoyote = 0f;
            } 
        }
        void GroundIdetifique(){ // identifica se o personagem está no chão
          
          Ground = Physics2D.OverlapCircle(pe.position, raio,chao);
        }

        void coyote(){

             if(Ground){
                contarTempoDoCoyote = coyoteTime;
            }else{
                contarTempoDoCoyote -= Time.deltaTime;
            }

        }

        void buffet(){

            if(Input.GetButtonDown("Jump")){
                contarJumpBuffet = jumpBuffet;
            }else{
                contarJumpBuffet -= Time.deltaTime;
            }
        }


         void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Enemy")){
                animator.SetBool("Death", true);
                animator.SetBool("Run",false);
                rigidbody2d.bodyType = RigidbodyType2D.Static;
                morte1 = true; 
            }
        }


        void morte(string morte){

            if(morte1 == true){
          tmepoDeResncer -= 1 * Time.deltaTime;
          if( tmepoDeResncer <= 0){

           SceneManager.LoadScene(morte);
           
          }
            }
          
          

        }

        void OnCollisionEnter2D(Collision2D col) {

            if(col.gameObject.layer == 7){
                this.transform.parent = col.transform;
                if(Input.GetButtonDown("Jump")){
                    this.transform.parent = null;
                }
            }
            
        }

        private void OnCollisionExit2D(Collision2D col) {
            if(col.gameObject.layer == 7){
                this.transform.parent = null;
            }
        }

}

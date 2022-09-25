using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //variable declaration
    [SerializeField] float speed =  20f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float bulletSpeed = 1000f;
    Animator anim;

    public Rigidbody2D projectile;
 
    // new input system
    public Vector2 moveVal;
    Rigidbody2D rbd;
    CapsuleCollider2D MyBodyCollider2D;
    BoxCollider2D MyFeetCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MyBodyCollider2D = GetComponent<CapsuleCollider2D>();
        MyFeetCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        FireBalls();
        FlipPlayer();
        Dash();
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        bool playerHasVerticalSpeed = Mathf.Abs(rbd.velocity.y) > Mathf.Epsilon;
        anim.SetBool("Jumping",true);
        
        if(!MyFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed){
            rbd.velocity += new Vector2(0f,jumpSpeed);
        }

    }

    // movements on inputs
    void Movements(){
        Vector2 playerVelocity = new Vector2(moveVal.x*speed,rbd.velocity.y);
        rbd.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rbd.velocity.x) > 0;
        if(playerHasHorizontalSpeed && MyFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            anim.SetBool("Walking",true);
        }else{
            anim.SetBool("Walking",false);
        }
    }

    // flip character left/right on input
    void FlipPlayer(){
        bool playerHasHorizontalSpeed = Mathf.Abs(rbd.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
            transform.localScale = new Vector2(0.3f*Mathf.Sign(rbd.velocity.x),0.3f);
        }
        
    }

    // Teleport mechanics
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Portal1"){
            transform.position = GameObject.FindGameObjectWithTag("Portal2").transform.position;
        }
    }

    public float dashForce = 1000f; 
    void Dash(){
        if(Input.GetKeyDown(KeyCode.E)){
            rbd.velocity = new Vector2(100f*Mathf.Sign(transform.localScale.x),rbd.velocity.y);
            anim.SetBool("Dash",true);
        }else{
            anim.SetBool("Dash",false);
        }
    }

    // fire bullet
    void FireBalls(){
        float pdir = Mathf.Sign(transform.localScale.x);
        Rigidbody2D p;
        
        if (Input.GetButtonDown("Fire1"))
        {
            if(pdir==1){
                p = Instantiate(projectile, transform.position  + new Vector3(0.8f*pdir,0,0),  new Quaternion(1,180,1,1)*transform.rotation);
            }else{
                p = Instantiate(projectile, transform.position  + new Vector3(0.8f*pdir,0,0),  transform.rotation);
            }
            
            p.velocity = transform.right * bulletSpeed * Time.deltaTime* Mathf.Sign(transform.localScale.x);
            
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        anim.SetBool("Jumping",false);    
    }

}

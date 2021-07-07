using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Player : MonoBehaviour
{   
    public float speed = 1f;
    public float jumpSpeed = 9f;
    public float maxSpeed = 10f;
    public float JumpPower = 20f;
    public bool grounded;
    public float jumpRate = 1f;
    public float nextJumpPress = 0.0f;
    public float fireRate = 0.2f;
    public float nextFireRate = 0.0f;
    private Rigidbody2D ridigBody2D;
    private Physics2D Physic2D;
    Animator animator;
    public int healthbar = 100;
    public Text healthText;
    public GameObject hitArea;
    public Slider sliderHp;

    void Start()
    {
        ridigBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        sliderHp.maxValue = healthbar;
    }
    void Update()
    {
       healthText.text = "HEALTH: "+healthbar;

       if(healthbar <= 0){
           healthbar = 0;
           animator.SetTrigger("Death");
       }

       sliderHp.value = healthbar;
       
       if(Input.GetKey(KeyCode.L)){
           TakeDamage(10);
       }

       animator.SetBool("grounded",true); 
       animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
       if(Input.GetAxis("Horizontal") < -0.1f){
           transform.Translate(Vector2.right * speed * Time.deltaTime);
           transform.eulerAngles = new Vector2(0,180); 
       }else if(Input.GetAxis("Horizontal") > 0.1f){
           transform.Translate(Vector2.right * speed * Time.deltaTime);
           transform.eulerAngles = new Vector2(0,0); 
       }

       if(Input.GetButtonDown("Jump") && Time.time > nextJumpPress){
           animator.SetBool("Jump",true);
           nextJumpPress = Time.time + jumpRate;
           ridigBody2D.AddForce(jumpSpeed * (Vector2.up * JumpPower));
       }else{
           animator.SetBool("Jump",false);
       }

        if(Input.GetKey(KeyCode.P) && Time.time > nextFireRate){
            nextFireRate = Time.time + fireRate;
            animator.SetBool("Attack",true);
            Attack();
        }else{
            animator.SetBool("Attack",false);
        }

    }

    void TakeDamage(int damage){
        healthbar = healthbar - damage;
    }

    public void Attack(){
        StartCoroutine(DelaySlash());
    }
    IEnumerator DelaySlash(){
        yield return new WaitForSeconds(0.3f);
        Instantiate(hitArea,transform.position,transform.rotation);
     }
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.tag == "health"){
            healthbar = healthbar + 25;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "deahtzone"){
            healthbar = 0;
        }
        if(other.gameObject.tag == "enemy"){
            TakeDamage (10);
        }
    }
    


}

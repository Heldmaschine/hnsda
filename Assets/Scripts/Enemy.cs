using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

   
    public float visionRadius;
    public float attackRadius;
    public float speed;


    [Tooltip("Сбор сборной скалы")]
    public GameObject rockPrefab;
    [Tooltip("Скорость атаки (секунды между атаками) ")]
    public float attackSpeed = 2f;
    bool attacking;

    
    [Tooltip("Количество жизней")]
    public int maxHp = 3;
    [Tooltip("Текущая жизнь")]
    public int hp;

    
    GameObject player;

    
    Vector3 initialPosition, target;

   
    Animator anim;
    Rigidbody2D rb2d;

    void Start () {

        
        player = GameObject.FindGameObjectWithTag("Player");

        
        initialPosition = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        
        hp = maxHp;
    }
    /// <summary>
    /// Метод нахождения обьекта для атаки.
    /// </summary>
    void Update () {

        
        target = initialPosition;
        
        
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            player.transform.position - transform.position, 
            visionRadius, 
            1 << LayerMask.NameToLayer("Default") 
                
        );

       
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        // Если Raycast находит игрока, мы ставим его на цели
        if (hit.collider != null) {
            if (hit.collider.tag == "Player"){
                target = player.transform.position;
            }
        }

        
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        // Если это враг, и он находится в зоне атаки, мы останавливаемся и атакуем его
        if (target != initialPosition && distance < attackRadius){
            
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.Play("Enemy_Walk", -1, 0);  

          
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        // В противном случае мы движемся к нему
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);

           
            anim.speed = 1;
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);
        }

        
        if (target == initialPosition && distance < 0.05f){
            transform.position = initialPosition; 
            
            anim.SetBool("walking", false);
        }

       
        Debug.DrawLine(transform.position, target, Color.green);
    }

    /// <summary>
    /// Мы можем нарисовать радиус видения и атаковать на сцене, рисуя сферу
    /// </summary>
    void OnDrawGizmosSelected() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    IEnumerator Attack(float seconds){
        attacking = true;  
        if (target != initialPosition && rockPrefab != null) {
            Instantiate(rockPrefab, transform.position, transform.rotation);
            
            yield return new WaitForSeconds(seconds);
        }
        attacking = false; 
    }

    /// <summary>
    /// Управление атакой, мы вычитаем жизнь
    /// </summary>
    public void Attacked(){
        if (--hp <= 0) Destroy(gameObject);
    }

    /// <summary>
    /// Метод отображение жизни врага в баре
    /// </summary>
    void OnGUI() {
        
        Vector2 pos = Camera.main.WorldToScreenPoint (transform.position);

        
        GUI.Box(
            new Rect(
                pos.x - 20,                  
                Screen.height - pos.y + 60,   
                40,                            
                24                            
            ), hp + "/" + maxHp               
        );
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    [Tooltip("Velocidad de movimiento en unidades del mundo")]
    public float speed;

    GameObject player;   
    Rigidbody2D rb2d;    
    Vector3 target, dir; 

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        
        if (player != null){
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
	}
    /// <summary>
    /// Атака скалой по обнаруженой цели
    /// </summary>
    void FixedUpdate () {

        if (target != Vector3.zero) {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
	}
    /// <summary>
    /// При столкновении персонажем или атакой удаляем камень.
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col){

        if (col.transform.tag == "Player" || col.transform.tag == "Attack"){
            Destroy(gameObject); 
        }
    }
    /// <summary>
    /// Удаление камня
    /// </summary>
    void OnBecameInvisible() {
        
        Destroy(gameObject);
    }
}

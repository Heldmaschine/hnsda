using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    /// <summary>
    /// Вычитаем жизнь из врага, если атакован.
    /// </summary>
    
    void OnTriggerEnter2D (Collider2D col) {
        
        if (col.tag == "Enemy") col.SendMessage("Attacked");
    }
}

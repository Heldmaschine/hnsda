using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDepth : MonoBehaviour {

    /// <summary>
    /// Переменная для обновления глубины в каждом кадре
    /// </summary>
    public bool fixEveryFrame;
    SpriteRenderer spr;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingLayerName = "Player";
        spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
	}

	void Update () {
        if (fixEveryFrame) {
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
	}
}

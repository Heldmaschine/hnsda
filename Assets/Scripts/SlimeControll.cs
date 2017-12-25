using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControll : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRig;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
	// Use this for initialization
	void Start () {

        myRig = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRig.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        } else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRig.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }

        }
	}
}

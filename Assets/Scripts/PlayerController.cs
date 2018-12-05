using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 playerPos;

    public Rect barrier;

    public float moveSpeed;

    public Vector3 rotAmount;
    public float rotXMultiplier;
    Vector3 playerInput;
    // Use this for initialization
    void Start ()
    {
        playerPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerInput.Set(0, Input.GetAxis("Horizontal"), 0);
        playerPos = transform.position;
        Move();
	}


    void Move()
    {
        playerPos += playerInput * moveSpeed;
        transform.rotation = Quaternion.Euler(new Vector3((-Mathf.Sin(Time.time * rotXMultiplier) * rotAmount.x),
            playerInput.y * rotAmount.y,
            -playerInput.y * rotAmount.z));

        ClampMovement();
    }

    void ClampMovement()
    {
        
        if(playerPos.x > barrier.xMax)
        {
            playerPos.x = barrier.xMax;
        }
        if (playerPos.x < barrier.xMin)
        {
            playerPos.x = barrier.xMin;
        }

        playerPos.y = Mathf.Sin(Time.time ) * (barrier.height /2);
        transform.position = playerPos;
    }

}

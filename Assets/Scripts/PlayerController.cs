using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour {

    public Vector3 playerPos;

    public static PlayerController instance;

    public Rect barrier;

    public bool canMove;
    public float moveSpeed;

    public Vector3 rotAmount;
    public float rotXMultiplier;
    Vector3 playerInput;

	Rigidbody rigid;
    // Use this for initialization
    void Start ()
    {
		rigid = GetComponent<Rigidbody>();
        instance = this;
        playerPos = transform.position;
        canMove = true;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		
        if (canMove)
        {
            playerInput.Set(Input.GetAxis("Horizontal"), 0, 0);
            playerPos = transform.position;
            Move();
			CheckCollision();
        }
	}


    void Move()
    {
        playerPos += playerInput * moveSpeed;
        transform.rotation = Quaternion.Euler(new Vector3((-Mathf.Cos(Time.time * rotXMultiplier) * GameManager.instance.multiplier),
            playerInput.x * rotAmount.y,
            -playerInput.x * rotAmount.z));

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

        playerPos.y = Mathf.Sin(Time.time * rotXMultiplier) * (barrier.height /2);
		rigid.MovePosition(playerPos);
        //transform.position = playerPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("RoofTop"))
        {
            print("Colliding");
            canMove = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("Game Over");
    }

	void CheckCollision()
	{
		int mask = LayerMask.GetMask("RoofTop");
		Collider[] cols = Physics.OverlapBox((transform.position + new Vector3(0.0f, 0.5f, -1.0f)), new Vector3(0.5f, 0.5f, 3.0f), Quaternion.identity, mask);

		if(cols.Length > 0)
		{
			//print("Colliding");
			canMove = false;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);
			StartCoroutine(LoadScene());
		}
	}
}

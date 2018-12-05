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
    // Use this for initialization
    void Start ()
    {
        instance = this;
        playerPos = transform.position;
        canMove = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int layerMask = LayerMask.GetMask("RoofTop");
        if (Physics.Raycast(transform.position, -transform.up, 5.0f, layerMask))
        {
            canMove = false;
            print("Colliding");
            canMove = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);
            StartCoroutine(LoadScene());
        }

        if (canMove)
        {
            playerInput.Set(Input.GetAxis("Horizontal"), 0, 0);
            playerPos = transform.position;
            Move();
        }
	}


    void Move()
    {
        playerPos += playerInput * moveSpeed;
        transform.rotation = Quaternion.Euler(new Vector3((-Mathf.Cos(Time.time * rotXMultiplier) * rotAmount.x),
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
        transform.position = playerPos;
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

        SceneManager.LoadScene("GameOver");
    }
}

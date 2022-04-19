using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float JumpForce;
    bool grounded;
    bool Alive = true;
    Rigidbody rb;
    GameManager gameManager;
    int moves;
    void Start()
    {
     rb = GetComponent<Rigidbody>();
     gameManager = GameObject.Find("ObstacleDespawn").GetComponent<GameManager>();;
     moves = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded == true && Alive == true)
        {
         Jump();
        }

        if(Input.GetKeyDown(KeyCode.D) && Alive == true && moves < 1)
        {
          MoveRight();
        }

        if(Input.GetKeyDown(KeyCode.A) && Alive == true && moves > -1)
        {
          MoveLeft();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }

        if(col.gameObject.CompareTag("Obstacle"))
        {
         Alive = false;
         gameManager.Lost();
        }
    }

    void Jump()
    {
      rb.AddForce(0f , 1f * JumpForce ,0f , ForceMode.Impulse);
      grounded = !grounded;
    }

    void MoveRight()
    {
      transform.Translate(Vector3.right * 3, Space.World);
      moves += 1;
    }

    void MoveLeft()
    {
      transform.Translate(Vector3.left * 3, Space.World);
      moves -= 1;
    }
}

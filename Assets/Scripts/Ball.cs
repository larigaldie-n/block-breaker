using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Raquette raquette1;
    [SerializeField] private Vector2 initialVelocity;
    private CircleCollider2D ballCollider;
    private BoxCollider2D paddleCollider;
    private Rigidbody2D ballRigidBody;
    private bool launched = false;
    Vector3 raquetteToBallDistanceVector;
    // Start is called before the first frame update
    void Start()
    {
        ballCollider = GetComponent<CircleCollider2D>();
        paddleCollider = raquette1.GetComponent<BoxCollider2D>();
        ballRigidBody = GetComponent<Rigidbody2D>();
        raquetteToBallDistanceVector = new Vector3(0.0f, ballCollider.radius + (paddleCollider.size.y / 2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (launched == false)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballRigidBody.velocity = initialVelocity;
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        ballCollider.transform.position = paddleCollider.transform.position + raquetteToBallDistanceVector;
    }
}

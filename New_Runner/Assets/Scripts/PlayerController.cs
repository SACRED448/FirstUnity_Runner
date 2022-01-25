using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int linetoMove = 1;
    public float lineDistance = 4;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (linetoMove < 2)
                linetoMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (linetoMove > 0)
                linetoMove--;
        }

        if (SwipeController.swipeUp)
        {
             if (controller.isGrounded)
                Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (linetoMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (linetoMove == 2)
            targetPosition += Vector3.right * lineDistance;

        transform.position = targetPosition;
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }



    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.deltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
}

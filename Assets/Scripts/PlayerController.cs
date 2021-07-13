using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    public Transform leftWall;
    public Transform rightWall;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float velocity = speed * Time.deltaTime;
        float horizontalPosition = transform.position.x + horizontalInput * velocity;

        float playerSize = transform.localScale.x / 2;

        if (horizontalPosition - playerSize <= leftWall.position.x + leftWall.localScale.x / 2)
        {
            return;
        }

        if (horizontalPosition + playerSize >= rightWall.position.x - rightWall.localScale.x / 2)
        {
            return;
        }

        transform.position = new Vector3(
            horizontalPosition,
            0.5f,
            transform.position.z);
    }
}

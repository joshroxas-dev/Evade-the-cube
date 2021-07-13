using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        float velocity = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z - velocity);
    }
}

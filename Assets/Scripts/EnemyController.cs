using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Catcher, Evader
}

public class EnemyController : MonoBehaviour
{
    private PlayerController m_PlayerController;
    private float m_TresholdPositionZ = -99.0f;
    public float speed = 10;
    public EnemyType enemyType; 

    void Start()
    {
        m_PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        float velocity = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z - velocity);

        if (Vector3.Distance(m_PlayerController.transform.position, transform.position) < 1.0f && enemyType == EnemyType.Evader)
        {
            m_PlayerController.ReceiveDamage();
            Destroy(gameObject);
        }
        else if (Vector3.Distance(m_PlayerController.transform.position, transform.position) < 1.0f && enemyType == EnemyType.Catcher) {
            Destroy(gameObject);
        }
        else if (transform.position.z + 10 < m_PlayerController.transform.position.z && enemyType == EnemyType.Catcher) {
            m_PlayerController.ReceiveDamage();
            Destroy(gameObject);
        }
        else if (transform.position.z <= m_TresholdPositionZ)
        {
            Destroy(gameObject);
        }
    }
}

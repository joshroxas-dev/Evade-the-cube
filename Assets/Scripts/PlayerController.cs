using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public HUDManager hudManager;
    public float speed = 10;
    public Transform leftWall;
    public Transform rightWall;
    private Stats m_Stats;

    void Awake()
    {
        m_Stats = GetComponent<Stats>();
        hudManager.UpdateHealthText(m_Stats.health);
    }
    void Update()
    {
        if (m_Stats.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

    public void ReceiveDamage()
    {
            m_Stats.UpdateHealth(10);
            hudManager.UpdateHealthText(m_Stats.health);
    }
}

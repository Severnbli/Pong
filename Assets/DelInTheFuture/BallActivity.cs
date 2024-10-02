using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivity : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Flipper") {
            Debug.Log("Hit a ball! " + Time.realtimeSinceStartup);
        }
        if (collision.gameObject.name == "Floor") {
            gameObject.transform.position = new Vector2(0,0);
        }

        // Получаем нормаль столкновения
        Vector2 collisionNormal = collision.GetContact(0).normal;

        // Определяем направление движения мяча
        Vector2 ballVelocity = rb.velocity;

        // Вычисляем угол между нормалью и вектором скорости
        float angle = Vector2.SignedAngle(ballVelocity, collisionNormal);

        // Если мяч катится вперед, придаем вращение
        if (angle > 0)
        {
            rb.angularVelocity = -rotationSpeed; // Вращение в одну сторону
        }
        else
        {
            rb.angularVelocity = rotationSpeed; // Вращение в другую сторону
        }
    }
}

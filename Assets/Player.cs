using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 2f;
    public float maxSpeed = 20f; // Максимальная скорость
    private Vector3 positionMouse;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Увеличиваем скорость
        speed = Mathf.Min(speed + acceleration * Time.fixedDeltaTime, maxSpeed);

        // Перемещаем игрока на основе текущей скорости
        Vector3 move = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Получаем положение курсора мыши в мировых координатах
        positionMouse = Input.mousePosition;
        positionMouse = Camera.main.ScreenToWorldPoint(new Vector3(positionMouse.x, positionMouse.y, Camera.main.nearClipPlane));
        float x = positionMouse.x;

        // Перемещаем объект только вдоль оси X (можете удалить, если это не требуется)
        rb.position = new Vector3(x, rb.position.y, rb.position.z);
    }
}

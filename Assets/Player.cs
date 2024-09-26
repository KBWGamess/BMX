using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 2f;
    public float maxSpeed = 20f; // ������������ ��������
    private Vector3 positionMouse;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ����������� ��������
        speed = Mathf.Min(speed + acceleration * Time.fixedDeltaTime, maxSpeed);

        // ���������� ������ �� ������ ������� ��������
        Vector3 move = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // �������� ��������� ������� ���� � ������� �����������
        positionMouse = Input.mousePosition;
        positionMouse = Camera.main.ScreenToWorldPoint(new Vector3(positionMouse.x, positionMouse.y, Camera.main.nearClipPlane));
        float x = positionMouse.x;

        // ���������� ������ ������ ����� ��� X (������ �������, ���� ��� �� ���������)
        rb.position = new Vector3(x, rb.position.y, rb.position.z);
    }
}

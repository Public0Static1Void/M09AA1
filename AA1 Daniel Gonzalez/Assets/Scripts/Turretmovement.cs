using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretmovement : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private Transform pipe;

    [SerializeField] private float rot_speed;

    private float mouse_x;
    private float mouse_y;

    void Update()
    {
        Move();
    }

    void Move()
    {
        mouse_x += Input.GetAxis("Mouse X") * rot_speed * Time.deltaTime;
        mouse_y += Input.GetAxis("Mouse Y") * rot_speed * Time.deltaTime;

        mouse_y = Mathf.Clamp(mouse_y, -20, 45);
        mouse_x = Mathf.Clamp(mouse_x, -45, 45);

        body.localRotation = Quaternion.Euler(0, mouse_x + body.localRotation.y, 0);
        pipe.localRotation = Quaternion.Euler(-mouse_y + pipe.localRotation.x, 0, 0);
    }
}
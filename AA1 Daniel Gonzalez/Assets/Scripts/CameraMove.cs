using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float collisionOffset = 0.1f;

    private float currentDistance;

    void Start()
    {
        currentDistance = maxDistance;
    }

    void Update()
    {
        RotateCamera();
        CameraRaycast();
    }

    private void RotateCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        if (direction.sqrMagnitude > 0.01f) // Evita la rotación innecesaria cuando no hay entrada
        {
            transform.RotateAround(gun.position, transform.up, horizontal * rotationSpeed);
            transform.RotateAround(gun.position, transform.right, -vertical * rotationSpeed);
        }
    }

    private void CameraRaycast()
    {
        RaycastHit hit;
        Vector3 dest = gun.position - transform.forward * currentDistance;

        if (Physics.Linecast(gun.position, dest, out hit))
        {
            currentDistance = Mathf.Clamp(hit.distance - collisionOffset, minDistance, maxDistance);
        }
        else
        {
            currentDistance = maxDistance;
        }

        transform.position = gun.position - transform.forward * currentDistance;
    }
}

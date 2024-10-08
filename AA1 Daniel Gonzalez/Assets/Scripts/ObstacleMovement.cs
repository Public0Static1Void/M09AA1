using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] List<Transform> path;
    [SerializeField] private int actual_point = 0;
    [SerializeField] private float speed;

    void Update()
    {
        if (Vector3.Distance(transform.position, path[actual_point].position) < 1f)
            UpdatePath();

        Vector3 dir = (path[actual_point].position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        Debug.Log(Vector3.Distance(transform.position, path[actual_point].position));
    }

    void UpdatePath()
    {
        if (actual_point < path.Count - 1)
            actual_point++;
        else
            actual_point = 0;
    }
}
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    void Start()
    {
        transform.position = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    }
}
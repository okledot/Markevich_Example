using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 target;

    private void Start()
    {

    }

    private void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = -1;
        Vector3 dir = target - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

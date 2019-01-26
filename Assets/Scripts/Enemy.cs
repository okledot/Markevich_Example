using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public bool alive = true;
    private Vector3 target;
    

    private void Start()
    {
        gameObject.GetComponentInChildren<TrailRenderer>().startWidth = transform.localScale.x*4;
        gameObject.GetComponentInChildren<TrailRenderer>().endWidth = 0;
    }

    private void Update()
    {
        if (alive)
        {
            Movement();
        }
        else
        {
            Die();
        }
    }

    private void Movement()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = -1;
        Vector3 dir = target - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Die()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
        transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, 0.5f * Time.deltaTime);
        if (transform.localScale == Vector3.zero) Destroy(gameObject);
    }
}

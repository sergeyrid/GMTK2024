using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseEnemyController : MonoBehaviour
{
    public float hp;
    public float speed;

    protected Transform transform;
    protected bool direction = true;

    protected virtual void Start()
    {
        transform = gameObject.transform;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Attack();

    protected virtual void Move()
    {
        float dir = 1;
        if (!direction)
        {
            dir = -1;
        }
        transform.Translate(dir * speed * Time.deltaTime * Vector2.right);
    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}


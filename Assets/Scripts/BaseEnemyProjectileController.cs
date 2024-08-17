using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyProjectileController : MonoBehaviour
{
    public float speed = 1;
    public float damage = 1;
    public float lifetime = 15;

    protected Vector2 direction = Vector2.right;
    protected Transform transform;
    private float lifetimeCounter;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        transform = gameObject.transform;
    }

    protected virtual void Update()
    {
        Move();
        lifetimeCounter += Time.deltaTime;
        if (lifetimeCounter > lifetime)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Projectile"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Building"))
        {
            other.gameObject.GetComponent<ZigurratController>().DealDamage(damage);
        }
        Destroy(gameObject);
    }
    
    public virtual void SetDirection(Vector2 dir)
    {
        direction = dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    public virtual void Fire() {}
}

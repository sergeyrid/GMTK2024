using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyProjectileController : MonoBehaviour
{
    public float speed = 1;
    public float damage = 1;

    private Vector2 direction = Vector2.right;
    protected Transform transform;

    // Start is called before the first frame update
    void Awake()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            other.gameObject.GetComponent<ZigurratController>().DealDamage(damage);
        }
        Destroy(gameObject);
    }
    
    protected virtual void SetDirection(Vector2 dir)
    {
        direction = dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    public virtual void Fire() {}
}

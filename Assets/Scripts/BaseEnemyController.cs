using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    public float hp;
    public float speed;
    public Transform position;
    public Vector3 direction = Vector3.right;

    private void Start()
    {
        position = gameObject.transform;
    }

    public void Attack()
    {
        Console.WriteLine("IT ATTAK");
    }

    public void Move()
    {
        position.SetPositionAndRotation(speed * , position.rotation);
    }
    
    public void SetHp(float hp)
    {
        this.hp = hp;
    }

    protected void FixedUpdate()
    {
        throw new NotImplementedException();
    }
}


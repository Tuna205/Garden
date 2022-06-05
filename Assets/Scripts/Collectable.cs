using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointValue = 1;

    private float speed;
    private Vector3 direction;

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.CompareTag("Player"))
        {
            Score.Get().IncreaseScore(pointValue);
        }
        else
        {
            HealthCounter.Get().DecreaseHp(1);
        }
        Destroy(this.gameObject);
    }

    public void Initialize(Vector3 direction, float speed)
    {
        this.speed = speed;
        this.direction = direction;
    }

    private void Update()
    {
        if (UDPReceiver.hasData)
        {
            this.transform.position += direction.normalized * speed;
        }
    }
}

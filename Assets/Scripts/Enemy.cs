using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    GameObject player;

    Rigidbody enemyRB;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 _lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(_lookDirection * _speed);

        if(transform.position.y < -10){
            Destroy(gameObject);
        }
    }
}

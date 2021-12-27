using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;

    private Transform player;
    public Vector2 target;

    private void Start() //cf EnemyFollow
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update() //lance le projectile avec un delais entre 2 projectiles, et cible le player
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectiles();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectiles();
            Health.instance.TakeDamages(1);
        }
    }

    private void DestroyProjectiles()
    {
        Destroy(gameObject);
    }
}
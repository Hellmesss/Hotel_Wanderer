using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grosu : MonoBehaviour
{
    public int damage;
    public float speed;
    public Animator animator;
    private Transform target;
    private Vector2 player;

    public int maxHealth = 100;
    public bool IsDead = false;
    public bool TakeDmg = false;
    int currenHealth;

    private int xp = 20;
    public Slider healthBar;

    void Start() //cf EnemyFollow
    {
        currenHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = new Vector2(target.position.x, target.position.y);
    }

    void Update() //cf EnemyFollow
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = new Vector2(target.position.x, target.position.y);
        if (Vector2.Distance(player, this.transform.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        healthBar.value = currenHealth;
    }


    public void TakeDamage(int dmg)
    {
        currenHealth -= dmg;

        if (currenHealth <= 0)
        {
            IsDead = true;
            animator.SetTrigger("IsDead");
            StartCoroutine(DeathDelay());
            Die();

        }
        animator.Play("grosu_hurt");
        healthBar.value = currenHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health.instance.TakeDamages(2);
        }

    }

    void Die()
    {


        this.enabled = false;

        ExpSystem.instance.IncreaseExp(xp);


        // animator.GetCurrentAnimatorStateInfo(0).IsName("bottle_die");
        // GetComponent<Collider2D>().enabled = false;


    }
    public IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
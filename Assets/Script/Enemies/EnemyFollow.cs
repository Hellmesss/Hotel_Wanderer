using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Transform player;

    
    private Vector2 target;

    public int maxHealth = 100;
    public bool Dead = false;
    int currenHealth;

    private int xp = 5;

    void Start()
    {
        currenHealth = maxHealth; //init la vie 
        player = GameObject.FindGameObjectWithTag("Player").transform; //cible a traquer
        target = new Vector2(player.position.x, player.position.y); //chemin vers la cible
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        if (Vector2.Distance(target, this.transform.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        
    }

    public void TakeDamage(int dmg) //method pour prendre des degats
    {
        currenHealth -= dmg;

        if (currenHealth<=0)
        {

            animator.SetTrigger("IsDead");
            StartCoroutine(DeathDelay());
            Die();
            
           
        }
        animator.Play("Bottle_Hurt");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health.instance.TakeDamages(1);
        }

    }

    void Die() //method pour gerer la mort du joueur
    {
        this.enabled = false;

        ExpSystem.instance.IncreaseExp(xp);
    }
    public IEnumerator DeathDelay() //permet de jouer l'anim de mort
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
        
    }
}

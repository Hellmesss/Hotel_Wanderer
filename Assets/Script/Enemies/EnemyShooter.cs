    using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public bool Dead;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject Player;
    public GameObject projectile;
    public Animator anim;
    private Transform player;

    public int maxHealth = 100;
    int currenHealth;

    private int xp = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }


    public void TakeDamage(int dmg) //cf EnemyFollow
    {
        currenHealth -= dmg;

        

        if (currenHealth <= 0)
        {
            anim.SetTrigger("IsDead");
            StartCoroutine(DeathDelay());
            Die();
            
        }
        anim.Play("Drug_Hurt");
    }

    void Die() //cf EnemyFollow
    {
        this.enabled = false;

        ExpSystem.instance.IncreaseExp(xp);

        

        //playerAnim.GetCurrentAnimatorStateInfo(0).IsName("bottle_die"))
        //GetComponent<Collider2D>().enabled = false;


    }

    void Update() //lance des projectiles
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        if (Vector2.Distance(Player.transform.position, this.transform.position) < 5f)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) < stoppingDistance && Vector2.Distance(transform.position, Player.transform.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -speed * Time.deltaTime) ;
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public IEnumerator DeathDelay() //cf EnemyFollow
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);

    }
}




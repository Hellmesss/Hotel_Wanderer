using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform[] attackPoints;
    public LayerMask enemyLayers;



    public static PlayerAttack instance;

    private Transform attackPoint;
    private float nextAttackTime = 0f;
    private int attackDamage=30;
    private float attackRate = 3f;
    private float attackRange = 0.5f;

    private void Awake()
    {

        if (instance != null)
        {
            return;
        }
        instance = this;

        attackPoint = attackPoints[0];

        
    }


    void Update() //gere l'attaque du player
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            attackPoint = attackPoints[0];
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            attackPoint = attackPoints[1];
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            attackPoint = attackPoints[2];
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            attackPoint = attackPoints[3];
        }


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }



    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log(hitEnemies.Length);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit");
            if (enemy.tag == "EnemyFollow")
                enemy.GetComponent<EnemyFollow>().TakeDamage(attackDamage);

            if (enemy.tag == "EnemyShooter")
                enemy.GetComponent<EnemyShooter>().TakeDamage(attackDamage);

            if (enemy.tag == "Grosu")
                enemy.GetComponent<grosu>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AddAttack()
    {
        attackDamage += Random.Range(5, 21);

    }
    public void AddAttackSpeed()
    {
        attackRate += Random.Range(0.5f, 1);
    }

    public void AddAttackRange()
    {
        attackRange += Random.Range(0.1f, 0.2f);
        if (attackRange >= 1)
            attackRange = 1;
    }
}
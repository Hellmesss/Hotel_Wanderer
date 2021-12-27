using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHeart;

    public GameObject player;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;

    public static Health instance;

    public bool Dead = false;

    public bool IsInvincible = false;

    public Animator anim;

    private void Awake() //gere la vie du player
    {
        if (instance != null)
        {
            return;
        }
        instance = this;


        anim = player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (health >= numOfHeart) { health = numOfHeart; } // if qui empeche de depasser le nombre de coeur max

        for (int i = 0; i < hearts.Length; i++) //boucle qui parcourt notre nombre de coeur max
        {
            if (i < health) // afficher les coeurs en fonction de leur etat 
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = brokenHeart;
            }

            if (i < numOfHeart) // desactiver les coeurs si il y en a plus que le nombre max
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public IEnumerator InvicibilityDelay() //invincibilité
    {
        yield return new WaitForSeconds(2f);
        IsInvincible = false;
    }


    public void AddHeart(int heart) //ajoute un coeur
    {
        health += heart;
    }

    public void Die()
    {
        anim.Play("Jane_Death1");
    }

    public void TakeDamages(int heart) //prends x dégats, joue les bonnes animations
    {
        if (!IsInvincible)
        {
            health -= heart;
            IsInvincible = true;
            StartCoroutine(InvicibilityDelay());

            if (health >= 0)
            {
                
                anim.Play("Jane_TakeDmg1");
            }

            if (health <= 0)
            {

                Dead = true;
                Die();
            }
        }
    }
}



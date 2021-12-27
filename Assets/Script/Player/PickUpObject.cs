using UnityEngine;

public class PickUpObject : MonoBehaviour
{


    private int speedBonus = 1;

    private void OnTriggerEnter2D(Collider2D collision) //permet de ramasser des objets au sol
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("Coin"))  //check le tag de l'objet avec lequel on rentre en collision
            {
                CoinCounter.instance.AddCoin(1);
                Destroy(gameObject);
            }
            if (this.CompareTag("Heart"))
            {
                if (CoinCounter.instance.coinCount >= 2)
                {
                    Health.instance.AddHeart(1);
                    CoinCounter.instance.RemoveCoin(2);
                    Destroy(gameObject);
                }
            }
            if (this.CompareTag("Candy"))
            {
                if (CoinCounter.instance.coinCount >= 5)
                {
                    PlayerAttack.instance.AddAttack();
                    CoinCounter.instance.RemoveCoin(5);
                    Destroy(gameObject);
                }
            }
            if (this.CompareTag("Juice"))
            {
                if (CoinCounter.instance.coinCount >= 3)
                {
                    PlayerMovement.instance.AddMoveSpeed(speedBonus);
                    CoinCounter.instance.RemoveCoin(3);
                    Destroy(gameObject);
                }
            }
        }
    }
}

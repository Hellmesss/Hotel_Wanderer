using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinCountText;
    public static CoinCounter instance;

    
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    public void AddCoin(int count) //modelise le porte feuille du joueur (le nombre de coin a sa disposotion)
    {
        coinCount = coinCount + count;
        coinCountText.text = coinCount.ToString();
    }

    public void RemoveCoin(int count)
    {
        
            coinCount = coinCount - count;
            coinCountText.text = coinCount.ToString();
        
    }
}

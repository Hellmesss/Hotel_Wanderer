using UnityEngine;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public int maxExp;
    public float updatedExp;

    public Image ExpBar;

    public int playerLevel;
    public Text levelText;

    public static ExpSystem instance;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start() //gere l'exp du joueur (monte de niveau)
    {
        playerLevel = 1;
        maxExp = 25;
        updatedExp = 0;
    }


    void Update()
    {
        ExpBar.fillAmount = updatedExp / maxExp;

        levelText.text = playerLevel + "";

        if (updatedExp >= maxExp && playerLevel < 5)
        {
            LevelUp();
            UpdateStats();
        }
    }

    public void IncreaseExp(int xp)
    {
        updatedExp += xp;
    }

    public void LevelUp ()
    {
        playerLevel++;
        updatedExp = updatedExp - maxExp;
        maxExp += maxExp;
    }

    public void UpdateStats()
    {
        PlayerAttack.instance.AddAttackSpeed();
        PlayerAttack.instance.AddAttackRange();
    }
}

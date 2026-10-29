using UnityEngine;

public class Arena : MonoBehaviour
{
    public enum HeroType { Warrior, Mage }

    [SerializeField] private HeroType heroType;
    [SerializeField] private int maximumRounds = 10;

    private Unit hero;
    private Unit enemy;

    void Awake()
    {
        if (heroType == HeroType.Warrior)
        {
            hero = new Unit("Воин", 100, 10, 16);
        }
        else
        {
            hero = new Unit("Маг", 130, 6, 12);
        }

        int enemyNumber = Random.Range(0, 3);

        if (enemyNumber == 0)
        {
            enemy = new Unit("Гоблин", 50, 4, 8);
        }
        else if (enemyNumber == 1)
        {
            enemy = new Unit("Орк", 80, 5, 10);
        }
        else
        {
            enemy = new Unit("Тролль", 140, 8, 12);
        }
    }

    void Start()
    {
        Debug.Log(hero.unitName + " (" + hero.health + " HP) против " + enemy.unitName + " (" + enemy.health + " HP)");

        for (int currentRound = 1; currentRound <= maximumRounds; currentRound++)
        {
            int heroDamage = hero.GetDamage();

            enemy.TakeDamage(heroDamage);

            string roundMessage = "Раунд " + currentRound + ": " + hero.unitName + " наносит " + heroDamage + ", у противника " + enemy.health + " HP";

            if (enemy.health == 0)
            {
                Debug.Log(roundMessage);
                Debug.Log("Победа! У героя осталось " + hero.health + " HP");
                return;
            }

            int enemyDamage = enemy.GetDamage();

            hero.TakeDamage(enemyDamage);

            roundMessage = roundMessage + "; " + enemy.unitName + " наносит " + enemyDamage + ", у героя " + hero.health + " HP";

            Debug.Log(roundMessage);

            if (hero.health == 0)
            {
                Debug.Log("Герой погиб");
                return;
            }
        }
    }
}

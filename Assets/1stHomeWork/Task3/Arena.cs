using UnityEngine;

public class Arena : MonoBehaviour
{
	public enum HeroType{Warrior, Mage}

	[SerializeField] private HeroType m_heroType;
	[SerializeField] private int m_maximumRounds = 10;

	[SerializeField] private UnitStats m_warriorStats;
	[SerializeField] private UnitStats m_mageStats;
	[SerializeField] private UnitStats m_goblinStats;
	[SerializeField] private UnitStats m_orcStats;
	[SerializeField] private UnitStats m_trollStats;

	private Unit m_hero;
	private Unit m_enemy;

	private void Awake()
	{
		if (m_heroType == HeroType.Warrior)
		{
			m_hero = new Unit(m_warriorStats);
		}
		else
		{
			m_hero = new Unit(m_mageStats);
		}

		int enemyNumber = Random.Range(0, 3);

		if (enemyNumber == 0)
		{
			m_enemy = new Unit(m_goblinStats);
		}
		else if (enemyNumber == 1)
		{
			m_enemy = new Unit(m_orcStats);
		}
		else
		{
			m_enemy = new Unit(m_trollStats);
		}
	}

	private void Start()
	{
		Debug.Log(m_hero.unitName + " (" + m_hero.health + " HP) против "
			+ m_enemy.unitName + " (" + m_enemy.health + " HP)");

		for (int currentRound = 1; currentRound <= m_maximumRounds; currentRound++)
		{
			int heroDamage = m_hero.GetDamage();

			m_enemy.TakeDamage(heroDamage);

			string roundMessage = "Раунд " + currentRound + ": "
				+ m_hero.unitName + " наносит " + heroDamage
				+ ", у противника " + m_enemy.health + " HP";

			if (m_enemy.health == 0)
			{
				Debug.Log(roundMessage);
				Debug.Log("Победа! У героя осталось " + m_hero.health + " HP");
				return;
			}

			int enemyDamage = m_enemy.GetDamage();

			m_hero.TakeDamage(enemyDamage);

			roundMessage = roundMessage + "; "
				+ m_enemy.unitName + " наносит " + enemyDamage
				+ ", у героя " + m_hero.health + " HP";

			Debug.Log(roundMessage);

			if (m_hero.health == 0)
			{
				Debug.Log("Поражение! Герой погиб");
				return;
			}
		}

		Debug.Log("Ничья! Закончились раунды");
	}
}

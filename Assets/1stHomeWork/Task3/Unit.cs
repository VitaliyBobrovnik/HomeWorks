using UnityEngine;

public class Unit
{
	public string unitName;
	public int health { get; private set; }

	private int m_minimumDamage;
	private int m_maximumDamage;

	public Unit(UnitStats unitStats)
	{
		unitName = unitStats.unitName;
		health = unitStats.health;
		m_minimumDamage = unitStats.minimumDamage;
		m_maximumDamage = unitStats.maximumDamage;
	}

	public int GetDamage()
	{
		int damage = DamageCalculator.CalculateDamage(m_minimumDamage, m_maximumDamage);
		return damage;
	}

	public void TakeDamage(int damageAmount)
	{
		health = health - damageAmount;

		if (health < 0)
		{
			health = 0;
		}
	}
}

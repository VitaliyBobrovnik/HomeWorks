using UnityEngine;

public static class DamageCalculator
{
	private const float CriticalMultiplier = 2f;

	public static float CalculateDamage(
		float weaponDamage,
		float armor,
		Task1.Element weaponElement,
		Task1.Element targetElement,
		float criticalChance,
		out float damageMultiplier,
		out bool isCritical)
	{
		float damage = weaponDamage - armor;

		if (damage < 1f)
		{
			damage = 1f;
		}

		if (weaponElement == Task1.Element.None || targetElement == Task1.Element.None)
		{
			damageMultiplier = 1f;
		}
		else if (weaponElement != targetElement)
		{
			damageMultiplier = 1.5f;
			damage = Mathf.FloorToInt(damage * damageMultiplier);
		}
		else
		{
			damageMultiplier = 0f;
			damage = damage * damageMultiplier;
		}

		isCritical = false;

		if (Random.Range(0f, 1f) < criticalChance)
		{
			damage = damage * CriticalMultiplier;
			isCritical = true;
		}

		return damage;
	}

	public static int CalculateDamage(int minimumDamage, int maximumDamage)
	{
		int weaponDamage = Random.Range(minimumDamage, maximumDamage + 1);
		float damageMultiplier;
		bool isCritical;

		float damage = CalculateDamage(
			weaponDamage,
			0f,
			Task1.Element.None,
			Task1.Element.None,
			0f,
			out damageMultiplier,
			out isCritical);

		return Mathf.FloorToInt(damage);
	}
}

using UnityEngine;

public class Unit
{  
    public int health { get; private set; }
    public string unitName;

    private int minimumDamage;
    private int maximumDamage;
    public Unit(string name, int unitHealth, int minDamage, int maxDamage)
    {
        unitName = name;
        health = unitHealth;
        minimumDamage = minDamage;
        maximumDamage = maxDamage;
    }
    public int GetDamage()
    {
        int damage = Random.Range(minimumDamage, maximumDamage + 1);
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

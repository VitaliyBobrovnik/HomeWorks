using UnityEngine;

public class Task1 : MonoBehaviour
{
    private float damage;
    private bool isCritical;
    private float damageMultiplier;
    private float criticalMultiplire = 2f;
    public enum Element {ice, fire, none}
    public float weaponDamage;
    public float armor;
    public float criticalChance;


    [SerializeField] private Element weaponElement;
    [SerializeField] private Element targetElement;


    private float DamageCalculaion()
    {
        damage = weaponDamage - armor;
        if(damage >= 1f)
        {
            return damage;
        }
        else
        {
            damage = 1f;
            return damage;
        }
    }
    void Start()
    {
        if ((weaponElement == Element.none) || targetElement == (Element.none))
        {
            damageMultiplier = 1f;
            DamageCalculaion();
        }
        else if (weaponElement != targetElement)
        {
            damageMultiplier = 1.5f;
            damage = Mathf.FloorToInt(DamageCalculaion() * damageMultiplier);
        }
        else
        {
            damageMultiplier = 0f;
            damage = DamageCalculaion() * damageMultiplier;
        }
        if((Random.Range(0f, 1f)) < criticalChance)
        {
            damage = damage * criticalMultiplire;
            isCritical = true;
        }
        Debug.Log($"Урон: {damage}, Броня: {armor}, Стихия оружия: {weaponElement}, Стихия цели: {targetElement}, Крит: {isCritical}, Шанс крита: {criticalChance}, Множитель урона: {damageMultiplier}");
    }

}

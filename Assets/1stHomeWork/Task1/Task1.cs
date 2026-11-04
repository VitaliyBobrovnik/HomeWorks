using UnityEngine;

public class Task1 : MonoBehaviour
{
    private float m_damage;
    private bool m_isCritical;
    private float m_damageMultiplier;

    public enum Element{None, Ice, Fire}

    public float weaponDamage;
    public float armor;
    public float criticalChance;

    [SerializeField] private Element m_weaponElement;
    [SerializeField] private Element m_targetElement;

    private void Start()
    {
        m_damage = DamageCalculator.CalculateDamage(
            weaponDamage,
            armor,
            m_weaponElement,
            m_targetElement,
            criticalChance,
            out m_damageMultiplier,
            out m_isCritical);

        Debug.Log($"Урон: {m_damage}, Броня: {armor}, Стихия оружия: {m_weaponElement}, Стихия цели: {m_targetElement}, Крит: {m_isCritical}, Шанс крита: {criticalChance}, Множитель урона: {m_damageMultiplier}");
    }
}

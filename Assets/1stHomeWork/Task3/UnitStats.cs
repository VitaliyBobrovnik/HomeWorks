using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "Game/Unit Stats")]
public class UnitStats : ScriptableObject
{
	public string unitName;
	public int health;
	public int minimumDamage;
	public int maximumDamage;
}

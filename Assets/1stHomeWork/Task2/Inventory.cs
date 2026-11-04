using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	private Dictionary<string, int> m_items = new Dictionary<string, int>();

	public void AddItem(string itemName, int itemCount = 1)
	{
		if (itemCount <= 0)
		{
			Debug.LogWarning("Количество добавляемых предметов должно быть больше 0");
			return;
		}

		if (m_items.ContainsKey(itemName) == true)
		{
			m_items[itemName] = m_items[itemName] + itemCount;
			Debug.Log("Добавлено: " + itemName + " x" + itemCount);
		}
		else
		{
			if (m_items.Count < 10)
			{
				m_items.Add(itemName, itemCount);
				Debug.Log("Добавлено: " + itemName + " x" + itemCount);
			}
			else
			{
				Debug.Log("Нет места для " + itemName);
			}
		}
	}

	public void RemoveItem(string itemName, int itemCount = 1)
	{
		if (itemCount <= 0)
		{
			Debug.LogWarning("Количество удаляемых предметов должно быть больше 0");
			return;
		}

		if (m_items.ContainsKey(itemName) == true)
		{
			if (m_items[itemName] >= itemCount)
			{
				m_items[itemName] = m_items[itemName] - itemCount;

				Debug.Log("Удалено: " + itemName + " x" + itemCount);

				if (m_items[itemName] == 0)
				{
					m_items.Remove(itemName);
				}
			}
			else
			{
				Debug.Log("Нельзя удалить " + itemName + ". Недостаточно предметов");
			}
		}
		else
		{
			Debug.Log("Нельзя удалить " + itemName + ". Такого предмета нет");
		}
	}

	public void Print()
	{
		int totalCount = 0;

		foreach (KeyValuePair<string, int> itemName in m_items)
		{
			Debug.Log(itemName.Key + " x" + itemName.Value);
			totalCount = totalCount + itemName.Value;
		}

		Debug.Log("Уникальных предметов: " + m_items.Count);
		Debug.Log("Всего предметов: " + totalCount);
	}
}

using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string itemName, int itemCount = 1)
    {
        if (items.ContainsKey(itemName) == true)
        {
            items[itemName] = items[itemName] + itemCount;
            Debug.Log("Добавлено: " + itemName + " x" + itemCount);
        }
        else
        {
            if (items.Count < 10)
            {
                items.Add(itemName, itemCount);
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
        if (items.ContainsKey(itemName) == true)
        {
            if (items[itemName] >= itemCount)
            {
                items[itemName] = items[itemName] - itemCount;

                Debug.Log("Удалено: " + itemName + " x" + itemCount);

                if (items[itemName] == 0)
                {
                    items.Remove(itemName);
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

        foreach (KeyValuePair<string, int> itemName in items)
        {
            Debug.Log(itemName.Key + " x" + itemName.Value);
            totalCount = totalCount + itemName.Value;
        }

        Debug.Log("Уникальных предметов: " + items.Count);
        Debug.Log("Всего предметов: " + totalCount);
    }
}

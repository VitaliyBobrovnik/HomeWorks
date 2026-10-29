using UnityEngine;

public class Task2 : MonoBehaviour
{
    void Start()
    {
        Inventory inventory = new Inventory();

        inventory.AddItem("ћеч", 2);
        inventory.AddItem("ўит");
        inventory.AddItem("«елье", 5);
        inventory.AddItem("ћеч", 3);
        
        inventory.RemoveItem("«елье", 2);
        inventory.RemoveItem("ўит");
        inventory.RemoveItem("Ћук");
        inventory.RemoveItem("ћеч", 10);

        inventory.Print();
    }
}

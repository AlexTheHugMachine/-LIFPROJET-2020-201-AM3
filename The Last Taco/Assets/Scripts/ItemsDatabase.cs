using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public Item[] allItems;
    public static ItemsDatabase instance;

    //Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de  ItemsDatabase dans la scène");
            return;
        }

        instance = this;
    }
}

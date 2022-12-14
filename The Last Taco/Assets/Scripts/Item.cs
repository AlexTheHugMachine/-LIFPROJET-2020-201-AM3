using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]

//Classe permettant de définir un item tel que la potion de vie ou de vitesse
public class Item : ScriptableObject
{
    public int id;
    public string Name;
    public string description;
    public int price;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
}

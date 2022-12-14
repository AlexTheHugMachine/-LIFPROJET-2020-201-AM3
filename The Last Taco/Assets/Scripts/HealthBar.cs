using UnityEngine;
using UnityEngine.UI;

//Classe permettant de définir la barre de vie du personnage
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    
    //Procédure permettant de mettre la vie du personnage au maximum et en changeant la couleur de la vie en vert
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    //Procédure permettant de définir le niveau de la vie. Elle modifie la taille de la barre ainsi que la couleur en fonction de la vie
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

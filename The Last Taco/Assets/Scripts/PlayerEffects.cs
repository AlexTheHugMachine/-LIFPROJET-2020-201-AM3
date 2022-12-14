using UnityEngine;
using System.Collections;

//Classe permettant de définir les effets spéciaux pour le joueur, comme augmenter la vitesse lorsque le joueur prend une potion de speed
public class PlayerEffects : MonoBehaviour
{

    //Procédure permettant d'ajouter de la vitesse lors de la prise de potion de speed
  public void AddSpedd(int speedGiven, float speedDuration)
  {
    PlayerMouvement.instance.moveSpeed += speedGiven;
    StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
  }

  //Procédure permettant de supprimer de la vitesse rajoutée pour revenir à la vitesse normale après un certain temps
  private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
  {
      yield return new WaitForSeconds(speedDuration);
      PlayerMouvement.instance.moveSpeed -= speedGiven;
  }
}

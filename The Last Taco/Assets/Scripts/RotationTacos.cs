using System.Collections;
using UnityEngine;

//Classe permettant la rotation sur eux mêmes des tacos sur le terrain
public class RotationTacos : MonoBehaviour
{
    public float rotz;
    public float RotationSpeed;
    public bool ClockWiseeRotation;

    //Procédure de mise à jour
    void Update()
    {
        if(ClockWiseeRotation == false)
        {
            rotz += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotz += -Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0,0,rotz);

    }
}

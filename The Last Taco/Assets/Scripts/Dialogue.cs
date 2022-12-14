using UnityEngine;

[System.Serializable]

//Classe définissant les possibilités de Dialogues pour les Boss par exemple
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
    [TextArea(3,10)]
    public string[] sentences2;
    [TextArea(3,10)]
    public string[] sentences3;
}

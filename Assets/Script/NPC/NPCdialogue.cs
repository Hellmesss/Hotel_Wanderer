using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCdialogue //fenetre de dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

}

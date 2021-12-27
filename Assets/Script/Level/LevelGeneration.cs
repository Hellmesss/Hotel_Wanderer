using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;

    private void Start() // instancie un nb random pour generer aleatoirement les levels template
    {
        int rand = Random.Range(0, objects.Length-1);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}

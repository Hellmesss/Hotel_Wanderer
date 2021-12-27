using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 --> bas 
    // 2 --> haut 
    // 3 --> gauche 
    // 4 --> droite 

    private RoomTemplate templates;
    private int rand;
    private int rand2;
    private bool spawned = false;
    public static bool GrosuSpawned = false;

    public float waitTime = 4f;


    private void Awake() //detruit tous les Gobj present dans la scene et recupere tous les Gobj avec le tag : room
                         //appelle la fct spawn avec une frequence de 0.1 f
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("spawn", 0.1f);
    }
    private void spawn() //permet de ne pas dupliquer grosu dans le meme etage et de faire spawn les rooms
    {
        if (spawned == false)
        {
            if (!GrosuSpawned)
            {
                rand2 = Random.Range(0, templates.LevelTemplates.Length - 1);
                if (rand2 == 5)
                {
                    GrosuSpawned = true;
                }
            }
            else
            {
                do
                {
                    rand2 = Random.Range(0, templates.LevelTemplates.Length - 1);
                } while (rand2 == 5);
            }
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length - 1);
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.LevelTemplates[rand2], transform.position, Quaternion.identity);

                //spawn bas
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length - 1);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.LevelTemplates[rand2], transform.position, Quaternion.identity);
                //spawn haut
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length - 1);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.LevelTemplates[rand2], transform.position, Quaternion.identity);
                //spawn gauche
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length - 1);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.LevelTemplates[rand2], transform.position, Quaternion.identity);
                //spawn droite
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //deux rooms ne sont pas superposable 
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner>().spawned == true && spawned == false)
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
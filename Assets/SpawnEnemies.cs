using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject Player;
    public float spawnrate;
    public float spawndelay;

    public GameObject Bat;

    void Start()
    {

        InvokeRepeating(nameof(SpawnEnemy), spawndelay, spawnrate);
    }
    void SpawnEnemy()
    {
        var position = new Vector2(Random.Range(Player.transform.position.x - 100f, Player.transform.position.x + 100f), Random.Range(Player.transform.position.y - 100f, Player.transform.position.y + 100f));
        Instantiate(Bat, position, Quaternion.identity);
    }

}
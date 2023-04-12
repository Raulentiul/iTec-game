using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int healthMax;
    int health;
    public GameObject HpBar;

    GameObject Enemy;


    private void Start()
    {


        health = healthMax;

        Enemy = this.gameObject;
    }

    void EnemyDamaged(int damage)
    {
        health -= damage;
        if (health >= 0) HpBar.transform.localScale = new Vector3((float)health / healthMax, 1);
        else { Destroy(gameObject); };
    }
}
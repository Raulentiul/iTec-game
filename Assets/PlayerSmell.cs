using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmell : MonoBehaviour
{
    GameObject[] gos;
    GameObject target;
    void FixedUpdate()
    {
        if (target == null) { gos = GameObject.FindGameObjectsWithTag("Enemy"); if (gos.Length > 0) target = gos[Random.Range(0, gos.Length - 1)]; }
        else
        {
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
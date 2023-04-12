using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public Transform Player;
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Player.position) > 150f) Destroy(gameObject);
    }
}
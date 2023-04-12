using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RClickDest : MonoBehaviour
{
    public LayerMask hitLayers;
    public Transform target;
    public Camera cam;
    void Update() {


        if (Input.GetMouseButtonDown(1)) {
            target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}

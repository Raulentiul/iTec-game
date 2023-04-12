using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    public int MaxSpeed;
    public float speed;
    public float nextWaypointDistance = 10f;
    public float update = .5f;
    public float nodesize;

    Pathfinding.Path path; // changed
    int currentWaypoint = 0;

    Seeker seeker;
    Transform transf;

    public Animator animator;
    float absX,absY;

    void Start() {

        seeker = GetComponent<Seeker>();
        transf = GetComponent<Transform>();

        InvokeRepeating(nameof(UpdatePath), 0f, update);

        speed = MaxSpeed;
    }

    void FixedUpdate() {
        if (path == null) { speed = 0f; animator.SetFloat("speed", speed); return; }
        if (Vector2.Distance(transf.position, target.position) < nodesize / 2) { speed = 0f; animator.SetFloat("speed", speed); ; return; }
        if (currentWaypoint >= path.vectorPath.Count) return;

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = MaxSpeed * 2;
        } else speed = MaxSpeed;

        Vector2 direction = ((Vector3)path.vectorPath[currentWaypoint] - transf.position).normalized;
        Vector2 force = speed * Time.deltaTime * direction;
        //Debug.Log(speed+ "fkmylife"+ direction);
        animator.SetFloat("speed", speed);
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            animator.SetBool("X>Y", true);
        }else animator.SetBool("X>Y", false);


        transf.Translate(force);

        float distance = Vector2.Distance(transf.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(transf.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Pathfinding.Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    //added

    /*public float GetDistanceToTarget() {
        List<Vector3> vPath = path.vectorPath;
        float totalDistance = 0;

        Vector3 current = transform.position;

        //Iterate through vPath and find the distance between the nodes
        for (int i = currentWaypoint; i < vPath.Count; i++) {
            totalDistance += (vPath[i] - current).magnitude;
            current = vPath[i];
        }

        totalDistance += (target.position - current).magnitude;

        return totalDistance;
    }*/



}

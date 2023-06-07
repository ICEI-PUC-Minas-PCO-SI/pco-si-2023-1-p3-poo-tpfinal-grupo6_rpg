using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    public float velMove, distanciaMax;

    private void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
        if (target != null)
            transform.position = target.position;
    }
    private void Update()
    {
        float vel = velMove;
        if (Vector2.Distance(transform.position, target.position) >= distanciaMax)
            vel = Mathf.MoveTowards(vel, 8, 2);

        transform.position = Vector2.MoveTowards(transform.position, target.position, vel * Time.deltaTime);
    }
}

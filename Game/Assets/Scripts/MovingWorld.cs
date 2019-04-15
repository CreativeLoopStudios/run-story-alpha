using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWorld : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 direction;

    private void Start()
    {
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}

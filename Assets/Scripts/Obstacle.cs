using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float Speed;

    void FixedUpdate()
    {
      transform.Translate(Vector3.back * Time.deltaTime * Speed, Space.World);
    }
}

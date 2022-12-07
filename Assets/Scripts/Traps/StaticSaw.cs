using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSaw : MonoBehaviour
{
    [SerializeField] private float RotationSpeed;
    [SerializeField] private bool RotateToRight;

    void Start()
    {
        if (RotateToRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}

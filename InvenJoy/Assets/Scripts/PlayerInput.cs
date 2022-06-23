using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string axis = "Horizontal";

    public float move { get; private set; }

    void Update()
    {
        move = Input.GetAxisRaw(axis);
    }
}

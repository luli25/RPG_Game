using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float xInput;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }
}

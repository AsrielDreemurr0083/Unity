using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public enum RoadLine
{
    Left = -1,
    Middle,
    Right
}


public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 2.0f;
    [SerializeField] Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        roadLine = RoadLine.Middle;
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine != RoadLine.Left) 
            {
                roadLine--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine != RoadLine.Right)
            {
                roadLine++;
            }
        }
    }

    void Update()
    {
        OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rigidbody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }
}

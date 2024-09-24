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
    [SerializeField] float speed = 25.0f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
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

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rigidbody.position = Vector3.Lerp
        (
            rigidbody.position, 
            new Vector3(positionX * (int)roadLine, 0, 0),
            speed * Time.fixedDeltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        IColliderable colliderable = other.GetComponent<IColliderable>();

<<<<<<< HEAD
        if (colliderable != null)
=======
        if(colliderable != null )
>>>>>>> b0999e6c45e4fbd6c3d8a4021f6e30fa0884492a
        {
            colliderable.Activate();
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}

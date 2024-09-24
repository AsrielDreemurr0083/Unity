using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IColliderable
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotationObject;

    [SerializeField] ParticleSystem particleSystem;

    public void Activate()
    {
<<<<<<< HEAD
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
=======
        particleSystem.Play();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

>>>>>>> b0999e6c45e4fbd6c3d8a4021f6e30fa0884492a
    private void OnEnable()
    {
        rotationObject = GameObject.Find("Rotation GameObject");

        speed = rotationObject.GetComponent<RotationManager>().Speed;

        transform.localRotation = rotationObject.transform.localRotation;
    }

    
}

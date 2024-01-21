using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;

    public float mainThrust = 500f;
    public float rotationThrust = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!audioSource.isPlaying)
            {
                 audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rigidbody.freezeRotation = true;
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
            rigidbody.freezeRotation = false;
        }
    }

}


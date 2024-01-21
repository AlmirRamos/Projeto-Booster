using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mainThrust = 500f;
    public float rotationThrust = 50f;
    public AudioClip mainEngine;

    Rigidbody rigidb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
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
            rigidb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!audioSource.isPlaying)
            {
                 audioSource.PlayOneShot(mainEngine);
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
            rigidb.freezeRotation = true;
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
            rigidb.freezeRotation = false;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField]float mainThrust = 1000f;
    [SerializeField]float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrustParticles;
    [SerializeField] ParticleSystem rightthrustParticles;
    [SerializeField] ParticleSystem leftthrustParticles;
    
    Rigidbody rb;
    AudioSource audioSource;

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
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
     
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);


        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!thrustParticles.isPlaying)
        {
            thrustParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        thrustParticles.Stop();
    }

   
    void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
        if (!rightthrustParticles.isPlaying)
        {
            rightthrustParticles.Play();
        }
    }
    
    void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
        if (!leftthrustParticles.isPlaying)
        {
            leftthrustParticles.Play();
        }
    }
    
    void StopRotating()
    {
        rightthrustParticles.Stop();
        leftthrustParticles.Stop();
    }

    

    void ApplyRotation(float rotationvalue)
    {
        rb.freezeRotation = true; //freezing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward * rotationvalue * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so that physics system can take over
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInfliater : MonoBehaviour
{
    private Rigidbody rb;

    public float floatStrength = 3.5f;
    public float maxSize = 3;
    [Range(0, 1)] public float riseSize = .5f;
    public float timeToReachMaxSize = 1;
    public float maxDrag = 100;
      
    private float maxSpeed = 6;
    private float minSpeed = 2;

    private float randomSpeed;

    private Vector3 baseScale;
    private Vector3 targetScale;
    private Vector3 sizeToRise;
    //rigidbody'deki drag deðerine eþit
    private float startDrag;  
    private float timeInflating;


    private float speed;


    void Start()
    {
        
        int currentBoosterCount = PlayerPrefs.GetInt("booster_count", 0);

        if(currentBoosterCount > 0)
        {
            maxSpeed = 10;
            minSpeed = 4;

        }
        
        randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        

        rb = GetComponent<Rigidbody>();

        baseScale = transform.localScale;
        targetScale = baseScale * maxSize;

        
        sizeToRise = baseScale * (riseSize * maxSize);
        startDrag = rb.drag;

    }
  
    private void Update()
    {
        BeginInfliate();

    }

    private void BeginInfliate()
    {
        // Increment the inflation time
        timeInflating += Time.deltaTime;
        // Turn off gravity
        rb.useGravity = false;
        // Set the object's velocity to an upward vector
        rb.velocity = new Vector3(0, speed, 0);

        // Clamp the inflation time within the max inflation time
        timeInflating = Mathf.Clamp(timeInflating, 0, timeToReachMaxSize);

        // Interpolate the object's local scale between the base scale and target scale
        transform.localScale = Vector3.Lerp(baseScale, targetScale, timeInflating / timeToReachMaxSize);

        // Interpolate the object's drag value between the start drag and max drag
        rb.drag = Mathf.Lerp(startDrag, maxDrag, InverseLerp(baseScale, sizeToRise, transform.localScale));

        // Interpolate the object's speed between 0 and the random speed
        speed = Mathf.Lerp(0, randomSpeed, InverseLerp(sizeToRise, targetScale, transform.localScale));

        // If the object's scale has reached the "sizeToRise" value, turn off gravity and set the velocity
        if (transform.localScale.magnitude >= sizeToRise.magnitude)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(0, speed, 0);
        }
        // If not, turn on gravity
        else
        {
            rb.useGravity = true;
        }        
    }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.35f;
    public float frequency = 0.5f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}

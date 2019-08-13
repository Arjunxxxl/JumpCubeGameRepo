using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBgEffect : MonoBehaviour
{
    public enum Shape
    {
        square, triangle
    }
    public Shape shape;

    [System.Serializable]
    public class Data
    {
        public float minSpeedSquare = 10;
        public float maxSpeedSquare = 50;
        public float minRotationSpeed = 10;
        public float maxRotationSpeed = 50;
        public float triangleMinSpeed = 30;
        public float triangleMaxSpeed = 70f;
    }
    [SerializeField]
    public Data data;

    [System.Serializable]
    public class SizeData
    {
        public float minSize;
        public float maxSize;
        public float currentSize;
        public float minSizeDecSpeed;
        public float maxSizeDecSpeed;
        public float sizeDecreaseSpeed;
        public Vector3 size;
        public Vector3 finalMinScale = new Vector3(0.15f, 0.15f, 1f);
    }
    [SerializeField]
    public SizeData sizeData;

    [Header("Local data")]
    public float speed_movement;
    public float rotation_speed;

    // Start is called before the first frame update
    void Start()
    {
        if (shape == Shape.square)
        {
            speed_movement = Random.Range(data.minSpeedSquare, data.maxSpeedSquare);
        }
        else if(shape == Shape.triangle)
        {
            speed_movement = Random.Range(data.triangleMinSpeed, data.triangleMaxSpeed);
        }
        rotation_speed = Random.Range(data.minRotationSpeed, data.maxRotationSpeed);
        sizeData.currentSize = Random.Range(sizeData.minSize, sizeData.maxSize);
        sizeData.size = Vector3.one * sizeData.currentSize;
        transform.localScale = sizeData.size;
        sizeData.sizeDecreaseSpeed = Random.Range(sizeData.minSizeDecSpeed, sizeData.maxSizeDecSpeed);
    }

    private void OnEnable()
    {
        if (shape == Shape.square)
        {
            speed_movement = Random.Range(data.minSpeedSquare, data.maxSpeedSquare);
        }
        else if (shape == Shape.triangle)
        {
            speed_movement = Random.Range(data.triangleMinSpeed, data.triangleMaxSpeed);
        }
        rotation_speed = Random.Range(data.minRotationSpeed, data.maxRotationSpeed);
        sizeData.currentSize = Random.Range(sizeData.minSize, sizeData.maxSize);
        sizeData.size = Vector3.one * sizeData.currentSize;
        transform.localScale = sizeData.size;
        sizeData.sizeDecreaseSpeed = Random.Range(sizeData.minSizeDecSpeed, sizeData.maxSizeDecSpeed);
    }

    public void Reset()
    {
        if (shape == Shape.square)
        {
            speed_movement = Random.Range(data.minSpeedSquare, data.maxSpeedSquare);
        }
        else if (shape == Shape.triangle)
        {
            speed_movement = Random.Range(data.triangleMinSpeed, data.triangleMaxSpeed);
        };
        rotation_speed = Random.Range(data.minRotationSpeed, data.maxRotationSpeed);
        sizeData.currentSize = Random.Range(sizeData.minSize, sizeData.maxSize);
        sizeData.size = Vector3.one * sizeData.currentSize;
        transform.localScale = sizeData.size;
        sizeData.sizeDecreaseSpeed = Random.Range(sizeData.minSizeDecSpeed, sizeData.maxSizeDecSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed_movement * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * rotation_speed * Time.deltaTime, Space.World);

        transform.localScale = Vector3.Lerp(transform.localScale, sizeData.finalMinScale, Time.deltaTime * sizeData.sizeDecreaseSpeed);
    }
}

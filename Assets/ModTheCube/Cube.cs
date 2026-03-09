using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 RotationAxis;
    private float RotationSpeed;
    private Material Mat;
    
    private Color TargetColor;
    [SerializeField] private float ColorTimer = 0f;
    [SerializeField] private float ColorInterval = 2f;
    [SerializeField] private float LerpSpeed = 2f;
    
    private void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Random.Range(0.5f, 5f) * Vector3.one;
        
        RotationAxis = Random.onUnitSphere;
        RotationSpeed = Random.Range(20f, 100f);
        
        Mat = GetComponent<Renderer>().material;
        TargetColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
        Mat.color = TargetColor;
    }
    
    private void Update()
    {
        transform.Rotate(RotationAxis, Time.deltaTime * RotationSpeed);
        
        ColorTimer += Time.deltaTime;
        if (ColorTimer >= ColorInterval)
        {
            TargetColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
            ColorTimer = 0f;
        }
        
        Mat.color = Color.Lerp(Mat.color, TargetColor, Time.deltaTime * LerpSpeed);
    }
}

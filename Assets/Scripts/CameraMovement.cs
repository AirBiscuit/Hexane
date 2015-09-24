using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float RotationRate = .2f;

    void Update()
    {
        transform.Rotate(0, RotationRate * Time.deltaTime * 100, 0);
    }

    public void IncreaseSpeed()
    {
        RotationRate += .01f;
    }

}

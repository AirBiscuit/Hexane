using UnityEngine;

using System.Collections;

public class Pickup : MonoBehaviour
{
    GameObject mainCam, timer;
    const float ANGLESTEP = 6.95f, DISTANCE = 15f;
    float[] yPositions = new float[] { 2.423977f, 0.8602456f, -0.7363977f, -2.33395f };
    Quaternion toZeroXYZ, toZeroXZ;

    void Start()
    {
        toZeroXYZ = transform.rotation;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        timer = GameObject.FindGameObjectWithTag("Timer");
    }

    void Update()
    {
        toZeroXYZ = Quaternion.FromToRotation(Vector3.zero, transform.position);
        toZeroXZ = new Quaternion(transform.rotation.x, toZeroXYZ.y, transform.rotation.z, transform.rotation.w);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toZeroXZ, 360);
    }

    public void ReInitializeSelf()
    {
        Debug.Log("Resetting...");
        int Angle = Random.Range(0, 52);
        int Row = Random.Range(0, 3);
        Debug.Log(string.Format("Angle {0} Row {1}", Angle, Row));
        if (Row == 1 || Row == 3)
            transform.position = new Vector3(DISTANCE * Mathf.Cos((ANGLESTEP / 2) * Angle), yPositions[Row], DISTANCE * Mathf.Sin((ANGLESTEP / 2) * Angle));
        else
            transform.position = new Vector3(DISTANCE * Mathf.Cos(ANGLESTEP * Angle), yPositions[Row], DISTANCE * Mathf.Sin(ANGLESTEP * Angle));

        mainCam.GetComponent<CameraMovement>().IncreaseSpeed();
        timer.GetComponent<TimerControl>().AddTime();
    }
}

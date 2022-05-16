using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController CM;
    static public CameraController controller
    {
        get
        {
            return CM;
        }
        set
        {
            CM = value;
        }
    }
    Camera cam;
    public Camera mainCamera
    {
        set
        {
            cam = value;
        }
    }

    Vector3 startCamPos;
    private void Awake()
    {
        CM = this;
        mainCamera = Camera.main;
    }
    public void CameraShake(int numberOfShakes, float intensity, float shakeTime, Vector2 axis)
    {
        StartCoroutine(CameraShakeCOR(numberOfShakes, intensity, shakeTime, axis));
    }

    IEnumerator CameraShakeCOR(int numberOfShakes, float intensity, float shakeTime, Vector2 axis)
    {
        startCamPos = cam.transform.position;
        float timeBetweenShakes = shakeTime / numberOfShakes;
        for (int i = 0; i < numberOfShakes; i++)
        {
            cam.transform.position += new Vector3(axis.x * (int)Random.Range(-1, 1), axis.y * (int)Random.Range(-1, 1), 0) * intensity;
            yield return new WaitForSeconds(timeBetweenShakes);
            cam.transform.position = startCamPos;
        }
    }
    public void CameraPositioning(Vector2 P, float cameraMaxDistance, float cameraLerpSpeed, GameObject follow)
    {
        Vector2 middlePoint = (P - (Vector2)cam.transform.position) / 2 / cameraMaxDistance;
        cam.transform.position = Vector2.Lerp(cam.transform.position, middlePoint + (Vector2)follow.transform.position, Time.deltaTime * cameraLerpSpeed);
        cam.transform.position += new Vector3(0, 0, -1);
    }
}
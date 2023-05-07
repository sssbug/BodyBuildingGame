using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float xVelocity, smoothTime, characterMinX, characterMaxX, cameraMinX, cameraMaxX;
    Vector3 offset;
    float map(float val, float amin, float amax, float bmin, float bmax)
    {
        return Mathf.Lerp(bmin, bmax, Mathf.InverseLerp(amin, amax, val));
    }
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, map(player.transform.position.x, characterMinX, characterMaxX, cameraMinX, cameraMaxX), ref xVelocity, smoothTime), transform.position.y, player.transform.position.z + offset.z);
    }
}


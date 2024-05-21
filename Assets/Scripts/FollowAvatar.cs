using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAvatar : MonoBehaviour
{
    public GameObject player; //Access user avatar
    private Vector3 offset = new Vector3(-3, 20, -20); //Create offset for camera to follow user from
    public float smoothSpeed = 0.125f;

    void Start()
    {

    }

   //Update camera position to follow player
    void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, smoothSpeed);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float positionThreshold = 0.1f; // Threshold to detect significant player movement

    private Vector3 previousTargetPosition;

    void Start()
    {
        if (target != null)
        {
            previousTargetPosition = target.position;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);

            if (Vector3.Distance(previousTargetPosition, target.position) > positionThreshold)
            {
                transform.position = Vector3.Slerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
                previousTargetPosition = target.position;
            }
        }
    }
}

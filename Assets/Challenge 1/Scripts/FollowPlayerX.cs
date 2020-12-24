using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;

    [SerializeField]
    private Vector3 offset = new Vector3 { x = 0, y = 5, z = -10 };

    private Vector3 playerPrevPos, playerMoveDir;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = offset.magnitude;
        playerPrevPos = plane.transform.position;
    }

    void LateUpdate()
    {
        playerMoveDir = plane.transform.position - playerPrevPos;

        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            
            transform.position = plane.transform.position - playerMoveDir * distance;

            transform.position = transform.position + offset;

            transform.LookAt(plane.transform.position);

            playerPrevPos = plane.transform.position;
        }
    }
}

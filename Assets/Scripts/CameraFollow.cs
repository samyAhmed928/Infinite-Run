
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offest;
    void Start()
    {
        offest=transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 targetPos = player.position + offest;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}

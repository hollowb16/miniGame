using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    // public Transform  targetToFollowl;

    // private float CameraX;
    // private float CameraY;
    // public float ZOffset;
    // public float YOffset;
    // public float XDeadZone = 50.0f;
    // public float YDeadZone = 50.0f;
    // public float CameraSpeed;
    // float startTime;
    public float dampTime = 0.15f;
    public Vector3 velocity = Vector2.zero;
    public Transform target;
    Camera camera;

    void Start()
    {
        // transform.position =  new Vector3(targetToFollowl.position.x,targetToFollowl.position.y,transform.position.z);
        // CameraX = transform.position.x;
        // CameraY = transform.position.y;
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {   
    //     CameraX = GetNewXValue();
    //     CameraY = GetNewYValue();

    //     Vector3 targetPosition = new Vector3(CameraX,CameraY,transform.position.z);
    //      transform.position =   Vector3.Lerp(transform.position,targetPosition,CameraSpeed * Time.deltaTime);

    if(target){
        Vector3 point = camera.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position,destination,ref velocity,dampTime);
    }
       
    }


    // float GetNewXValue () {
        
    //    if (targetToFollowl.position.x - XDeadZone > transform.position.x)
    //    {
    //        return targetToFollowl.position.x - XDeadZone;
    //    }else if (targetToFollowl.position.x + XDeadZone < transform.position.x)
    //    {
    //        return targetToFollowl.position.x + XDeadZone;
    //    }
    //    else{
    //        return CameraX;
    //    }
    // }

    // float GetNewYValue () {
    //     if (targetToFollowl.position.y - (YDeadZone - YOffset) > transform.position.y)
    //     {
    //         return targetToFollowl.position.y - (YDeadZone - YOffset);
    //     }else if (targetToFollowl.position.y + (YDeadZone + YOffset) < transform.position.y)
    //     {
    //         return targetToFollowl.position.y + (YDeadZone + YOffset);
    //     }else{
    //         return CameraY;
    //     }

    // }

    
}

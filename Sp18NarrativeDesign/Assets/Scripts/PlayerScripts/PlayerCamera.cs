﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;
    [SerializeField] Vector3 playerOffset;
    [SerializeField] Vector3 maxPosOffset;
    [SerializeField] Vector3 minPosOffset;
    float yAxisRotation = 0;
    float xAxisRotation = 0;


    [SerializeField] float minCameraXAngle = -7.5f;
    [SerializeField] float maxCameraXAngle = 45;

    [SerializeField] float sensitivity = 1.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerObject != null)
        {
            xAxisRotation += 100 * sensitivity * -Input.GetAxis("Mouse Y") * Time.deltaTime;
            xAxisRotation = Mathf.Clamp(xAxisRotation, minCameraXAngle, maxCameraXAngle);

            yAxisRotation += 100 * sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;

            transform.eulerAngles = new Vector3(xAxisRotation, transform.eulerAngles.y, transform.eulerAngles.z);

            transform.position = PlayerObject.transform.position + Quaternion.Euler(xAxisRotation, yAxisRotation, 0) * playerOffset;
            transform.LookAt(new Vector3(
                PlayerObject.transform.position.x,
                this.transform.position.y,
                PlayerObject.transform.position.z
                ));
            transform.eulerAngles = new Vector3(xAxisRotation, transform.eulerAngles.y, transform.eulerAngles.z);
            //   transform.RotateAround(PlayerObject.transform.position,new Vector3(0,1,0),5 * Time.deltaTime );
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PlayerObject.transform.position + Quaternion.Euler(0, yAxisRotation, 0) * playerOffset, .5f);

    }
    private void OnEnable()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }
}

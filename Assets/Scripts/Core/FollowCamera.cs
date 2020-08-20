using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        private Quaternion newRotation;

        public float speed;
        public float horizontalRotationSpeed = 250.0f;

        private float h;


        void LateUpdate()
        {
            transform.position = target.position;

            if (Input.GetMouseButton(1))
            {
                // RotateCamera();

                // transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

                transform.Rotate(0f, Input.GetAxis("Mouse X") * horizontalRotationSpeed * Time.deltaTime, 0f);
            }
        }
    }
}
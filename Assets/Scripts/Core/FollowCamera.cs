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

        private void Start()
        {
            Initialize();
        }

        void LateUpdate()
        {
            transform.position = target.position;

            if (Input.GetMouseButton(1))
            {
                // RotateCamera();

                transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
            }
        }

        private void Initialize()
        {
            h = this.transform.eulerAngles.x;
        }

        private void RotateCamera()
        {
            print("Rotate Camera");

            //Cursor.lockState = CursorLockMode.Locked;

            h += Input.GetAxis("Mouse X") * horizontalRotationSpeed * Time.deltaTime;

            h = ClampAngle(h, -360.0f, 360.0f);

            newRotation = Quaternion.Euler(0.0f, h, 0.0f);
        }

        /* Keeps the angles values within their specificed minimum and maximum
     * inputs while at the same time putting the values back to 0 if they
     * go outside of the 360 degree range */
        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;

            if (angle > 360)
                angle -= 360;

            return Mathf.Clamp(angle, min, max);
        }
    }
}
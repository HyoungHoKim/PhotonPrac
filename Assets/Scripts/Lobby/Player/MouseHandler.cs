using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

namespace Com.Intern.hyoukim
{
    public class MouseHandler : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        // horizontal rotation speed
        public float horizontalSpeed = 1f;
        // vertical rotation speed
        public float verticalSpeed = 1f;
        #endregion

        #region private Fields
        private float xRotation = 0.0f;
        private float yRotation = 0.0f;
        private Camera cam;
        #endregion

        #region MonoBehaviour Callbacks
        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponentInChildren<Camera>();
            if (!photonView.IsMine)
            {
                cam.enabled = false;
                cam.GetComponent<AudioListener>().enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
                float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

                yRotation += mouseX;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90, 90);

                cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
                this.transform.eulerAngles = new Vector3(0.0f, yRotation, 0.0f);
            }
        }
        #endregion
    }
}

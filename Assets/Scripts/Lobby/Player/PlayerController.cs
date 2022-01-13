using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

namespace Com.Intern.hyoukim
{
    public class PlayerController : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        public float MovementSpeed = 1f;
        public float Gravity = 9.8f;
        #endregion

        #region Private Fields
        CharacterController characterController;
        private float velocity = 0;
        #endregion

        #region MonoBehavior Callbacks
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                // playermovement - forward, backward, left, right
                float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
                float vertical = Input.GetAxis("Vertical") * MovementSpeed;
                characterController.Move((right * horizontal + forward * vertical) * Time.deltaTime);

                // Gravity
                if (characterController.isGrounded)
                {
                    velocity = 0;
                } 
                else
                {
                    velocity -= Gravity * Time.deltaTime;
                    characterController.Move(new Vector3(0, velocity, 0));
                }
            }
        }
        #endregion
    }
}

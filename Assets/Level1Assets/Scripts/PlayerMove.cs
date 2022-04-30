using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

namespace ICTProject
{
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField]
        float jetForce = 0, jetMax = 5f, buildSpeed = 3f;

        public CinemachineVirtualCamera Vcam;
        //float normCamDistance = 2, maxCamDistance = 4;

        public float rotationSpeed;

        public PlayerInputMaps controls;

        InputAction leftStick, rightStick, jet;

        public ParticleSystem jetEffects;

        private void OnEnable()
        {
            leftStick = controls.Player.LeftStick;
            leftStick.Enable();
            rightStick = controls.Player.RightStick;
            rightStick.Enable();
            jet = controls.Player.Jet;
            jet.Enable();
        }

        private void OnDisable()
        {
            leftStick.Disable();
            rightStick.Disable();
            jet.Disable();
        }

        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            controls = new PlayerInputMaps();
        }

        float yaw, pitch, roll;
        bool doJet = false, isBuildingPower = false;

        private void Update()
        {
            Vcam.m_Lens.FieldOfView = (jetForce / jetMax * 10 + 80);

            yaw = leftStick.ReadValue<Vector2>().x;
            pitch = -leftStick.ReadValue<Vector2>().y;
            //roll = rightStick.ReadValue<Vector2>().x;

            if (jet.IsPressed() && !isBuildingPower)
                isBuildingPower = true;

            //holding jet builds power, releasing launches. draw back camera as power builds. 
            if (jet.IsPressed() && isBuildingPower)
            {
                jetForce += Time.deltaTime * buildSpeed;
                if (jetForce > jetMax)
                    jetForce = jetMax;
            }

            if (!jet.IsPressed() && isBuildingPower)
            {
                doJet = true;
                isBuildingPower = false;
                jetEffects.Play();
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (doJet)
            {
                doJet = false;
                rb.AddForce(transform.forward * jetForce, ForceMode.Impulse);
                jetForce = 0;
            }

            rb.AddTorque(transform.up * yaw * rotationSpeed * Time.deltaTime);
            rb.AddTorque(transform.right * pitch * rotationSpeed * Time.deltaTime);
            //rb.AddTorque(transform.forward * -roll * rotationSpeed * Time.deltaTime);
            
        }
    }

}

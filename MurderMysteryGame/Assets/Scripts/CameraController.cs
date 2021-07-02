using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public Transform m_targetObject;

    [SerializeField]
    public bool m_canMove = true;

    [SerializeField]
    public Vector3 m_zoomAmount = new Vector3(0, -10.0f, 10.0f);

    private Camera mainCamera;
    private Transform camRig;

    private Quaternion newCamRot;
    private Vector3 newCamZoom;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        camRig = mainCamera.transform.parent.transform;

        newCamRot = camRig.rotation;
    }

    private void Update()
    {
        if (m_canMove)
        {
            CameraMovement();
        }
    }

    private void CameraMovement()
    {
        // Follows player
        camRig.position = m_targetObject.position;

        if (Input.GetKeyDown(KeyCode.A))
        {
            newCamRot *= Quaternion.Euler(Vector3.up * 90.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            newCamRot *= Quaternion.Euler( Vector3.up * -90.0f);
        }

        camRig.rotation = Quaternion.Lerp(camRig.rotation, newCamRot, Time.deltaTime * 12.0f);

        //if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
        //{
        //    newCamZoom += m_zoomAmount;
        //}

        //if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        //{
        //    newCamZoom -= m_zoomAmount;
        //}

        //mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, newCamZoom, Time.deltaTime * 15.0f);
    }
}

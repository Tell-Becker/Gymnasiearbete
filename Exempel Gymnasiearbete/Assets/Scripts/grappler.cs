using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappler : MonoBehaviour
{
    private Vector3 mousePos;
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;
    public LayerMask grappleMask; // Se om jag kan göra att den bara grapplar på ett visst layer
    public bool isGrapplerActive;

    void Start()
    {
        distanceJoint.enabled = false;
        isGrapplerActive = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            distanceJoint.connectedAnchor = mousePos;
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
            isGrapplerActive = true; 
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
            isGrapplerActive = false; 
        }
        if (distanceJoint.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
        
    }

    // private Vector3 _mousePos;
    // private Camera _camera;

    // private bool _check;

    // private DistanceJoint2D _distanceJoint;

    // private LineRenderer _lineRenderer;

    // private Vector3 _tempPos;

    // public LayerMask grappleMask;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     _camera = Camera.main;
    //     _distanceJoint = GetComponent<DistanceJoint2D>();
    //     _lineRenderer = GetComponent<LineRenderer>();
    //     _distanceJoint.enabled = false;
    //     _check = true;
    //     _lineRenderer.positionCount = 0;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     GetMousePos();

    //     RaycastHit2D hit2D = Physics2D.Raycast(_camera.transform.position, _mousePos, Mathf.Infinity, grappleMask);
    //     if (Input.GetMouseButtonDown(0) && _check) // && hit2D
    //     {
    //         _distanceJoint.enabled = true;
    //         _distanceJoint.connectedAnchor = _mousePos;
    //         _lineRenderer.positionCount = 2;
    //         _tempPos = _mousePos;
    //         _check = false;
    //     }else if (Input.GetMouseButtonDown(0))
    //     {
    //         _distanceJoint.enabled = false;
    //         _check = true;
    //         _lineRenderer.positionCount = 0;
    //     }
    //     DrawLine();
    // }

    // private void DrawLine()
    // {
    //     if(_lineRenderer.positionCount <=0) return;
    //     _lineRenderer.SetPosition(0,transform.position);
    //     _lineRenderer.SetPosition(1,_tempPos);
    // }

    // private void GetMousePos()
    // {
    //     _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    // }
}
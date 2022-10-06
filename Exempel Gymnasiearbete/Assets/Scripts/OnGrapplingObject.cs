using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrapplingObject : MonoBehaviour
{
    public bool MouseOnGrappleLayer {get; private set;}

    private void OnMouseOver()
    {
        MouseOnGrappleLayer = true;
    }

    private void OnMouseExit()
    {
        MouseOnGrappleLayer = false;
    }
}

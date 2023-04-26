using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    [Header("Object Config")]
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject wim;
    [SerializeField] private Rigidbody rb;

    public void teleport()
    {
        rb.constraints = RigidbodyConstraints.None;
        RaycastHit hit;
        rayInteractor.TryGetCurrent3DRaycastHit(out hit);
        Vector3 localHit = map.transform.InverseTransformPoint(hit.point);
        Debug.Log(localHit);
        Vector3 worldHit = world.transform.TransformPoint(localHit);
        Debug.Log(worldHit);
        worldHit.y += 1.0f;
        
        
        Camera.main.transform.parent.position= worldHit;
        worldHit.x += 4.0f;
        wim.transform.position = worldHit;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void tryGrabObject(GameObject grabObject) {
        if (grabObject == null)
            return;

        grabbedObject = grabObject;
        var bounds = grabObject.GetComponent<MeshRenderer>().bounds;

        grabbedObjectSize = (bounds.max - bounds.min).magnitude;
    }

    void dropObject() {
        if (grabbedObject == null)
            return;

        var rigidbody = grabbedObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
            rigidbody.velocity = Vector3.zero;


        grabbedObject = null;
    }


    GameObject getMouseHoverObject(float range) {
        var position = Camera.main.transform.position;
        RaycastHit raycastHit;
        var target = Camera.main.transform.forward;
        var ray = new Ray(position, target);
        int layerMask = 1 << LayerMask.NameToLayer("Water");

        int buttonLayerMask = 1 << LayerMask.NameToLayer("Button");
        if (Physics.Raycast(ray, out raycastHit, range, buttonLayerMask)) {
            if (raycastHit.collider.gameObject != null) {
                UnionZone.instance.UnionAtom();
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 2.5f);
        if (Physics.Raycast(ray, out raycastHit, range, layerMask))
            return raycastHit.collider.gameObject;

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if(grabbedObject == null)
                tryGrabObject(getMouseHoverObject(5.0f));
            else
                dropObject();
        }
        if (grabbedObject != null) {
            var position = Camera.main.transform.position;
            var forward = Camera.main.transform.forward;
            var newPostion = position + forward * (grabbedObjectSize + 1.0f);
            grabbedObject.transform.position = newPostion;
        }

    }
}

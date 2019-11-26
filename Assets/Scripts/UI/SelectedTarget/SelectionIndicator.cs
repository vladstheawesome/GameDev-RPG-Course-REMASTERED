using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    MouseManager mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mm.selectedObject != null)
        {
            //Bounds bigBounds = mm.selectedObject.GetComponentInChildren<Renderer>().bounds;

            //// This "diameter" only works correctly for relatively circular or square objects
            //float diameter = bigBounds.size.z;
            //diameter *= 3.25f;

            //this.transform.position = new Vector3(bigBounds.center.x, 0, bigBounds.center.z);
            //this.transform.localScale = new Vector3(bigBounds.size.x, bigBounds.size.y, bigBounds.size.z);

            this.transform.position = mm.selectedObject.transform.position;
        }
    }
}

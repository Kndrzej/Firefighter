using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHelmet : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               // if(hit.)
            }
        }
    }
}

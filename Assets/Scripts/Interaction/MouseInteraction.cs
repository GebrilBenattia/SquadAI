using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Input.GetMouseButtonDown(0))
            return;

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("Pawn")) {
            Transform objectHit = hit.transform;

            //m_Controller.controlledPawn = objectHit.gameObject.GetComponent<Pawn>();
        }
    }
}

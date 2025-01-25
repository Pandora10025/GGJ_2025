using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;

    private Transform _selection;
    private bool isLooking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;

        }


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Selectable"))
            {
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;

                    isLooking = true;
                }

                _selection = selection;
            }
            
        }


        if (isLooking && Input.GetMouseButtonDown(0))
        {
            //this.GetComponent<DialogueManager>().textboxIsActive = true;
            if(_selection != null) this.GetComponent<DialogueManager>().ActivateTextBox(_selection.GetComponent<ObjectBehavior>().objName, _selection.GetComponent<ObjectBehavior>().objText);
            isLooking = false;
        }
        
    }
}

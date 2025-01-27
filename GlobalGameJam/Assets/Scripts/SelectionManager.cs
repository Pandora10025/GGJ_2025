using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Fungus;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;

    private Transform _selection;
    private bool isLooking;
    public Flowchart flowchart;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("is talking" + gameManager.GetComponent<GameManager>().isTalking);
        if(_selection != null)
        {
            _selection = null;
        } else
        {
            this.GetComponent<DialogueManager>().DeactivateTextBox();
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            if (selection.CompareTag("Selectable"))
            {
                isLooking = true;
                _selection = selection;
            }
            
        }


        if (isLooking)
        {
            if(Input.GetKeyDown(KeyCode.Space) && !gameManager.GetComponent<GameManager>().isTalking)
            {
                Debug.Log("clicked");
                //if (_selection != null) this.GetComponent<DialogueManager>().ActivateTextBox(_selection.GetComponent<ObjectBehavior>().objName, _selection.GetComponent<ObjectBehavior>().objText);
                if(_selection != null) flowchart.SendFungusMessage(_selection.GetComponent<ObjectBehavior>().FungusMessage);
                isLooking = false;
            }
            
        }
        
    }
}

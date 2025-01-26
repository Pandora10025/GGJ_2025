using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject flowchart;
    [SerializeField] GameObject player;
    [SerializeField] GameObject blackOut;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flowchart.GetComponent<Flowchart>().GetBooleanVariable("isTalking"))
        {
            player.GetComponent<PlayerMovement>().isFrozen = true;
        } else
        {
            player.GetComponent<PlayerMovement>().isFrozen = false;
        }
    }
}

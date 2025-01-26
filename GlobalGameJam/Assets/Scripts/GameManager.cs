using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject flowchart;
    [SerializeField] GameObject player;
    [SerializeField] GameObject blackOut;

    float blackAlpha;
    bool isSeeing;

    public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        blackAlpha = 1;
    }

    // Update is called once per frame
    void Update()
    {

        isTalking = flowchart.GetComponent<Flowchart>().GetBooleanVariable("isTalking");
        if (isTalking)
        {
            player.GetComponent<PlayerMovement>().isFrozen = true;
        } else
        {
            player.GetComponent<PlayerMovement>().isFrozen = false;
        }

        if (!isSeeing && flowchart.GetComponent<Flowchart>().GetBooleanVariable("CanSee")) {
            blackAlpha = Mathf.Lerp(blackAlpha, 0, 0.005f);
            blackOut.GetComponent<Image>().color = new Color(0, 0, 0, blackAlpha);
            if (blackAlpha == 0) isSeeing = true;
        }
    }
}

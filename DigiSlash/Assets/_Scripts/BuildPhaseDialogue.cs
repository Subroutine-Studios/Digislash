using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPhaseDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueManager _dialogueManager;

    //Dialogue first
    private bool inDialogue = true;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartDialogue());

    }

    // Update is called once per frame
    void Update()
    {



    }

    private IEnumerator StartDialogue()
    {

        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();

    }
}

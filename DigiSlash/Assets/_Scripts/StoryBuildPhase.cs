using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryBuildPhase : MonoBehaviour
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


        if (inDialogue && _dialogueManager.done)
        {
            inDialogue = false;
            _dialogueManager.done = false;

            StartCoroutine(StartDialogue());
     
        }


        // last scene is done , load level 1
        if (_dialogueManager.done && _dialogueManager._sceneIndex == 6)
        {
        
            SceneManager.LoadScene("Level_One");
        }

        else if (_dialogueManager.done)
        {
            _dialogueManager.done = false;
            StartCoroutine(StartDialogue());
        }


        Debug.Log("Scene index " + _dialogueManager._sceneIndex);



    }

    private IEnumerator StartDialogue()
    {

        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();
       
    }

 }
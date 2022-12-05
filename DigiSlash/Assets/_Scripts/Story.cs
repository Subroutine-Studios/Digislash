using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * NOTE NOTE NOTE
 * THIS script is unique per level, depending on when you want dialogue or a wave
 * NOTE NOTE NOTE
 */
public class Story : MonoBehaviour
{
    [SerializeField]
    private DialogueManager _dialogueManager;

    //Dialogue first
    private bool inDialogue = true;


   

    // Start is called before the first frame update
    void Start()
    {
        //Start talking about the tutorial/story
        StartCoroutine(StartDialogue());

    }


    void Update()
    {
  
        if (inDialogue && _dialogueManager.done) 
        {
            SceneManager.LoadScene(2);
        }

    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();
    }
}

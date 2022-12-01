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
    [SerializeField]
    private GameObject orbImage;

   

    // Start is called before the first frame update
    void Start()
    {
        //Start talking about the tutorial/story
        StartCoroutine(StartDialogue());

        orbImage.gameObject.SetActive(false);
    }


    void Update()
    {
  
        if (inDialogue && _dialogueManager.done) 
        {
            inDialogue = false;
            _dialogueManager.done = false;

            orbImage.gameObject.SetActive(true);
            Debug.Log("Orb Image " + orbImage.gameObject.activeSelf);

            StartCoroutine(StartDialogue());

           // Debug.Log("dialogue manager " + _dialogueManager.done);
        }

        if (_dialogueManager.done)
        {
            Debug.Log("Load Level 1");
            SceneManager.LoadScene("Level_One");

        }


    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();
    }
}

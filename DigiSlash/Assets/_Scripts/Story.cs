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

    private bool showWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        //Start talking about the tutorial/story
        StartCoroutine(StartDialogue());

        orbImage.gameObject.SetActive(false);
    }


    void Update()
    {
        // if (inDialogue && _dialogueManager.done && showWeapon)
        if (inDialogue && _dialogueManager.done)
        {
            inDialogue = false;
            _dialogueManager.done = false;
            SceneManager.LoadScene("Level_One");
        }

        /*
        else if(!showWeapon)
        {
            inDialogue = true;
            orbImage.gameObject.SetActive(true);
            StartCoroutine(StartDialogue());
        }
        */

    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();
    }
}

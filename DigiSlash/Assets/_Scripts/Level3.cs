using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * NOTE NOTE NOTE
 * THIS script is unique per level, depending on when you want dialogue or a wave
 * NOTE NOTE NOTE
 */
public class Level3 : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private DialogueManager _dialogueManager;

    //Dialogue first
    private bool inDialogue = true;

    private bool inCombat = false;

    // Start is called before the first frame update
    void Start()
    {
        //Start talking about the incoming enemies 
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        //If dialogue is done
        if (inDialogue && _dialogueManager.done)
        {
            inDialogue = false;
            _dialogueManager.done = false;
            //When theres still more waves to go
            if (_gameManager._spawnManager.currentWave < 3)
            {
                Debug.Log("Current Wave : " + _gameManager._spawnManager.currentWave);
                inCombat = true;
                _gameManager.StartWave();
            }

            //Go to next level
            else
            {
                // go to Level 2
                Debug.Log("Completed the waves");
                StartCoroutine(StartDialogue());
                if (Input.GetKeyDown(KeyCode.Return))
                    SceneManager.LoadScene(4);
            }
        }

        //If combat is done
        else if (inCombat && _gameManager.isPlayerSuccessful)
        {
            inCombat = false;
            Debug.Log("isPlayerSuccessful " + _gameManager.isPlayerSuccessful + "  inCombat " + inCombat);

            /* Call dialogue manager if you need to say something at the next wave
             * 
             * inDialogue = true;
             * StartCoroutine(StartDialogue());
             * 
             * 
             * 
             * You can choose which wave has dialogue and which one goes straight to the next wave using this code
             * 
             * switch(_gameManager._spawnManager.currentWave)
             * {
             *      //Wave 0 will have dialogue before combat
             *      case 0: inDialogue = true;
             *              StartCoroutine(StartDialogue());
             *              break;
             *              
             *      //Wave 1 will have dialogue before combat
             *      case 1: inDialogue = true;
             *              StartCoroutine(StartDialogue());
             *              break;
             *              
             *      //Wave 2 will go straight to combat
             *      case 2: inCombat = true;
                             _gameManager.StartWave();
             *              break;
             * }
             * 
             */

            switch (_gameManager._spawnManager.currentWave)
            {
                //Wave 0 will have dialogue before combat
                case 0:
                    inDialogue = true;
                    Debug.Log("CASE 0 inCombat: " + inCombat);
                    StartCoroutine(StartDialogue());
                    break;

                //Wave 1 will have dialogue before combat
                case 1:
                    inDialogue = true;
                    Debug.Log("CASE 1 inCombat:  " + inCombat);
                    StartCoroutine(StartDialogue());
                    break;

                //Wave 2 will go straight to combat
                case 2:
                    inDialogue = true;
                    Debug.Log("CASE 2 inCombat:  " + inCombat);
                    StartCoroutine(StartDialogue());
                    break;
                // all waves have been cleared
                case 3:
                    inDialogue = true;
                    inCombat = false;
                    Debug.Log("All waves cleared.");
                    StartCoroutine(StartDialogue());
                    break;
                    
                    /* Switching to next level works. Will uncomment once all levels are accomplished/
                     * 
                    // go to level 2
                    if (Input.GetKeyDown(KeyCode.Return))
                        SceneManager.LoadScene(4);
                    break;
                    */
            }

        }
    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        _dialogueManager.NextSentence();
    }
}

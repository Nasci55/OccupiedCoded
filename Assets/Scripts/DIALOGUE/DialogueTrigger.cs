using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private bool showDialogueOnlyOnce;
 
    public Dialogue dialogue;

    public UnityEvent OnDialogueTriggered;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        OnDialogueTriggered?.Invoke();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
            if (showDialogueOnlyOnce)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
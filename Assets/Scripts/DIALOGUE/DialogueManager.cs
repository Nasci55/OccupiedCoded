using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
 
    [SerializeField] private Image characterIcon;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogueArea;
 
    private Queue<DialogueLine> lines;

    [SerializeField]
    private bool isDialogueActive = false;

    [SerializeField]
    private float typingSpeed = 0.2f;

    [SerializeField]
    private Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DisplayNextDialogueLine();
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
 
        lines = new Queue<DialogueLine>();
    }
 
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
 
        animator.Play("show");
 
        lines.Clear();
 
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
 
        DisplayNextDialogueLine();
    }
 
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
 
        DialogueLine currentLine = lines.Dequeue();
 
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
 
        StopAllCoroutines();
 
        StartCoroutine(TypeSentence(currentLine));
    }
 
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
 
    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}
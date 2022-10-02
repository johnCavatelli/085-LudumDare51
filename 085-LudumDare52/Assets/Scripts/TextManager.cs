using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI talkingHeadText;
    public TextMeshProUGUI toolTipText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI cashText;
    public Image headImage1;
    public Image headImage2;
    public Animator animator;
    public Button yesChoiceButton;
    public Button noChoiceButton;
    public static TextManager current;

    private bool typing = false;
    private bool makingChoice = false;
    private string currentTextBeingTyped;



    internal Button getYesChoiceButton()
    {
        yesChoiceButton.onClick.RemoveAllListeners();
        return yesChoiceButton;
    }
    internal Button getNoChoiceButton()
    {
        noChoiceButton.onClick.RemoveAllListeners();
        return noChoiceButton;
    }

    internal void MakeChoice(string t)
    {
        FindObjectOfType<playerMovement>().Freeze();
        FindObjectOfType<MouseLook>().Freeze();
        talkingHeadText.text = t;
        Cursor.lockState = CursorLockMode.None;
        makingChoice = true;
        yesChoiceButton.gameObject.SetActive(true);
        noChoiceButton.gameObject.SetActive(true);
    }

    internal void EndChoice(string s)
    {
        Cursor.lockState = CursorLockMode.Locked;
        DisplayDialogue(s);
        yesChoiceButton.gameObject.SetActive(false);
        noChoiceButton.gameObject.SetActive(false);
    }
    internal void StartDialogue(string firstName, Sprite talkingSpriteFirst, Sprite talkingSpriteSecond)
    {
        nameText.text = firstName;
        headImage1.sprite = talkingSpriteFirst;
        headImage2.sprite = talkingSpriteSecond;
        animator.SetBool("InDialogue", true);
    }

    internal void EndDialogue()
    {
        StopCoroutine("TypeText");
        animator.SetBool("InDialogue", false);
        FindObjectOfType<playerMovement>().UnFreeze();
        FindObjectOfType<MouseLook>().UnFreeze();
    }

    internal void DisplayDialogue(string v)
    {
        FindObjectOfType<playerMovement>().Freeze();
        FindObjectOfType<MouseLook>().Freeze();
        currentTextBeingTyped = v;
        StartCoroutine("TypeText", v);
    }

    private void Awake()
    {
        current = this;
    }

    private IEnumerator TypeText(string toType)
    {
        typing = true;
        makingChoice = false;
        talkingHeadText.text = " ";
        char[] characters = toType.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            talkingHeadText.text += characters[i];
            AudioManager.current.talkSource.pitch = UnityEngine.Random.Range(0.5f, 1.5f);
            AudioManager.current.talkSource.Play();
            yield return new WaitForSeconds(0.04f);
        }
        typing = false;
    }

    internal bool AttemptProgressInteraction()
    {
        print("HEREEEE " + makingChoice);

        if (typing)
        {
            StopCoroutine("TypeText");
            talkingHeadText.text = currentTextBeingTyped;
            typing = false;
            return false;
        }
        else if (!makingChoice)
        {
            EndDialogue();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateTipText(string v)
    {
        toolTipText.text = v;
    }

    public void ClearTipText()
    {
        if(toolTipText.text != null)
        {
            toolTipText.text = null;
        }
    }

    public void DisplayMessage(string message)
    {
        messageText.text = "";
        StopCoroutine("WriteMessage");

        StartCoroutine("WriteMessage", message);
    }

    IEnumerator WriteMessage(string message)
    {
        messageText.text = message;
        yield return new WaitForSeconds(1.2f);
        while(messageText.text.Length > 0)
        {
            messageText.text = messageText.text.Remove(messageText.text.Length - 1);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void UpdateCashText(int newVal)
    {
        cashText.text = newVal.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneTextDispalyer : MonoBehaviour
{
    public string text;
    public TextMeshProUGUI box;
    public AudioSource talkSource;
    private void OnEnable()
    {           
        StartCoroutine("TypeText", text);
    }

    private IEnumerator TypeText(string toType)
    {
        //typing = true;
        box.text = " ";
        char[] characters = toType.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            box.text += characters[i];
            talkSource.pitch = UnityEngine.Random.Range(0.5f, 1.5f);
            talkSource.Play();
            yield return new WaitForSeconds(0.02f);
        }
        //typing = false;
    }
}

using TMPro;
using UnityEngine;

public class DialogLine : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] string[] timelineTextLines;

    int currentLine = 0;

    void NextDialogLine()
    {
        currentLine++;
        dialogText.text = timelineTextLines[currentLine];
    }
}

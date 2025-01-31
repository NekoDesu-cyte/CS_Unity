    using TMPro;
using UnityEngine;

public class DialogLine : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogText;
 

    int currentLine = 0;

    public void NextDialogLine()
    {
        currentLine++;
        dialogText.text = timelineTextLines[currentLine];
    }
}

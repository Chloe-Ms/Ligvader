using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _newHSText;

    private void Start()
    {
        StartCoroutine(BlinkRoutine());
    }
    IEnumerator BlinkRoutine()
    {
        if (_newHSText != null)
        {
            while (true)
            {
                _newHSText.color = new Color(_newHSText.color.r, _newHSText.color.g, _newHSText.color.b, 1);
                yield return new WaitForSeconds(0.35f);
                _newHSText.color = new Color(_newHSText.color.r, _newHSText.color.g, _newHSText.color.b, 0);
                yield return new WaitForSeconds(0.35f);
            }
        }
    }
}

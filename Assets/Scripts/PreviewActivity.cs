using System.Collections;
using TMPro;
using UnityEngine;

public class PreviewActivity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _previewText;
    [SerializeField] private int _previewSeconds = 3;

    void Awake()
    {
        StartCoroutine(preview());
    }

    private IEnumerator preview() {
        for (int i = _previewSeconds; i > 0; i--) {
            _previewText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        gameObject.SetActive(false);
    }
}

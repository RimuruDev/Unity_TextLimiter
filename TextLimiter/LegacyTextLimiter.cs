using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.TextLimiter
{
#if UNITY_EDITOR
    [ExecuteAlways]
#endif
    [RequireComponent(typeof(Text))]
    public sealed class LegacyTextLimiter : MonoBehaviour
    {
        [SerializeField, Min(0)] private int maxLength = 120;
        [SerializeField, HideInInspector] private Text uiText;

        private void Awake() =>
            CacheTextComponent();

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate() =>
            CacheTextComponent();

        private void Update() =>
            UpdateText(uiText.text);

        public void UpdateText(string newText) =>
            uiText.text = newText.Length > maxLength ? newText[..maxLength] : newText;

        private void CacheTextComponent()
        {
            if (uiText == null)
                uiText = GetComponent<Text>();
        }
    }
}
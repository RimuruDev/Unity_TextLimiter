// Resharper disable all
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub    Organizations: https://github.com/Rimuru-Dev
// **************************************************************** //

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
        [SerializeField] private bool editorMode;

        private void Awake() =>
            CacheTextComponent();

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate() =>
            CacheTextComponent();

        private void Update()
        {
            if (!editorMode)
                return;

            UpdateText(uiText.text);
        }

        public void UpdateText(string newText) =>
            uiText.text = newText.Length > maxLength ? newText[..maxLength] : newText;

        private void CacheTextComponent()
        {
            if (uiText == null)
                uiText = GetComponent<Text>();
        }
    }
}
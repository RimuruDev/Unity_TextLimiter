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

using TMPro;
using UnityEngine;

namespace RimuruDev.TextLimiter
{
#if UNITY_EDITOR
    [ExecuteAlways]
#endif
    [RequireComponent(typeof(TMP_Text))]
    public class TMPTextLimiter : MonoBehaviour
    {
        [SerializeField, Min(0)] private int maxLength = 120;
        [SerializeField, HideInInspector] private TMP_Text uiText;
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
                uiText = GetComponent<TMP_Text>();
        }
    }
}
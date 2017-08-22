using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUIAnimation
{
    public class GUIAnimator : MonoBehaviour
    {
        public Image image;
        public Text text;
        public RectTransform rect;

        void Start()
        {
            image = GetComponent<Image>();
            text = GetComponent<Text>();
            rect = GetComponent<RectTransform>();

            FadeInitialize();
            MoveInitialize();
            ScaleInitialize();
        }

        #region Functions

        private void FadeInitialize()
        {
            if (!fade.enable) return;

            fade.sAlpha = image != null ? image.color.a : text.color.a;
        }

        private void MoveInitialize()
        {
            if (!move.enable) return;
            move.sPosition = rect.anchoredPosition;
        }

        private void ScaleInitialize()
        {
            if (!scale.enable) return;
            scale.sScale = rect.localScale;
        }

        #endregion//Functions

        #region Variables

        public Fade fade;
        public Move move;
        public Scale scale;

        #endregion//Variables

        #region Animation Class

        public class Anima
        {
            public bool enable;
            public float delay;
            public float time;
            public bool loop;
        }

        [System.Serializable]
        public class Fade : Anima
        {
            [Range(0f, 1f)]
            public float sAlpha;
            [Range(0f, 1f)]
            public float eAlpha;
        }

        [System.Serializable]
        public class Move : Anima
        {
            public Vector2 sPosition;
            public Vector2 ePosition;
        }

        [System.Serializable]
        public class Scale : Anima
        {
            public Vector3 sScale;
            public Vector3 eScale;
        }

        #endregion//Animation Class
    }
}
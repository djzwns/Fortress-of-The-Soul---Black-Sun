using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUIAnimation
{
    public class GUIAnimSystem : MonoBehaviour
    {
        static private GUIAnimSystem _instance;
        static public GUIAnimSystem instance
        {
            get
            {
                if (_instance != null) return _instance;
                else
                {
                    GameObject go = new GameObject("GUIAnimationManager");
                    _instance = go.AddComponent<GUIAnimSystem>();

                    return _instance;
                }
            }
        }

        public void AnimIn(GUIAnimator _gui)
        {
            FadeIn(_gui);
            MoveIn(_gui);
            ScaleIn(_gui);
        }

        private void FadeIn(GUIAnimator _gui)
        {
            if (!_gui.fade.enable) return;

            StartCoroutine(_FadeIn(_gui));
        }

        private IEnumerator _FadeIn(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.fade.delay);

            float time = 0;
            Color color = _gui.image != null ? _gui.image.color : _gui.text.color;
            Color sColor = new Color(color.r, color.g, color.b, _gui.fade.sAlpha);
            Color eColor = new Color(color.r, color.g, color.b, _gui.fade.eAlpha);

            while (time < 1)
            {
                time += Time.deltaTime / _gui.fade.time;

                if (_gui.image == null)
                    _gui.text.color = Color.Lerp(eColor, sColor, time);
                else
                    _gui.image.color = Color.Lerp(eColor, sColor, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.fade.loop)
                yield return StartCoroutine(_FadeOut(_gui));
        }

        private void MoveIn(GUIAnimator _gui)
        {
            if (!_gui.move.enable) return;

            StartCoroutine(_MoveIn(_gui));
        }

        private IEnumerator _MoveIn(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.move.delay);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime / _gui.move.time;

                _gui.rect.anchoredPosition = Vector2.Lerp(_gui.move.ePosition, _gui.move.sPosition, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.move.loop)
                yield return StartCoroutine(_MoveOut(_gui));
        }

        private void ScaleIn(GUIAnimator _gui)
        {
            if (!_gui.scale.enable) return;

            StartCoroutine(_ScaleIn(_gui));
        }

        private IEnumerator _ScaleIn(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.scale.delay);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime / _gui.move.time;

                _gui.rect.localScale = Vector2.Lerp(_gui.scale.eScale, _gui.scale.sScale, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.scale.loop)
                yield return StartCoroutine(_ScaleOut(_gui));
        }

        public void AnimOut(GUIAnimator _gui)
        {
            FadeOut(_gui);
            MoveOut(_gui);
            ScaleOut(_gui);
        }

        private void FadeOut(GUIAnimator _gui)
        {
            if (!_gui.fade.enable) return;

            StartCoroutine(_FadeOut(_gui));
        }

        private IEnumerator _FadeOut(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.fade.delay);

            float time = 0;
            Color color = _gui.image != null ? _gui.image.color : _gui.text.color;
            Color sColor = new Color(color.r, color.g, color.b, _gui.fade.sAlpha);
            Color eColor = new Color(color.r, color.g, color.b, _gui.fade.eAlpha);

            while (time < 1)
            {
                time += Time.deltaTime / _gui.fade.time;

                if (_gui.image == null)
                    _gui.text.color = Color.Lerp(sColor, eColor, time);
                else
                    _gui.image.color = Color.Lerp(sColor, eColor, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.fade.loop)
                yield return StartCoroutine(_FadeIn(_gui));
        }

        private void MoveOut(GUIAnimator _gui)
        {
            if (!_gui.move.enable) return;

            StartCoroutine(_MoveOut(_gui));
        }

        private IEnumerator _MoveOut(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.move.delay);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime / _gui.move.time;

                _gui.rect.anchoredPosition = Vector2.Lerp(_gui.move.sPosition, _gui.move.ePosition, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.move.loop)
                yield return StartCoroutine(_MoveIn(_gui));
        }

        private void ScaleOut(GUIAnimator _gui)
        {
            if (!_gui.scale.enable) return;
            StartCoroutine(_ScaleOut(_gui));
        }

        private IEnumerator _ScaleOut(GUIAnimator _gui)
        {
            yield return new WaitForSeconds(_gui.scale.delay);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime / _gui.move.time;

                _gui.rect.localScale = Vector2.Lerp(_gui.scale.sScale, _gui.scale.eScale, time);

                yield return new WaitForEndOfFrame();
            }

            if (_gui.scale.loop)
                yield return StartCoroutine(_ScaleIn(_gui));
        }

        private void EnableUI(GUIAnimator _gui, bool _enable)
        {
            _gui.gameObject.SetActive(_enable);
        }
    }
}
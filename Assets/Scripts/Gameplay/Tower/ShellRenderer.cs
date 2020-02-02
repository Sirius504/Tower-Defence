using System.Collections;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay.TowerSystem
{
    public class ShellRenderer : MonoBehaviour
    {
        [SerializeField] private float animationTime = .1f;
        [SerializeField] private float fadeOutTime = .4f;
        private LineRenderer lineRenderer;
        private Coroutine currentRoutine;

        [Inject]
        public void Construct(LineRenderer lineRenderer)
        {
            this.lineRenderer = lineRenderer;
            lineRenderer.enabled = false;
        }

        public void DrawShotAt(Vector3 target, Vector3 targetSpeed)
        {
            if (currentRoutine != null)
                StopCoroutine(currentRoutine);

            currentRoutine = StartCoroutine(DrawArrowLine(target + targetSpeed * animationTime));
        }

        private IEnumerator DrawArrowLine(Vector3 targetPosition)
        {
            ResetLineRenderer();
            float startTime = Time.time;
            Vector3 toTarget = InverseScale(targetPosition - transform.position, transform.lossyScale);
            float t = 0f;
            while (t <= 1f)
            {
                t = (Time.time - startTime) / animationTime;
                var newPositon = Vector3.Lerp(Vector3.zero, toTarget, t);
                lineRenderer.SetPosition(1, newPositon);
                yield return new WaitForEndOfFrame();
            }

            t = 0f;
            float fadeOutStart = Time.time;
            while (t <= 1f)
            {
                t = (Time.time - fadeOutStart) / fadeOutTime;
                lineRenderer.startColor = Color.Lerp(lineRenderer.startColor, SetAlpha(lineRenderer.startColor, 0f), t);
                lineRenderer.endColor = Color.Lerp(lineRenderer.endColor, SetAlpha(lineRenderer.endColor, 0f), t);
                yield return new WaitForEndOfFrame();
            }

            lineRenderer.enabled = false;
        }

        private void ResetLineRenderer()
        {
            lineRenderer.enabled = true;
            lineRenderer.startColor = SetAlpha(lineRenderer.startColor, 1f);
            lineRenderer.endColor = SetAlpha(lineRenderer.endColor, 1f);
            lineRenderer.SetPosition(1, Vector3.zero);
        }

        private Vector3 InverseScale(Vector3 vector, Vector3 scale)
        {
            return new Vector3(
                vector.x / scale.x,
                vector.y / scale.y,
                vector.z / scale.z);
        }

        private Color SetAlpha(Color color, float value)
        {
            return new Color(color.r, color.g, color.b, value);
        }
    } 
}

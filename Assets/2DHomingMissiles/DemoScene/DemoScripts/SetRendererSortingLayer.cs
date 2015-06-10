using UnityEngine;
using System.Collections;

namespace TwoDHomingMissiles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class SetRendererSortingLayer : MonoBehaviour
    {
        public string sortingLayerName;
        public int sortingLayerId;
        public bool usesParticleRenderer;

        // Use this for initialization
        void Start()
        {

            if (!usesParticleRenderer)
            {
                var particleRenderer = gameObject.GetComponent<ParticleSystem>().renderer;

                if (particleRenderer != null)
                {
                    particleRenderer.sortingLayerName = sortingLayerName;
                    particleRenderer.sortingOrder = sortingLayerId;
                    particleRenderer.sortingLayerID = sortingLayerId;
                }
            }
            else
            {
                var particleRenderer = gameObject.GetComponent<ParticleRenderer>().renderer;

                if (particleRenderer != null)
                {
                    particleRenderer.sortingLayerName = sortingLayerName;
                    particleRenderer.sortingOrder = sortingLayerId;
                    particleRenderer.sortingLayerID = sortingLayerId;
                }
            }
        }
    }
}
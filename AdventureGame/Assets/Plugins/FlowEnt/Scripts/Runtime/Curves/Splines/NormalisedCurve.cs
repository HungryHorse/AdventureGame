//Special thanks to Chris Hargrove(https://github.com/ChrisHargrove) for pointing out the need for normalisation.
using UnityEngine;

namespace FriedSynapse.FlowEnt
{
    /// <summary>
    /// This curve is a normalised version of any ICurve given.
    /// </summary>
    /// <remarks>
    /// The concept of normalisation means that the delta T will be proportional to the lenght of each segment of the curve.
    /// </remarks>
    public class NormalisedCurve : ICurve
    {
        private const int DefaultResolution = 100;
        public NormalisedCurve(ICurve normalisableCurve, int resolution = DefaultResolution)
        {
            this.normalisableCurve = normalisableCurve;
            this.resolution = resolution;
            this.resolutionStep = 1f / resolution;
            this.distances = new float[resolution];
            this.distanceTravelled = new float[resolution];
            Init();
        }
        private readonly ICurve normalisableCurve;
        private readonly int resolution;
        private readonly float resolutionStep;
        private readonly float[] distances;
        private readonly float[] distanceTravelled;
        private float distance;

        private void Init()
        {
            Vector3 start = normalisableCurve.GetPoint(0);
            Vector3 end;
            distanceTravelled[0] = 0;
            for ((int i, float endStep) = (0, resolutionStep); i < resolution - 1; i++, endStep += resolutionStep)
            {
                end = normalisableCurve.GetPoint(endStep);
                float stepDistance = Vector3.Distance(start, end);
                distances[i] = stepDistance;
                distance += stepDistance;
                distanceTravelled[i + 1] = distance;
                start = end;
            }
            distances[resolution - 1] = 0;
        }

        public Vector3 GetPoint(float t)
        {
            float distanceT = t * distance;
            int segment = GetSegment(distanceT, 0, distanceTravelled.Length - 1);
            float segmentDistance = distanceT - distanceTravelled[segment];
            float segmentT;
            if (distances[segment] == 0)
            {
                segmentT = 0;
            }
            else
            {
                segmentT = segmentDistance / distances[segment];
            }
            float normalisedT = (segment + segmentT) / resolution;
            return normalisableCurve.GetPoint(normalisedT);
        }

        private int GetSegment(float distanceT, int start, int end)
        {
            if (end - start <= 1)
            {
                return start;
            }

            int mid = (start + end) / 2;
            if (distanceTravelled[mid] < distanceT)
            {
                return GetSegment(distanceT, mid, end);
            }
            else
            {
                return GetSegment(distanceT, start, mid);
            }
        }
    }
}

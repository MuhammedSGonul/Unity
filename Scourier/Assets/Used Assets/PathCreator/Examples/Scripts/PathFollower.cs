using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        [HideInInspector] public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        [HideInInspector] public float speed = 0;
        [HideInInspector] public float distanceTravelled;

        [HideInInspector] public bool isPathChanged = false;


        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

                if (distanceTravelled >= pathCreator.path.length)
                {
                    isPathChanged = true;
                }


            }

        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

    }
}
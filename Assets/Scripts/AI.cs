using UnityEngine;
using System.Collections;
using Pathfinding.RVO;

namespace Pathfinding
{
    /*
        AI Controller designed specifically for 'blacky'.
        Attach this script to the AI to have it be able to pathfind around stuff.
        Attach this bad boy to a parent GameObject...

        Overrides the AIPath class, see that class's documentation for more information on most variables.

        NOTE:   This script assumes Y is up and that character movement is mostly on the XZ plane
    */

    [RequireComponent(typeof (Seeker))]
    public class AI : AIPath
    {
        /** Minimum velocity for moving */
        public float sleepVelocity = 0.4F;

        public override Vector3 GetFeetPosition()
        {
            return tr.position;
        }

        // Use this for initialization
        private void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        private void Update()
        {
            //  Get velocity in game world.
            if (canMove)    //  found in AIPath class.
            {
                //Get velocity in world-space
                Vector3 velocity;
                if (canMove)
                {

                    //Calculate desired velocity
                    Vector3 dir = CalculateVelocity(GetFeetPosition());

                    //Rotate towards targetDirection (filled in by CalculateVelocity)
                    RotateTowards(targetDirection);

                    dir.y = 0;
                    if (dir.sqrMagnitude > sleepVelocity * sleepVelocity)
                    {
                        //If the velocity is large enough, move
                    }
                    else
                    {
                        //Otherwise, just stand still (this ensures gravity is applied)
                        dir = Vector3.zero;
                    }

                    if (navController != null)
                    {
                        velocity = Vector3.zero;
                    }
                    else if (controller != null)
                    {
                        controller.SimpleMove(dir);
                        velocity = controller.velocity;
                    }
                    else
                    {
                        Debug.LogWarning("No NavmeshController or CharacterController attached to GameObject");
                        velocity = Vector3.zero;
                    }
                }
                else
                {
                    velocity = Vector3.zero;
                }


                //  TODO:   Do we need to animate something here?

            }
        }
    }
}

using UnityEngine;

namespace _Main.Scripts.Grid
{
    public class MyNode
    {
        public int XId { get; private set; }
        public int YId { get; private set; }
        public float Radius { get; private set; }
        public bool Walkable { get; private set; }
        public Vector3 WorldPos { get; private set; }

        public MyNode(bool p_walkable, Vector3 p_worldPos, float p_radius, Vector3 p_gridPosition)
        {
            Walkable = p_walkable;
            WorldPos = p_worldPos;

            Radius = p_radius;
            
            XId = (int)p_gridPosition.x;
            YId = (int)p_gridPosition.y;
        }
    }
}
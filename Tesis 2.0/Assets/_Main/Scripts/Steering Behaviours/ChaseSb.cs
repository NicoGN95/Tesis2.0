using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours
{
    public class ChaseSb : ISteeringBehaviour
    {
        private Transform m_origin;
        private Transform m_target;

        public ChaseSb(Transform p_origin, Transform p_target)
        {
            m_origin = p_origin;
            m_target = p_target;
        }

        public Vector3 GetDir()
        {
            return (m_target.position - m_origin.position).normalized;
        }

    }
}
﻿//
// Script name: TrackVehicule
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace Track
{
    public class TrackVehicle : MonoBehaviour
    {
        #region Variables
        [SerializeField] protected TrackPiece m_CurrentTrack;
        [SerializeField] protected float m_Gravity = 1f;
        [SerializeField, ReadOnly] protected Vector3 m_LastPosition = Vector3.zero;

        public bool IsInAir
        {
            get { return m_CurrentTrack == null; }
        }
        #endregion

        #region Unity API
        protected virtual void Update()
        {
            if (m_CurrentTrack == null)
            {
                transform.position += Vector3.down * m_Gravity * Time.deltaTime;
            }
            else
            {
                m_LastPosition = transform.position;
                m_LastPosition.y = m_CurrentTrack.GetHeightOnTrack(m_LastPosition.x);
                transform.position = m_LastPosition;
            }
        }
        #endregion

        #region Public Methods
        public void SetTrackPiece(TrackPiece track)
        {
            m_CurrentTrack = track;
        }

        public void MoveForward(float velocity)
        {
            Move(velocity);
        }

        public void MoveBackward(float velocity)
        {
            Move(-velocity);
        }
        #endregion

        #region Protected Methods
        protected virtual void Move(float velocity)
        {
            if (m_CurrentTrack != null)
            {
                transform.position += m_CurrentTrack.Right * velocity;
                m_CurrentTrack = m_CurrentTrack.GetNextTrackPiece(transform);
            }
            else
            {
                transform.position += Vector3.right * velocity * Time.deltaTime;
            }
        }
        #endregion

        #region Private Methods
        #endregion

    }
}
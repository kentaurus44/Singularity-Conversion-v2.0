﻿// File: Projectile
// Created by: Rigil Malubay

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Projectile : Subject {
	
	// const
	public const string SELF_DESTRUCT = "SelfDestruct";

	// enum
	public enum ePorjectileType
	{
		Blackhole,
		Bullet
	}

	// public
	public ePorjectileType m_Type;

	// protected
	[SerializeField]
	protected float m_Damage;
	protected Vector3 m_TargetPosition = Vector3.zero;
	protected Vector3 m_InitialPosition = Vector3.zero;
	protected Vector3 m_PathVector = Vector3.zero;

	// private

	// properties
	public Vector3 TargetPosition 
	{
		set 
		{
			m_TargetPosition = value;
		}
	}
	#region Unity API
	protected virtual void Update()
	{
		Travel();
	}
	protected virtual void OnDestroy()
	{

	}
	#endregion

	#region Public Methods
	public virtual void Shoot()
	{
		m_PathVector = m_TargetPosition - transform.position;
	}
	#endregion

	#region Protected Methods
	protected virtual void Travel()
	{
		transform.Translate(m_PathVector * Time.deltaTime);
	}
	protected virtual void SelfDestruct()
	{
		NotifyObervers(SELF_DESTRUCT);
		Destroy(gameObject);
	}
	#endregion

	#region Private Methods
	#endregion
}
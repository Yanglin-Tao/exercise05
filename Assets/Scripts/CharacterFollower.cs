using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterFollower : MonoBehaviour
{
	public Transform _followingObject;
	NavMeshAgent _followingAgent;
	CharacterRenderer _charRenderer;

	void Start()
	{
		_followingAgent = _followingObject.GetComponent<NavMeshAgent>();
		_charRenderer = GetComponent<CharacterRenderer>();
	}

	void Update()
	{
		transform.position = _followingObject.transform.position;

		if (_followingAgent.velocity.x < 0)
		{
			_charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Left);
			_charRenderer.SetAction(CharacterRenderer.Action.Moving);
		}
		if (_followingAgent.velocity.x > 0)
		{
			_charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Right);
			_charRenderer.SetAction(CharacterRenderer.Action.Moving);
		}
		if (_followingAgent.velocity.magnitude == 0)
		{
			_charRenderer.SetAction(CharacterRenderer.Action.Standing);
		}
	}
}

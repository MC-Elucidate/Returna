﻿[System.Serializable]
public class InteractState : AState<PlayerStateManager>
{
	public override void AnimatorUpdate()
	{
	}

	public override IState CheckTransition()
	{
		if (!stateManager.interactionInterface.Interacting)
		{
			return stateManager.states.FreeMovement;
		}
		return this;
	}

	public override void EnterState()
	{
	}

	public override void ExitState()
	{
	}

	public override void StateUpdate()
	{
	}
}

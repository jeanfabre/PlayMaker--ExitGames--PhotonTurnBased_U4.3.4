// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;
using System;
using System.Collections.Generic;
using ExitGames.Client.Photon.LoadBalancing;

using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Call the TurnBased Cloud Server to join a random, available room." +
	         "If all rooms are closed or full, the OperationResponse will have a returnCode of ErrorCode.NoRandomMatchFound." +
	         "If successful, the OperationResponse contains a gameserver address and the name of some room. " +
	         "This is an async request which will triggers 'PHOTON TURNBASED / XXX' events ")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1107")]
	public class PhotonTurnBasedJoinRandomRoom: FsmStateAction
	{

		[ObjectType(typeof(MatchmakingMode))]
		public FsmEnum matchMakingMode;
		
		[Tooltip("Max number of players that can be in the room at any time. 0 means 'no limit'.")]
		public FsmInt maxNumberOfPLayers;
	
		[ActionSection("Expected Properties")]
		
		[CompoundArray("Count", "Key", "Value")]
		[Tooltip("The expected Property to set")]
		public FsmString[] expectedPropertyKey;
		[RequiredField]
		[Tooltip("Value of the property")]
		public FsmVar[] expectedPropertyValue;

		
		[ActionSection("Result")]
		[UIHint(UIHint.Variable)]
		[Tooltip("True If the operation could be sent (has to be connected).")]
		public FsmBool operationSent;
		
		[Tooltip("Event fired If the operation could NOT be sent (has to be connected).")]
		public FsmEvent operationFailedEvent;
		
		public override void Reset()
		{

			matchMakingMode = null;
			maxNumberOfPLayers = null;

			expectedPropertyKey = null;
			expectedPropertyValue = null;

			
			operationSent = null;
			operationFailedEvent = null;
		}
		
		public override void OnEnter()
		{

			ExitGames.Client.Photon.Hashtable _expectedProps = new ExitGames.Client.Photon.Hashtable();
			
			int i = 0;
			foreach(FsmString _prop in expectedPropertyKey)
			{
				_expectedProps[_prop.Value] =  PlayMakerUtils.GetValueFromFsmVar(this.Fsm,expectedPropertyValue[i]);
				i++;
			}

			byte _maxNumberOfPLayers = (byte)maxNumberOfPLayers.Value;

			MatchmakingMode _mod = (MatchmakingMode)Enum.ToObject(typeof(MatchmakingMode),matchMakingMode.Value);

			Debug.Log(_mod);

			bool _couldBeSent = PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.OpJoinRandomRoom(_expectedProps,_maxNumberOfPLayers,_mod);
			operationSent.Value = _couldBeSent;
			if (_couldBeSent)
			{
				Fsm.Event(operationFailedEvent);
			}
			
			Finish();
			
		}
		
	}
}
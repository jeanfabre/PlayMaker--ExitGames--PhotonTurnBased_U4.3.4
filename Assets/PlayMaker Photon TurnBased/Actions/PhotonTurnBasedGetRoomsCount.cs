// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;
using System;
using System.Collections.Generic;

using HutongGames.PlayMaker.Photon.TurnBased;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Statistic value available on master server: Rooms count (Currently created).")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1107")]
	public class PhotonTurnBasedGetRoomsCount : FsmStateAction
	{
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt roomsCount;
		
		public bool everyFrame;
		
		public override void Reset()
		{
			roomsCount = null;
			everyFrame = true;
		}
		
		public override void OnEnter()
		{
			getProperty();
			
			if (!everyFrame)
			{
				Finish();
			}
		}	
		
		public override void OnUpdate()
		{
			getProperty();
		}	
		
		void getProperty()
		{
			roomsCount.Value =	PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.RoomsCount;
			
		}	
	}
}
﻿// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;
using System;
using System.Collections.Generic;
namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Statistic value available on master server: Players on Master (Looking for Games).")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1107")]
	public class PhotonTurnBasedGetPlayersOnMasterCount : FsmStateAction
	{
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt playersOnMasterCount;
		
		public bool everyFrame;
		
		public override void Reset()
		{
			playersOnMasterCount = null;
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
			playersOnMasterCount.Value = PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.PlayersOnMasterCount;
			
		}	
	}
}
// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;
using System;
using System.Collections.Generic;

using ExitGames.Client.Photon.LoadBalancing;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Call the TurnBased Cloud Server webhook 'GetGameList' to return the current list of saved games. This is an asynchronous operation.")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1107")]
	public class PhotonTurnBasedCallGetGamesList : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		[ArrayEditorAttribute(VariableType.String)]
		public FsmArray gameList;

		[RequiredField]
		public FsmEvent gameListAvailable;
		
		public override void Reset()
		{
			gameListAvailable = null;
		}

		public override void OnEnter()
		{

			PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.OpWebRpc("GetGameList", new Dictionary<string, object>());

			PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.OnGameListReceivedAction += OnGameListReceived;
		}

		public override void OnExit()
		{
			if (PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance!=null)
			{
				PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.OnGameListReceivedAction -= OnGameListReceived;
			}

		}

		void OnGameListReceived ()
		{
			Debug.Log("OnGameListReceived");

			if (!gameList.IsNone)
			{
				gameList.Reset();

				Dictionary<string, int> _list = PlayMakerPhotonLoadBalancingClientProxy.instance.LbcInstance.SavedGames;

				gameList.Resize(_list.Count);

				string[] _keys = new string[_list.Count];

				int i = 0;
				foreach(KeyValuePair<string, int> _item in _list)
				{
					_keys[i] = _item.Key;
					 
					//int savedActorNumber = _item["ActorNr"];

					i++;
				}

				gameList.stringValues = _keys;
			}



			Fsm.Event(gameListAvailable);
			Finish();
		}
		
	}
}
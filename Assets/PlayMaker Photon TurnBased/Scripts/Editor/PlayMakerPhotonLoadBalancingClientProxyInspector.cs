using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayMakerPhotonLoadBalancingClientProxy))]
public class PlayMakerPhotonLoadBalancingClientProxyInspector : Editor {

	PlayMakerPhotonLoadBalancingClientProxy _target;


	//GUILayoutOption[] GUILayoutOption_null =null;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		/*
		if(_target==null)
		{
			_target = (PlayMakerPhotonLoadBalancingClientProxy)target;
		}

		//"59b9d56e-198e-4ce3-bcbd-14d2df422b74"

		_target.appId = EditorGUILayout.TextField("appId",_target.appId);
		_target.appVersion = EditorGUILayout.TextField("appVersion",_target.appVersion);
		EditorGUILayout.LabelField("state",_target.state,GUILayoutOption_null);
*/
	}
}

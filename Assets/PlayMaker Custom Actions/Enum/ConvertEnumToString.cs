// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.
// __ECO__ __ACTION__ __BETA__ //

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Convert)]
	[Tooltip("Converts an Enum value to a String value.")]
	public class ConvertEnumToString : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The Enum variable to convert.")]
		public FsmEnum enumVariable;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("A String variable to store the converted value.")]
		public FsmString stringVariable;

		[Tooltip("Optional Format, allows for leading zeroes. E.g., 0000")]
		public FsmString format;

		[Tooltip("Repeat every frame. Useful if the Enum variable is changing.")]
		public bool everyFrame;
		
		public override void Reset()
		{
			enumVariable = null;
			stringVariable = null;
			everyFrame = false;
			format = null;
		}
		
		public override void OnEnter()
		{
			DoConvertEnumToString();
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoConvertEnumToString();
		}
		
		void DoConvertEnumToString()
		{
			if (format.IsNone || string.IsNullOrEmpty(format.Value))
			{
				stringVariable.Value = enumVariable.Value.ToString();
			}
			else
			{
				stringVariable.Value = enumVariable.Value.ToString(format.Value);
			}
				

		}
	}
}
using System;
using System.Collections;

public static class PlayMakerUtils_Extensions
{
	
	#region ArrayList
	  /// <summary>
        /// Merges keys of type string to target Hashtable.
        /// </summary>
	public static int LastIndexOf(ArrayList target,Object value) {
         return PlayMakerUtils_Extensions.LastIndexOf(target,value,target.Count - 1, target.Count);
    }

    public static int LastIndexOf(ArrayList target,Object value, int startIndex) {
        return PlayMakerUtils_Extensions.LastIndexOf(target,value, startIndex, startIndex + 1);
    }
	
	public static int LastIndexOf(ArrayList target,Object value,int startIndex, int count) {
		
		ArrayList _list = target;

        if (_list.Count == 0)
                    return -1;
		
		if (startIndex < 0 || startIndex >= _list.Count) throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_Index");
        if (count < 0 || count > startIndex + 1) throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_Count");

        int endIndex = startIndex - count + 1;
        if (value == null) {
            for(int i=startIndex; i >= endIndex; i--)
                if (_list[i] == null)
                    return i;
            return -1;
        } else {
            for(int i=startIndex; i >= endIndex; i--)
                if (_list[i] != null && _list[i].Equals(value))
                    return i;
            return -1;
        }
	}
	
	#endregion
	
}


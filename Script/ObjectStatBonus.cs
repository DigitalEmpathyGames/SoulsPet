using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectStatBonus{
	public string stat;
	public int bonus;

	public ObjectStatBonus(){
	}

	public void setStat(string nuevoStat){
		stat = nuevoStat;
	}

	public string getStat (){
		return stat;
	}

	public void setBonus(int nuevoBonus){
		bonus = nuevoBonus;
	}

	public int getBonus(){
		return bonus;
	}

	public Dictionary<string, object> ToDictionary() {
		Dictionary<string, object> result = new Dictionary<string, object>();
		result["stat"] = stat;
		result["bonus"] = bonus;
		return result;
	}

}

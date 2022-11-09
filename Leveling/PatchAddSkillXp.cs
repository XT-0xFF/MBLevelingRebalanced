﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace AdjustableLeveling.Leveling;

[HarmonyPatch(typeof(HeroDeveloper), "AddSkillXp")]
internal static class PatchAddSkillXp
{
	public static void Prefix(HeroDeveloper __instance, SkillObject skill, ref float rawXp)
	{
		rawXp *= AdjustableLeveling.Settings.SkillXPMultiplier * skill.SkillToModifier();

		if (__instance?.Hero?.CharacterObject.IsPlayerCharacter == false)
			rawXp *= AdjustableLeveling.Settings.NPCSkillXPMultiplier * skill.NPCSkillToModifier();
	}
}

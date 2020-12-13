using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DBZMOD;
using System;

namespace kiweaponsaddons.Items
{
    public class ButtKicker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("ProZD would be proud");
            DisplayName.SetDefault("battle outfit");
        }
        
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 140000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 39;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                MyPlayer.ModPlayer(player).kiDamage += 1.33f;
                MyPlayer.ModPlayer(player).kiCrit += 15;
                MyPlayer.ModPlayer(player).kiMax2 += 3500;
                player.endurance += 0.17f;
                player.meleeDamage += 0.16f;
                player.meleeSpeed += 0.16f;
                player.meleeCrit += 14;
                player.magicDamage += 0.16f;
                player.magicCrit += 14;
                player.rangedDamage += 0.16f;
                player.rangedCrit += 14;
                player.lifeRegen += 18;
                player.minionDamage += 0.014f;
                player.maxMinions += 4;
                player.thorns = 0.3f;
                player.detectCreature = true;
                MyPlayer.ModPlayer(player).kiChargeRate += 7;
                MyPlayer.ModPlayer(player).kiRegen += 15;
                MyPlayer.ModPlayer(player).flightSpeedAdd += 0.1f;
                MyPlayer.ModPlayer(player).flightUsageAdd += 2;
                MyPlayer.ModPlayer(player).chargeLimitAdd += 1;
                MyPlayer.ModPlayer(player).kiDrainMulti -= 0.66f;
                MyPlayer.ModPlayer(player).kiKbAddition += 0.14f;
                MyPlayer.ModPlayer(player).kiSpeedAddition += -.15f;
                MyPlayer.ModPlayer(player).kaiokenDrainMulti -= 0.5f;
                MyPlayer.ModPlayer(player).spiritCharm = true;
                MyPlayer.ModPlayer(player).infuserRainbow = true;
                MyPlayer.ModPlayer(player).buldariumSigmite = true;
                MyPlayer.ModPlayer(player).crystalliteAlleviate = true;
                MyPlayer.ModPlayer(player).radiantTotem = true;
                MyPlayer.ModPlayer(player).pureEnergyCirclet = true;
                MyPlayer.ModPlayer(player).luminousSectum = true;
                MyPlayer.ModPlayer(player).goblinKiEnhancer = true;
                MyPlayer.ModPlayer(player).earthenArcanium = true;
                MyPlayer.ModPlayer(player).majinNucleus = true;
                MyPlayer.ModPlayer(player).metamoranSash = true;
                MyPlayer.ModPlayer(player).timeRing = true;
                MyPlayer.ModPlayer(player).senzuBag = true;
                MyPlayer.ModPlayer(player).bloodstainedBandana = true;
                MyPlayer.ModPlayer(player).blackDiamondShell = true;
                MyPlayer.ModPlayer(player).battleKit = true;
                MyPlayer.ModPlayer(player).legendNecklace = true;
                MyPlayer.ModPlayer(player).legendWaistcape = true;
                MyPlayer.ModPlayer(player).zenkaiCharm = true;
                MyPlayer.ModPlayer(player).kaioCrystal = true;
                MyPlayer.ModPlayer(player).chargeMoveSpeed = Math.Max(MyPlayer.ModPlayer(player).chargeMoveSpeed, 1.5f);
            }
        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);


            if (DBZMod != null)
            { 
                recipe.AddIngredient(mod.GetItem("DnaGod"), 1 );
                recipe.AddIngredient(DBZMod.GetItem("TimeRing"), 1);
                recipe.AddIngredient(DBZMod.GetItem("SenzuBag"), 1);
                recipe.AddIngredient(DBZMod.GetItem("BloodstainedBandana"), 1);
                recipe.AddIngredient(DBZMod.GetItem("BlackDiamondShell"), 1);
                recipe.AddIngredient(DBZMod.GetItem("BattleKit"), 1);
                recipe.AddIngredient(DBZMod.GetItem("AncientLegendWaistCape"), 1);
                recipe.AddIngredient(DBZMod.GetItem("AncientLegendNecklace"), 1);
                recipe.AddIngredient(DBZMod.GetItem("KaioCrystal"), 1);
                recipe.AddIngredient(DBZMod.GetItem("ZenkaiCharm"), 1);
                recipe.AddTile(DBZMod.TileType("ZTable"));
        }
            else
            {
                recipe.AddIngredient(ItemID.DirtBlock, 1);
            }
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
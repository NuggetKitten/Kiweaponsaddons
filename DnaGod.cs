using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DBZMOD;
using System;

namespace kiweaponsaddons.Items
{
    public class DnaGod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("He is speaking the language of gods.");
            DisplayName.SetDefault("Gods DNA");
        }
        
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 140000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 22;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                MyPlayer.ModPlayer(player).kiDamage += 0.77f;
                MyPlayer.ModPlayer(player).kiCrit += 15;
                MyPlayer.ModPlayer(player).kiMax2 += 4050;
                player.endurance += 0.17f;
                player.meleeDamage += 0.16f;
                player.meleeSpeed += 0.16f;
                player.meleeCrit += 14;
                player.magicDamage += 0.16f;
                player.magicCrit += 14;
                player.rangedDamage += 0.16f;
                player.rangedCrit += 14;
                player.lifeRegen += 14;
                player.minionDamage += 0.014f;
                player.maxMinions += 4;
                MyPlayer.ModPlayer(player).kiChargeRate += 6;
                MyPlayer.ModPlayer(player).kiRegen += 12;
                MyPlayer.ModPlayer(player).flightSpeedAdd += 0.1f;
                MyPlayer.ModPlayer(player).flightUsageAdd += 2;
                MyPlayer.ModPlayer(player).chargeLimitAdd += 1;
                MyPlayer.ModPlayer(player).kiDrainMulti -= 3;
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
                MyPlayer.ModPlayer(player).chargeMoveSpeed = Math.Max(MyPlayer.ModPlayer(player).chargeMoveSpeed, 1.5f);
            }
        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);


            if (DBZMod != null)
            { 
                recipe.AddIngredient(mod.GetItem("DragonSigil"), 1 );
                recipe.AddIngredient(DBZMod.GetItem("MetamoranSash"), 1);
                recipe.AddIngredient(DBZMod.GetItem("GreenPotara"), 1);
                recipe.AddIngredient(DBZMod.GetItem("MajinNucleus"), 1);
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
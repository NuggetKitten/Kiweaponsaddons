using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DBZMOD;

namespace kiweaponsaddons.Items
{
    public class DragonCharmNeck : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'An emblem enscribed with markings of the dragon.'\n22% Increased Ki Damage\nAll damage increased by 16%\n+750 Maximum ki\n14% reduced damage\n+4 max minions\nGreatly increased life regen\nAll crit increased by 14%. \nEffect of rainbow infuser.");
            DisplayName.SetDefault("Dragon Charm Necklace");
        }
        
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 140000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 6;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                MyPlayer.ModPlayer(player).kiDamage += 0.22f;
                MyPlayer.ModPlayer(player).kiCrit += 14;
                MyPlayer.ModPlayer(player).kiMax2 += 750;
                player.endurance += 0.14f;
                player.meleeDamage += 0.16f;
                player.meleeSpeed += 0.16f;
                player.meleeCrit += 14;
                player.magicDamage += 0.16f;
                player.magicCrit += 14;
                player.rangedDamage += 0.16f;
                player.rangedCrit += 14;
                player.lifeRegen += 5;
                player.minionDamage += 0.014f;
                player.maxMinions += 4;
                MyPlayer.ModPlayer(player).spiritCharm = true;
                MyPlayer.ModPlayer(player).infuserRainbow = true;
            }
        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);


            if (DBZMod != null)
            { 
                recipe.AddIngredient(DBZMod.GetItem("InfuserRainbow"), 1);
            recipe.AddIngredient(DBZMod.GetItem("SpiritCharm"), 1);
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
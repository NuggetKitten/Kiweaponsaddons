using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DBZMOD;

namespace kiweaponsaddons.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class RadiantGreavesPlus : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("18% Increased Ki Damage"
                + "\n24% Increased Ki Crit Chance" +
                               "\n+1000 Max Ki" +
                               "\nIncreased Ki Regen" +
                               "\n28% Increased movement speed");
            DisplayName.SetDefault("Radiant Greaves+");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;
            item.value = 34000;
            item.rare = 10;
            item.defense = 22;
        }
        public override void UpdateEquip(Player player)
        {
            MyPlayer.ModPlayer(player).KiDamage += 0.18f;
            MyPlayer.ModPlayer(player).kiCrit += 24;
            MyPlayer.ModPlayer(player).kiMax2 += 1000;
            MyPlayer.ModPlayer(player).kiRegen += 4;
            player.moveSpeed += 0.28f;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);

            if (DBZMod != null)
            {
                recipe.AddIngredient(ItemID.LunarBar, 22);
                recipe.AddIngredient(DBZMod.GetItem("RadiantFragment"), 15);
                recipe.AddIngredient(DBZMod.GetItem("RadiantGreaves"), 1);
            }
            else
            {
                recipe.AddIngredient(ItemID.DirtBlock, 1);
            }
            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
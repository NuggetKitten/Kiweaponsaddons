using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DBZMOD;

namespace kiweaponsaddons.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class RadiantVisorPlus : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("22% Increased Ki Damage"
                + "\n26% Increased Ki crit" +
                               "\n+1000 Max Ki" +
                               "\nIncreased flight speed");
            DisplayName.SetDefault("Radiant Visor+");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;
            item.value = 52000;
            item.rare = 10;
            item.defense = 26;
        }

        public override void UpdateEquip(Player player)
        {
            MyPlayer.ModPlayer(player).KiDamage += 0.22f;
            MyPlayer.ModPlayer(player).kiCrit += 16;
            MyPlayer.ModPlayer(player).kiMax2 += 1000;
            MyPlayer.ModPlayer(player).flightSpeedAdd += 0.5f;

        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            drawAltHair = false;
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
                recipe.AddIngredient(DBZMod.GetItem("RadiantVisor"), 1);
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
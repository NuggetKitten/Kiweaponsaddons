using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DBZMOD;

namespace kiweaponsaddons.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class RadiantScalepiecePlus : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("28% Increased Ki Damage"
                + "\n18% Increased Ki knockback" +
                               "\n+1750 Max Ki" +
                               "\n+5 Maximum Charges" +
                               "\nReduced flight ki usage");
            DisplayName.SetDefault("Radiant Scalepiece+");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;
            item.value = 68000;
            item.rare = 10;
            item.defense = 42;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("RadiantVisorPlus") && legs.type == mod.ItemType("RadiantGreavesPlus");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Hitting enemies heals a random amount of ki and fires off homing projectiles at nearby enemies." +
                "\nIncreased Ki Regen and +250 Max Life";
            player.statLifeMax2 += 250;
            MyPlayer.ModPlayer(player).radiantBonus = true;
            MyPlayer.ModPlayer(player).kiRegen += 4;
            MyPlayer.ModPlayer(player).KiDamage += 0.28f;
        }
        public override void UpdateEquip(Player player)
        {
            MyPlayer.ModPlayer(player).KiDamage += 0.08f;
            MyPlayer.ModPlayer(player).kiKbAddition += 18;
            MyPlayer.ModPlayer(player).kiMax2 += 1750;
            MyPlayer.ModPlayer(player).chargeLimitAdd += 5;
            MyPlayer.ModPlayer(player).flightUsageAdd += 2;

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
                recipe.AddIngredient(DBZMod.GetItem("RadiantGreaves"));
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
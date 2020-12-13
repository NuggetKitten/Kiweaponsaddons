
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DBZMOD;
using kiweaponsaddons.Buffs;
using Terraria.Utilities;

namespace kiweaponsaddons.Items
{

    public class kisward : KiItem
    {

        public override void UpdateInventory(Player player)
        {
            if (MyPlayer.ModPlayer(player).IsKiDepleted())
            {
                player.channel = false;
            }
            else
            {
  
                if (player.channel)
                {
                    player.AddBuff(item.buffType, 2);
                }
            }

        }
        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            return true;
        }

        public override void SetDefaults()
        {
            item.shoot = ModContent.ProjectileType<Projectiles.ExampleLaser>();
            item.channel = true;
            item.shootSpeed = 2f;
            item.damage = 258;
            item.knockBack = 2f;
            item.useStyle = 5;
            item.UseSound = SoundID.Item12;
            item.useAnimation = 100;
            item.useTime = 10;
            item.width = 5;
            item.noUseGraphic = true;
            item.height = 5;
            item.autoReuse = true;
            item.value = 10500;
            item.rare = 3;
            kiDrain = 80;
            item.buffType = ModContent.BuffType<Buffs.kidbuff>();

           
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
           
            position = Main.MouseWorld;
            return true;

        }
        
        public float dkidrain = 0.8f;
        public override int ChoosePrefix(Terraria.Utilities.UnifiedRandom rand)
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            var prefixChooser = new WeightedRandom<int>();
            prefixChooser.Add(DBZMod.PrefixType("BalancedPrefix"), 3); // 3 times as likely
            prefixChooser.Add(DBZMod.PrefixType("CondensedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("MystifyingPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("UnstablePrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("FlawedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("BoostedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("NegatedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("OutrageousPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("PoweredPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("FlashyPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("InfusedPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("DistractingPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("DestructivePrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("MasteredPrefix"), 1);
            prefixChooser.Add(DBZMod.PrefixType("TranscendedPrefix"), 1);
            int choice = prefixChooser;
            if ((item.damage > 0) && item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Better than it looks");
            DisplayName.SetDefault("Spirit Sword");



        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);
            if (DBZMod != null)
            {
                recipe.AddTile(DBZMod.TileType("ZTable"));
                recipe.AddIngredient(DBZMod.GetItem("StableKiCrystal"), 100);
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
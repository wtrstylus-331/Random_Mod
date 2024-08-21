using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace rand_mod.Items.Weapons
{
    public class NTW20 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 104;
            Item.height = 32;
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = 30000;

            Item.useAnimation = 70;
            Item.useTime = 70;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.ArmorPenetration = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 235;
            Item.knockBack = 60f;
            Item.crit = 50;
            Item.noMelee = true;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20f;
            Item.useAmmo = ModContent.ItemType<Ammo.NTWAmmo>();

            Item.UseSound = new SoundStyle($"{nameof(rand_mod)}/Assets/Sounds/Items/NTW20")
            {
                Volume = 0.55f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, 0f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);

            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddIngredient(ItemID.SniperRifle, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 45f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
    }
}

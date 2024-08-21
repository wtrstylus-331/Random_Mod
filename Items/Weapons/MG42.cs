using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace rand_mod.Items.Weapons
{
    public class MG42 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 88;
            Item.height = 32;
            Item.scale = 0.9f;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = 15000;

            Item.useAnimation = 4;
            Item.useTime = 4;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.ArmorPenetration = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 70;
            Item.knockBack = 2f;
            Item.crit = 30;
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 17f;
            Item.useAmmo = ModContent.ItemType<Ammo.MG42Ammo>();

            Item.UseSound = new SoundStyle($"{nameof(rand_mod)}/Assets/Sounds/Items/MG42")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 0f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);

            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 1);
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

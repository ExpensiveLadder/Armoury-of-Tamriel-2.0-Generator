using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

namespace ArmouryofTamriel2Generator
{
    public class Material
    {
        public string Name;
        public string ID;
        public FormKey Ingot;
        public FormKey Keyword;
        public ConditionFloat? PerkRequirement;

        public Material(string name, FormKey ingot, FormKey keyword)
        {
            Name = name;
            ID = name;
            Ingot = ingot;
            Keyword = keyword;
        }

        public Material(string name, FormKey ingot, FormKey keyword, FormKey smithingPerk)
        {
            Name = name;
            Ingot = ingot;
            Keyword = keyword;
            ID = name;

            PerkRequirement = new ConditionFloat()
            {
                CompareOperator = CompareOperator.EqualTo,
                ComparisonValue = 1,
                Data = new FunctionConditionData()
                {
                    Function = Condition.Function.HasPerk,
                    ParameterOneRecord = new FormLink<IPerkGetter>(smithingPerk)
                }
            };
        }
        public Material(string name, FormKey ingot, FormKey keyword, FormKey smithingPerk, string id)
        {
            Name = name;
            Ingot = ingot;
            Keyword = keyword;
            ID = id;
            PerkRequirement = new ConditionFloat() { CompareOperator = CompareOperator.EqualTo, ComparisonValue = 1, Data = new FunctionConditionData() { Function = Condition.Function.HasPerk, ParameterOneRecord = new FormLink<IPerkGetter>(smithingPerk) } };
        }

        //                                               Name                    Ingot                                 Keyword                         Required Smithing Perk
        public static readonly Material IronWeapon = new("Iron", FormKey.Factory("05ACE4:Skyrim.esm"), FormKey.Factory("01E718:Skyrim.esm"));
        public static readonly Material SteelWeapon = new("Steel", FormKey.Factory("05ACE5:Skyrim.esm"), FormKey.Factory("01E719:Skyrim.esm"), FormKey.Factory("0CB40D:Skyrim.esm"));
        public static readonly Material DwarvenWeapon = new("Dwarven", FormKey.Factory("0DB8A2:Skyrim.esm"), FormKey.Factory("01E71A:Skyrim.esm"), FormKey.Factory("0CB40E:Skyrim.esm"));
        public static readonly Material MoonstoneWeapon = new("Moonstone", FormKey.Factory("05AD9F:Skyrim.esm"), FormKey.Factory("01E71B:Skyrim.esm"), FormKey.Factory("0CB40f:Skyrim.esm"));
        public static readonly Material OrichalcumWeapon = new("Orichalcum", FormKey.Factory("05AD99:Skyrim.esm"), FormKey.Factory("01E71C:Skyrim.esm"), FormKey.Factory("0CB410:Skyrim.esm"));
        public static readonly Material GlassWeapon = new("Glass", FormKey.Factory("05ADA1:Skyrim.esm"), FormKey.Factory("01E71D:Skyrim.esm"), FormKey.Factory("0CB411:Skyrim.esm"));
        public static readonly Material EbonyWeapon = new("Ebony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("01E71E:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm"));
        public static readonly Material DaedricWeapon = new("Daedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("01E71F:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"));
        public static readonly Material QuickSilverWeapon = new("Silver", FormKey.Factory("05ADA0:Skyrim.esm"), FormKey.Factory("0C5C00:Skyrim.esm"), FormKey.Factory("014A21:Armoury of Tamriel.esm"));

        public static readonly Material IronArmor = new("Iron", FormKey.Factory("05ACE4:Skyrim.esm"), FormKey.Factory("06BBE3:Skyrim.esm"));
        public static readonly Material SteelArmor = new("Steel", FormKey.Factory("05ACE5:Skyrim.esm"), FormKey.Factory("06BBE6:Skyrim.esm"), FormKey.Factory("0CB40D:Skyrim.esm"));
        public static readonly Material DwarvenArmor = new("Dwarven", FormKey.Factory("0DB8A2:Skyrim.esm"), FormKey.Factory("06BBD7:Skyrim.esm"), FormKey.Factory("0CB40E:Skyrim.esm"));
        public static readonly Material MoonstoneArmor = new("Moonstone", FormKey.Factory("05AD9F:Skyrim.esm"), FormKey.Factory("06BBD9:Skyrim.esm"), FormKey.Factory("0CB40f:Skyrim.esm"));
        public static readonly Material OrichalcumArmor = new("Orichalcum", FormKey.Factory("05AD99:Skyrim.esm"), FormKey.Factory("06BBE5:Skyrim.esm"), FormKey.Factory("0CB410:Skyrim.esm"));
        public static readonly Material GlassArmor = new("Glass", FormKey.Factory("05ADA1:Skyrim.esm"), FormKey.Factory("06BBDC:Skyrim.esm"), FormKey.Factory("0CB411:Skyrim.esm"));
        public static readonly Material EbonyArmor = new("Ebony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD8:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm"));
        public static readonly Material DaedricArmor = new("Daedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD4:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"));
        public static readonly Material QuickSilverArmor = new("Silver", FormKey.Factory("05ADA0:Skyrim.esm"), FormKey.Factory("06BBE2:Skyrim.esm"), FormKey.Factory("014A21:Armoury of Tamriel.esm"));

        public static readonly Material ALTEbonyArmor = new("Ebony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD8:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm"), "ALTEbony"); 
        public static readonly Material ALTDaedricArmor = new("Daedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD4:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"), "ALTDaedric");
    }

    public class Style
    {
        public string Name;
        public ConditionFloat? PerkRequirement;

        public Style(string name)
        {
            Name = name;
        }

        public Style(string name, FormKey smithingPerk)
        {
            Name = name;

            PerkRequirement = new ConditionFloat()
            {
                CompareOperator = CompareOperator.EqualTo,
                ComparisonValue = 1,
                Data = new FunctionConditionData()
                {
                    Function = Condition.Function.HasPerk,
                    ParameterOneRecord = new FormLink<IPerkGetter>(smithingPerk)
                }
            };
        }

        public static readonly Style BasicStyle = new("Basic");
        public static readonly Style AkaviriStyle = new("Akaviri", FormKey.Factory("019047:Armoury of Tamriel.esm"));
        public static readonly Style BretonStyle = new("Breton", FormKey.Factory("019048:Armoury of Tamriel.esm"));
        public static readonly Style DremoraStyle = new("Dremora", FormKey.Factory("019049:Armoury of Tamriel.esm"));
        public static readonly Style DunmerStyle = new("Dunmer", FormKey.Factory("01904A:Armoury of Tamriel.esm"));
        public static readonly Style DwemerStyle = new("Dwemer", FormKey.Factory("01904B:Armoury of Tamriel.esm"));
        public static readonly Style NordStyle = new("Nordic", FormKey.Factory("01904C:Armoury of Tamriel.esm"));
        public static readonly Style SkaalStyle = new("Skaal", FormKey.Factory("02C34C:Armoury of Tamriel.esm"));
        public static readonly Style ImperialStyle = new("Imperial", FormKey.Factory("01904D:Armoury of Tamriel.esm"));
        public static readonly Style AltmerStyle = new("Altmeri", FormKey.Factory("01904E:Armoury of Tamriel.esm"));
        public static readonly Style OrnateStyle = new("Ornate", FormKey.Factory("01904F:Armoury of Tamriel.esm"));
        public static readonly Style RedguardStyle = new("Redguard", FormKey.Factory("019050:Armoury of Tamriel.esm"));
        public static readonly Style OrcishStyle = new("Orcish", FormKey.Factory("019051:Armoury of Tamriel.esm"));
        public static readonly Style AncientStyle = new("Ancient", FormKey.Factory("019054:Armoury of Tamriel.esm"));
        public static readonly Style DawnguardStyle = new("Dawnguard", FormKey.Factory("02C34A:Armoury of Tamriel.esm"));
        public static readonly Style ThalmorStyle = new("Thalmor", FormKey.Factory("02C369:Armoury of Tamriel.esm"));

        public static readonly Style HideStyle = new("Hide");
        public static readonly Style LeatherStyle = new("Leather", FormKey.Factory("02B6EA:Armoury of Tamriel.esm"));
        public static readonly Style ScaleStyle = new("Scale", FormKey.Factory("02B6E8:Armoury of Tamriel.esm"));
        public static readonly Style CompanionsStyle = new("Companions", FormKey.Factory("02B6EB:Armoury of Tamriel.esm"));
        public static readonly Style VampireStyle = new("Vampire", FormKey.Factory("02C34B:Armoury of Tamriel.esm"));
        public static readonly Style StormcloakStyle = new("Stormcloak", FormKey.Factory("02B6E9:Armoury of Tamriel.esm"));
    }

    public class RuneInfo
    {
        public FormLink<MiscItem>? Rune { get; set; }
        public FormLink<Perk>? BootsPerk { get; set; }
        public FormLink<Perk>? HelmetPerk { get; set; }
        public FormLink<Perk>? GauntletsPerk { get; set; }
        public FormLink<Spell>? CuirassSpell { get; set; }
        public FormLink<Spell>? CuirassEffect { get; set; }
        public FormLink<Spell>? WeaponSpell { get; set; }
        public FormLinkNullable<ObjectEffect>? WeaponEnchant { get; set; }
        public FormLinkNullable<ObjectEffect>? BowEnchant { get; set; }
        public FormLink<Spell>? BowSpell { get; set; }
        public string BootsDescription { get; set; }
        public string GauntletsDescription { get; set; }
        public string CuirassDescription { get; set; }
        public string HelmetDescription { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RuneInfo() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static readonly RuneInfo Fire1 = new()
        {
            Rune = FormKey.Factory("0012D4:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all flame resistance effects by 20%.",
            CuirassDescription = "Summons a cloak of flames.",
            HelmetDescription = "Increases damage from Flame Breath and reduces shout cooldown by 10%.",
            GauntletsDescription = "Increases damage from fire spells and enchantments by 10%.",
            BootsPerk = FormKey.Factory("02C874:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C862:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C86B:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C89B:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C85C:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C87D:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8BB:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("00142C:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C892:Armoury of Tamriel.esm"),
            ID = "MagFlame",
            Name = "Ancient Flame"
        };
        public static readonly RuneInfo Fire2 = new()
        {
            Rune = FormKey.Factory("02C6DE:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all flame resistance effects by 30%.",
            CuirassDescription = "Summons a cloak of flames.",
            HelmetDescription = "Increases damage from Flame Breath and reduces shout cooldown by 15%.",
            GauntletsDescription = "Increases damage from fire spells and enchantments by 15%.",
            BootsPerk = FormKey.Factory("02C875:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C863:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C86C:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C859:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C89C:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C87E:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8BC:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("00142D:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C893:Armoury of Tamriel.esm"),
            ID = "MagFlame",
            Name = "Ancient Flame"
        };
        public static readonly RuneInfo Fire3 = new()
        {
            Rune = FormKey.Factory("02C6DF:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all flame resistance effects by 40%.",
            CuirassDescription = "Summons a cloak of flames.",
            HelmetDescription = "Increases damage from Flame Breath and reduces shout cooldown by 20%.",
            GauntletsDescription = "Increases damage from fire spells and enchantments by 20%.",
            BootsPerk = FormKey.Factory("02C876:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C864:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C86D:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C89E:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C89D:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C87F:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8BD:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("00142E:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C894:Armoury of Tamriel.esm"),
            ID = "MagFlame",
            Name = "Ancient Flame"
        };
        public static readonly RuneInfo Frost1 = new()
        {
            Rune = FormKey.Factory("0012F7:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all frost resistance effects by 20%.",
            CuirassDescription = "Summons a cloak of frost.",
            HelmetDescription = "Increases damage from Frost Breath and reduces shout cooldown by 10%.",
            GauntletsDescription = "Increases damage from frost spells and enchantments by 10%.",
            BootsPerk = FormKey.Factory("02C877:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C865:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C86E:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C85A:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C85D:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C882:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8BE:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("001432:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C895:Armoury of Tamriel.esm"),
            ID = "MagFrost",
            Name = "Ancient Shard"
        };
        public static readonly RuneInfo Frost2 = new()
        {
            Rune = FormKey.Factory("02C6E0:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all frost resistance effects by 30%.",
            CuirassDescription = "Summons a cloak of frost.",
            HelmetDescription = "Increases damage from Frost Breath and reduces shout cooldown by 15%.",
            GauntletsDescription = "Increases damage from frost spells and enchantments by 15%.",
            BootsPerk = FormKey.Factory("02C878:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C866:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C86F:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C8A0:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C89F:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C881:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8BF:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("001433:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C896:Armoury of Tamriel.esm"),
            ID = "MagFrost",
            Name = "Ancient Shard"
        };
        public static readonly RuneInfo Frost3 = new()
        {
            Rune = FormKey.Factory("02C6E1:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all frost resistance effects by 40%.",
            CuirassDescription = "Summons a cloak of frost.",
            HelmetDescription = "Increases damage from Frost Breath and reduces shout cooldown by 20%.",
            GauntletsDescription = "Increases damage from frost spells and enchantments by 20%.",
            BootsPerk = FormKey.Factory("02C879:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C867:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C870:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C8A2:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C8A1:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C880:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8C0:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("001434:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C897:Armoury of Tamriel.esm"),
            ID = "MagFrost",
            Name = "Ancient Shard"
        };
        public static readonly RuneInfo Shock1 = new()
        {
            Rune = FormKey.Factory("0012F8:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all shock resistance effects by 20%.",
            CuirassDescription = "Summons a cloak of lightning.",
            HelmetDescription = "Increases the duration of Storm Call and reduces shout cooldown by 10%.",
            GauntletsDescription = "Increases damage from shock spells and enchantments by 10%.",
            BootsPerk = FormKey.Factory("02C87A:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C868:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C871:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C85B:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C85E:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C883:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8C1:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("001438:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C898:Armoury of Tamriel.esm"),
            ID = "MagShock",
            Name = "Ancient Storm"
        };
        public static readonly RuneInfo Shock2 = new()
        {
            Rune = FormKey.Factory("02C6E2:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all shock resistance effects by 30%.",
            CuirassDescription = "Summons a cloak of lightning.",
            HelmetDescription = "Increases the duration of Storm Call and reduces shout cooldown by 15%.",
            GauntletsDescription = "Increases damage from shock spells and enchantments by 15%.",
            BootsPerk = FormKey.Factory("02C87B:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C869:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C872:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C8A4:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C8A3:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C884:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8C2:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("001439:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C899:Armoury of Tamriel.esm"),
            ID = "MagShock",
            Name = "Ancient Storm"
        };
        public static readonly RuneInfo Shock3 = new()
        {
            Rune = FormKey.Factory("02C6E3:Armoury of Tamriel.esm"),
            BootsDescription = "Enhances all shock resistance effects by 40%.",
            CuirassDescription = "Summons a cloak of lightning.",
            HelmetDescription = "Increases the duration of Storm Call and reduces shout cooldown by 20%.",
            GauntletsDescription = "Increases damage from shock spells and enchantments by 20%.",
            BootsPerk = FormKey.Factory("02C87C:Armoury of Tamriel.esm"),
            HelmetPerk = FormKey.Factory("02C86A:Armoury of Tamriel.esm"),
            GauntletsPerk = FormKey.Factory("02C873:Armoury of Tamriel.esm"),
            CuirassSpell = FormKey.Factory("02C8A6:Armoury of Tamriel.esm"),
            CuirassEffect = FormKey.Factory("02C8A5:Armoury of Tamriel.esm"),
            WeaponSpell = FormKey.Factory("02C885:Armoury of Tamriel.esm"),
            BowSpell = FormKey.Factory("02C8C3:Armoury of Tamriel.esm"),
            WeaponEnchant = FormKey.Factory("00143A:Armoury of Tamriel.esm"),
            BowEnchant = FormKey.Factory("02C89A:Armoury of Tamriel.esm"),
            ID = "MagShock",
            Name = "Ancient Storm"
        };

        public static readonly List<RuneInfo> runes1 = new()
        {
            Fire1,
            Frost1,
            Shock1
        };

        public static readonly List<RuneInfo> runes2 = new()
        {
            Fire2,
            Frost2,
            Shock2
        };
        public static readonly List<RuneInfo> runes3 = new()
        {
            Fire3,
            Frost3,
            Shock3
        };
    }


    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "YourPatcher.esp")
                .Run(args);
        }

        public static readonly ConditionFloat isEnchanted = new()
        {
            CompareOperator = CompareOperator.NotEqualTo,
            Flags = Condition.Flag.OR,
            ComparisonValue = 1,
            Data = new FunctionConditionData()
            {
                Function = Condition.Function.EPTemperingItemIsEnchanted
            }
        };

        public static readonly ConditionFloat hasArcaneBlacksmith = new()
        {
            CompareOperator = CompareOperator.EqualTo,
            ComparisonValue = 1,
            Data = new FunctionConditionData()
            {
                Function = Condition.Function.HasPerk,
                ParameterOneRecord = new FormLink<IPerkGetter>(FormKey.Factory("05218E:Skyrim.esm"))
            }
        };

        public static readonly Noggog.ExtendedList<Condition> temperConditions = new()
        {
            isEnchanted,
            hasArcaneBlacksmith
        };

        public static readonly IFormLinkNullable<IKeywordGetter> forge = new FormLinkNullable<IKeywordGetter>(FormKey.Factory("088105:Skyrim.esm"));
        public static readonly IFormLinkNullable<IKeywordGetter> sharpeningWheel = new FormLinkNullable<IKeywordGetter>(FormKey.Factory("088108:Skyrim.esm"));
        public static readonly IFormLinkNullable<IKeywordGetter> armorTable = new FormLinkNullable<IKeywordGetter>(FormKey.Factory("0ADB78:Skyrim.esm"));
        public static readonly IFormLinkNullable<Keyword> armorSwap = new FormLinkNullable<Keyword>(FormKey.Factory("02C1BB:Armoury of Tamriel.esm"));
        public static readonly IFormLinkNullable<Keyword> craftingMagKey = new FormLinkNullable<Keyword>(FormKey.Factory("02C6E4:Armoury of Tamriel.esm"));
        public static readonly IFormLinkNullable<ObjectEffect> BlockEnchantment = new FormLinkNullable<ObjectEffect>(FormKey.Factory("02C8A8:Armoury of Tamriel.esm"));

        public static readonly FormLink<Keyword> ArmorHeavy = new(FormKey.Factory("06BBD2:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorLight = new(FormKey.Factory("06BBD3:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorBoots = new(FormKey.Factory("06C0ED:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorHelmet = new(FormKey.Factory("06C0EE:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorGauntlets = new(FormKey.Factory("06C0EF:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorCuirass = new(FormKey.Factory("06C0EC:Skyrim.esm"));
        public static readonly FormLink<Keyword> WeapTypeBow = new(FormKey.Factory("01E715:Skyrim.esm"));
        public static readonly FormLink<Keyword> MagicDisallowEnchanting = new(FormKey.Factory("0C27BD:Skyrim.esm"));

        public static Noggog.ExtendedList<AlternateTexture> SetTextureSets(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, Noggog.ExtendedList<AlternateTexture> texturelist, string oldMaterialID, string newMaterialID)
        {
            Noggog.ExtendedList<AlternateTexture> temptexturelist = new();
            foreach (var texture in texturelist)
            {
                var texturegetter = texture.NewTexture.Resolve(state.LinkCache);
                if (texturegetter.EditorID == null) throw new Exception("null textureset editorid");
                var newtextureeditorid = texturegetter.EditorID.Replace(oldMaterialID, newMaterialID);
                if (state.LinkCache.TryResolve<ITextureSetGetter>(newtextureeditorid, out var newtexturegetter))
                {
                    Console.WriteLine("setting textureset: " + newtextureeditorid);
                    temptexturelist.Add(new AlternateTexture()
                    {
                        Index = texture.Index,
                        Name = texture.Name,
                        NewTexture = newtexturegetter.AsLink()
                    });
                }
                else
                {
                    throw new Exception("ERROR: Could not find textureset: " + newtextureeditorid);
                }
            }

            return temptexturelist;
        }

        public static void CreateWeapon(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IWeaponGetter weapon, Material oldMaterial, Material newMaterial, Style style, List<RuneInfo>? runeInfos, bool silver = false)
        {
            // Item
            var neweapon = state.PatchMod.Weapons.DuplicateInAsNewRecord(weapon);

            if (weapon.EditorID == null) throw new Exception("null editorid");
            if (weapon.Name == null) throw new Exception("null name");
            var oldname = weapon.Name.ToString();
            if (oldname == null) throw new Exception("null name");

            var editorID = weapon.EditorID.Replace(oldMaterial.ID, newMaterial.ID);
            Console.WriteLine("generating weapon: " + editorID);

            neweapon.EditorID = editorID;
            neweapon.Name = oldname.Replace(oldMaterial.Name, newMaterial.Name);

            if (neweapon.Keywords == null)
            {
                neweapon.Keywords = new();
            } else if (oldMaterial.Keyword != null)
            {
                if (neweapon.Keywords.Contains(oldMaterial.Keyword))
                {
                    neweapon.Keywords.Remove(oldMaterial.Keyword);
                }
            }
            if (newMaterial.Keyword != null)
            {
                neweapon.Keywords.Add(newMaterial.Keyword);
            }

            // Silver
            if (silver) AddSilverWeaponPerk(neweapon);

            // Texture Sets
            if (neweapon.Model?.AlternateTextures != null)
            {
                neweapon.Model.AlternateTextures = SetTextureSets(state, neweapon.Model.AlternateTextures, oldMaterial.ID, newMaterial.ID);
            }

            // First Person Model

            var oldweaponmodel = weapon.FirstPersonModel.Resolve(state.LinkCache);
            if (oldweaponmodel == null) throw new Exception();

            var neweaponmodel = state.PatchMod.Statics.DuplicateInAsNewRecord(oldweaponmodel);
            neweapon.FirstPersonModel = new FormLinkNullable<IStaticGetter>(neweaponmodel);

            neweaponmodel.EditorID = editorID.Replace("400", "4001stPerson");

            if (neweaponmodel.Model?.AlternateTextures != null)
            {
                neweaponmodel.Model.AlternateTextures = SetTextureSets(state, neweaponmodel.Model.AlternateTextures, oldMaterial.ID, newMaterial.ID);
            }

            state.PatchMod.Statics.Set(neweaponmodel);
            state.PatchMod.Weapons.Set(neweapon);

            // Recipe
            var recipeConditions = new Noggog.ExtendedList<Condition>();
            if (newMaterial.PerkRequirement != null)
            {
                recipeConditions.Add(newMaterial.PerkRequirement);
            }
            if (style.PerkRequirement != null)
            {
                recipeConditions.Add(style.PerkRequirement);
            }

            var newRecipe = new ConstructibleObject(state.PatchMod)
            {
                EditorID = editorID.Replace("400", "400Recipe"),
                CreatedObjectCount = 1,
                CreatedObject = new FormLinkNullable<IConstructibleGetter>(neweapon.FormKey),
                Conditions = recipeConditions,
                WorkbenchKeyword = forge
            };

            state.PatchMod.ConstructibleObjects.Set(newRecipe);

            // Temper
            CreateTemperRecipe(state, neweapon, newMaterial);

            // Runed
            if (runeInfos != null)
            {
                foreach (var runeInfo in runeInfos)
                {
                    CreateRunedWeapon(state, neweapon, newMaterial, runeInfo);
                }
            }
        }

        public static void CreateArmor(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material oldMaterial, Material newMaterial, Style? style = null, bool CSWAP = false, List<RuneInfo>? runeInfos = null)
        {
            if (style == null) style = Style.BasicStyle;
            // Item
            var newarmor = state.PatchMod.Armors.DuplicateInAsNewRecord(armor);

            if (armor.EditorID == null) throw new Exception("null editorid");
            if (armor.Name == null) throw new Exception("null name");
            var oldname = armor.Name.ToString();
            if (oldname == null) throw new Exception("null name");

            var editorID = armor.EditorID.Replace(oldMaterial.ID, newMaterial.ID);
            Console.WriteLine("generating armor: " + editorID);

            newarmor.EditorID = editorID;
            newarmor.Name = oldname.Replace(oldMaterial.Name, newMaterial.Name);

            if (newarmor.Keywords == null)
            {
                newarmor.Keywords = new();
            }
            else if (oldMaterial.Keyword != null)
            {
                if (newarmor.Keywords.Contains(oldMaterial.Keyword))
                {
                    newarmor.Keywords.Remove(oldMaterial.Keyword);
                }
            }
            if (newMaterial.Keyword != null)
            {
                newarmor.Keywords.Add(newMaterial.Keyword);
            }

            // Texture Sets
            if (newarmor.WorldModel?.Female?.Model?.AlternateTextures != null)
            {
                newarmor.WorldModel.Female.Model.AlternateTextures = SetTextureSets(state, newarmor.WorldModel.Female.Model.AlternateTextures, oldMaterial.ID, newMaterial.ID);
            }
            if (newarmor.WorldModel?.Male?.Model?.AlternateTextures != null)
            {
                newarmor.WorldModel.Male.Model.AlternateTextures = SetTextureSets(state, newarmor.WorldModel.Male.Model.AlternateTextures, oldMaterial.ID, newMaterial.ID);
            }

            // Armor Addons

            var newarmature = new Noggog.ExtendedList<IFormLinkGetter<IArmorAddonGetter>>();
            foreach (var armoraddongetter in newarmor.Armature)
            {
                var armoraddon = armoraddongetter.Resolve(state.LinkCache);
                var newarmoraddon = state.PatchMod.ArmorAddons.DuplicateInAsNewRecord(armoraddon);
                if (armoraddon.EditorID == null) throw new Exception("armoraddon: " + armoraddongetter + " has a null editorid");
                newarmoraddon.EditorID = armoraddon.EditorID.Replace(oldMaterial.ID, newMaterial.ID);

                // Armor Addon Texture Sets
                if (newarmoraddon.WorldModel?.Female?.AlternateTextures != null)
                {
                    newarmoraddon.WorldModel.Female.AlternateTextures = SetTextureSets(state, newarmoraddon.WorldModel.Female.AlternateTextures, oldMaterial.ID, newMaterial.ID);
                }
                if (newarmoraddon.WorldModel?.Male?.AlternateTextures != null)
                {
                    newarmoraddon.WorldModel.Male.AlternateTextures = SetTextureSets(state, newarmoraddon.WorldModel.Male.AlternateTextures, oldMaterial.ID, newMaterial.ID);
                }
                if (newarmoraddon.FirstPersonModel?.Female?.AlternateTextures != null)
                {
                    newarmoraddon.FirstPersonModel.Female.AlternateTextures = SetTextureSets(state, newarmoraddon.FirstPersonModel.Female.AlternateTextures, oldMaterial.ID, newMaterial.ID);
                }
                if (newarmoraddon.FirstPersonModel?.Male?.AlternateTextures != null)
                {
                    newarmoraddon.FirstPersonModel.Male.AlternateTextures = SetTextureSets(state, newarmoraddon.FirstPersonModel.Male.AlternateTextures, oldMaterial.ID, newMaterial.ID);
                }

                state.PatchMod.ArmorAddons.Set(newarmoraddon);
                newarmature.Add(newarmoraddon);
            }
            newarmor.Armature.Clear();
            foreach(var armoraddon in newarmature)
            {
                newarmor.Armature.Add(armoraddon);
            }

            state.PatchMod.Armors.Set(newarmor);

            // Recipe
            var recipeConditions = new Noggog.ExtendedList<Condition>();
            if (newMaterial.PerkRequirement != null)
            {
                recipeConditions.Add(newMaterial.PerkRequirement);
            }
            if (style.PerkRequirement != null)
            {
                recipeConditions.Add(style.PerkRequirement);
            }

            var newRecipe = new ConstructibleObject(state.PatchMod)
            {
                EditorID = editorID.Replace("400", "400Recipe"),
                CreatedObjectCount = 1,
                CreatedObject = new FormLinkNullable<IConstructibleGetter>(newarmor.FormKey),
                Conditions = recipeConditions,
                WorkbenchKeyword = forge
            };

            state.PatchMod.ConstructibleObjects.Set(newRecipe);

            // Temper
            CreateTemperRecipe(state, newarmor, newMaterial);

            // CSWAP
            if (CSWAP)
            {
                CreateCSWAPLight(state, newarmor, newMaterial);
            }
            // Runed
            if (runeInfos != null)
            {
                foreach (var runeInfo in runeInfos)
                {
                    var runedArmor = CreateRunedArmor(state, newarmor, newMaterial, runeInfo);
                    if (CSWAP)
                    {
                        CreateRunedItemRecipes(state, newarmor, CreateCSWAPLight(state, runedArmor, newMaterial), runeInfo);
                    }
                }
            }
        }

        public static Armor CreateCSWAPHeavy(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material material)
        {
            // Armor
            var CSWAParmor = armor.Duplicate(state.PatchMod.GetNextFormKey());
            if (armor.EditorID == null) throw new Exception();
            CSWAParmor.EditorID = armor.EditorID.Replace("400ArmorCSWAP", "400Armor");
            Console.WriteLine("generating CSWAP: " + CSWAParmor.EditorID);

            if (CSWAParmor.BodyTemplate == null || CSWAParmor.Keywords == null) throw new Exception();
            CSWAParmor.BodyTemplate.ArmorType = ArmorType.HeavyArmor;
            if (!armor.MajorFlags.HasFlag(Armor.MajorFlag.Shield))
            {
                CSWAParmor.Keywords.Remove(ArmorLight);
                CSWAParmor.Keywords.Add(ArmorHeavy);
            }

            state.PatchMod.Armors.Set(CSWAParmor);

            // Temper
            CreateTemperRecipe(state, CSWAParmor, material);

            // Convert Light to Heavy
            var convertHeavy = new ConstructibleObject(state.PatchMod)
            {
                EditorID =  CSWAParmor.EditorID.Replace("400", "400RecipeCSWAPLighttoHeavy"),
                CreatedObjectCount = 1,
                CreatedObject = CSWAParmor.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = armor.AsNullableLink(),
                            Count = 1
                        }
                    }
                },
                Conditions = new Noggog.ExtendedList<Condition>
                {
                    new ConditionFloat
                    {
                        CompareOperator = CompareOperator.GreaterThan,
                        ComparisonValue = 0,
                        Data = new FunctionConditionData()
                        {
                            RunOnType = Condition.RunOnType.Subject,
                            Function = Condition.Function.GetItemCount,
                            ParameterOneRecord = armor.AsNullableLink()
                        }
                    },
                },
                WorkbenchKeyword = armorSwap
            };
            state.PatchMod.ConstructibleObjects.Set(convertHeavy);

            // Convert Heavy to Light
            var convertLight = new ConstructibleObject(state.PatchMod)
            {
                EditorID = CSWAParmor.EditorID.Replace("400", "400RecipeCSWAPHeavytoLight"),
                CreatedObjectCount = 1,
                CreatedObject = armor.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = CSWAParmor.AsNullableLink(),
                            Count = 1
                        }
                    }
                },
                Conditions = new Noggog.ExtendedList<Condition>
                {
                    new ConditionFloat
                    {
                        CompareOperator = CompareOperator.GreaterThan,
                        ComparisonValue = 0,
                        Data = new FunctionConditionData()
                        {
                            RunOnType = Condition.RunOnType.Subject,
                            Function = Condition.Function.GetItemCount,
                            ParameterOneRecord = CSWAParmor.AsNullableLink()
                        }
                    },
                },
                WorkbenchKeyword = armorSwap
            };
            state.PatchMod.ConstructibleObjects.Set(convertLight);

            return CSWAParmor;
        }

        public static Armor CreateCSWAPLight(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material material)
        {
            // Armor
            var CSWAParmor = armor.Duplicate(state.PatchMod.GetNextFormKey());
            if (armor.EditorID == null) throw new Exception();
            CSWAParmor.EditorID = armor.EditorID.Replace("400Armor", "400ArmorCSWAP");
            Console.WriteLine("generating CSWAP: " + CSWAParmor.EditorID);

            if (CSWAParmor.BodyTemplate == null || CSWAParmor.Keywords == null) throw new Exception();
            CSWAParmor.BodyTemplate.ArmorType = ArmorType.LightArmor;
            if (!armor.MajorFlags.HasFlag(Armor.MajorFlag.Shield))
            {
                CSWAParmor.Keywords.Remove(ArmorHeavy);
                CSWAParmor.Keywords.Add(ArmorLight);
            }

            state.PatchMod.Armors.Set(CSWAParmor);

            // Temper
            CreateTemperRecipe(state, CSWAParmor, material);

            // Convert Light to Heavy
            var convertHeavy = new ConstructibleObject(state.PatchMod)
            {
                EditorID = armor.EditorID.Replace("400", "400RecipeCSWAPLighttoHeavy"),
                CreatedObjectCount = 1,
                CreatedObject = armor.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = CSWAParmor.AsNullableLink(),
                            Count = 1
                        }
                    }
                },
                Conditions = new Noggog.ExtendedList<Condition>
                {
                    new ConditionFloat
                    {
                        CompareOperator = CompareOperator.GreaterThan,
                        ComparisonValue = 0,
                        Data = new FunctionConditionData()
                        {
                            RunOnType = Condition.RunOnType.Subject,
                            Function = Condition.Function.GetItemCount,
                            ParameterOneRecord = CSWAParmor.AsNullableLink()
                        }
                    },
                },
                WorkbenchKeyword = armorSwap
            };
            state.PatchMod.ConstructibleObjects.Set(convertHeavy);

            // Convert Heavy to Light
            var convertLight = new ConstructibleObject(state.PatchMod)
            {
                EditorID = armor.EditorID.Replace("400", "400RecipeCSWAPHeavytoLight"),
                CreatedObjectCount = 1,
                CreatedObject = CSWAParmor.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = armor.AsNullableLink(),
                            Count = 1
                        }
                    }
                },
                Conditions = new Noggog.ExtendedList<Condition>
                {
                    new ConditionFloat
                    {
                        CompareOperator = CompareOperator.GreaterThan,
                        ComparisonValue = 0,
                        Data = new FunctionConditionData()
                        {
                            RunOnType = Condition.RunOnType.Subject,
                            Function = Condition.Function.GetItemCount,
                            ParameterOneRecord = armor.AsNullableLink()
                        }
                    },
                },
                WorkbenchKeyword = armorSwap
            };
            state.PatchMod.ConstructibleObjects.Set(convertLight);

            return CSWAParmor;
        }

        public static List<IArmorGetter> CreateRunedArmor(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material material, List<RuneInfo> runeInfos)
        {
            List<IArmorGetter> armors = new();
            foreach (var runeInfo in runeInfos)
            {
                armors.Add(CreateRunedArmor(state, armor, material, runeInfo));
            }
            return armors;
        }

        public static Armor CreateRunedArmor(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material material, RuneInfo runeInfo)
        {
            // Armor
            var runedarmor = armor.Duplicate(state.PatchMod.GetNextFormKey());
            if (runedarmor.EditorID == null || runedarmor.Keywords == null || runedarmor.Name?.String == null) throw new Exception();
            runedarmor.EditorID += runeInfo.ID;
            Console.WriteLine("generating Runed Armor: " + runedarmor.EditorID);
            runedarmor.Name = runedarmor.Name.String.Replace("Ancient", runeInfo.Name);

            // Armor Texture Sets
            if (runedarmor.WorldModel?.Female?.Model?.AlternateTextures != null)
            {
                runedarmor.WorldModel.Female.Model.AlternateTextures = SetTextureSets(state, runedarmor.WorldModel.Female.Model.AlternateTextures, "300", "300" + runeInfo.ID);
            }
            if (runedarmor.WorldModel?.Male?.Model?.AlternateTextures != null)
            {
                runedarmor.WorldModel.Male.Model.AlternateTextures = SetTextureSets(state, runedarmor.WorldModel.Male.Model.AlternateTextures, "300", "300" + runeInfo.ID);
            }

            // Armor Addons
            var newarmature = new Noggog.ExtendedList<IFormLinkGetter<IArmorAddonGetter>>();
            foreach (var armoraddongetter in runedarmor.Armature)
            {
                var armoraddon = armoraddongetter.Resolve(state.LinkCache);
                var newarmoraddon = state.PatchMod.ArmorAddons.DuplicateInAsNewRecord(armoraddon);
                if (armoraddon.EditorID == null) throw new Exception("armoraddon: " + armoraddongetter + " has a null editorid");
                newarmoraddon.EditorID = armoraddon.EditorID.Replace("400", "400" + runeInfo.ID);

                // Armor Addon Texture Sets
                if (newarmoraddon.WorldModel?.Female?.AlternateTextures != null)
                {
                    newarmoraddon.WorldModel.Female.AlternateTextures = SetTextureSets(state, newarmoraddon.WorldModel.Female.AlternateTextures, "300", "300" + runeInfo.ID);
                }
                if (newarmoraddon.WorldModel?.Male?.AlternateTextures != null)
                {
                    newarmoraddon.WorldModel.Male.AlternateTextures = SetTextureSets(state, newarmoraddon.WorldModel.Male.AlternateTextures, "300", "300" + runeInfo.ID);
                }
                if (newarmoraddon.FirstPersonModel?.Female?.AlternateTextures != null)
                {
                    newarmoraddon.FirstPersonModel.Female.AlternateTextures = SetTextureSets(state, newarmoraddon.FirstPersonModel.Female.AlternateTextures, "300", "300" + runeInfo.ID);
                }
                if (newarmoraddon.FirstPersonModel?.Male?.AlternateTextures != null)
                {
                    newarmoraddon.FirstPersonModel.Male.AlternateTextures = SetTextureSets(state, newarmoraddon.FirstPersonModel.Male.AlternateTextures, "300", "300" + runeInfo.ID);
                }

                state.PatchMod.ArmorAddons.Set(newarmoraddon);
                newarmature.Add(newarmoraddon);
            }
            runedarmor.Armature.Clear();
            foreach (var armoraddon in newarmature)
            {
                runedarmor.Armature.Add(armoraddon);
            }

            // Effects
            runedarmor.Keywords.Add(MagicDisallowEnchanting);
            runedarmor.ObjectEffect = BlockEnchantment;
            if (runedarmor.VirtualMachineAdapter == null) runedarmor.VirtualMachineAdapter = new();
#pragma warning disable CS8601 // Possible null reference assignment.
            if (runedarmor.Keywords.Contains(ArmorBoots))
            {
                runedarmor.Description = runeInfo.BootsDescription;
                runedarmor.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTArmorPerk",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "ArmorPerk",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.BootsPerk
                        }
                    }
                });
            }
            else if (runedarmor.Keywords.Contains(ArmorGauntlets))
            {
                runedarmor.Description = runeInfo.GauntletsDescription;
                runedarmor.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTArmorPerk",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "ArmorPerk",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.GauntletsPerk
                        }
                    }
                });
            }
            else if (runedarmor.Keywords.Contains(ArmorHelmet))
            {
                runedarmor.Description = runeInfo.HelmetDescription;
                runedarmor.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTArmorPerk",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "ArmorPerk",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.HelmetPerk
                        }
                    }
                });
            }
            else if (runedarmor.Keywords.Contains(ArmorCuirass))
            {
                runedarmor.Description = runeInfo.CuirassDescription;
                runedarmor.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTArmorSpell",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "ArmorSpell",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.CuirassSpell
                        },
                        new ScriptObjectProperty
                        {
                            Name = "effectSpell",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.CuirassEffect
                        }
                    }
                });
            }
#pragma warning restore CS8601 // Possible null reference assignment.
            state.PatchMod.Armors.Set(runedarmor);

            // Recipes
            CreateTemperRecipe(state, runedarmor, material);
            CreateRunedItemRecipes(state, armor, runedarmor, runeInfo);

            return runedarmor;
        }

        public static Weapon CreateRunedWeapon(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IWeaponGetter weapon, Material material, RuneInfo runeInfo)
        {
            // Armor
            var runedweapon = weapon.Duplicate(state.PatchMod.GetNextFormKey());
            if (runedweapon.EditorID == null || runedweapon.Keywords == null || runedweapon.Name?.String == null) throw new Exception();
            runedweapon.EditorID += runeInfo.ID;
            Console.WriteLine("generating Runed Weapon: " + runedweapon.EditorID);
            runedweapon.Name = runedweapon.Name.String.Replace("Ancient", runeInfo.Name);

            // Texture Sets
            if (runedweapon.Model?.AlternateTextures != null)
            {
                runedweapon.Model.AlternateTextures = SetTextureSets(state, runedweapon.Model.AlternateTextures, "300", "300" + runeInfo.ID);
            }

            // First Person Model
            var oldweaponmodel = weapon.FirstPersonModel.Resolve(state.LinkCache);
            if (oldweaponmodel == null) throw new Exception();
            var neweaponmodel = state.PatchMod.Statics.DuplicateInAsNewRecord(oldweaponmodel);
            runedweapon.FirstPersonModel = new FormLinkNullable<IStaticGetter>(neweaponmodel);
            neweaponmodel.EditorID = runedweapon.EditorID.Replace("400", "4001stPerson");
            if (neweaponmodel.Model?.AlternateTextures != null)
            {
                neweaponmodel.Model.AlternateTextures = SetTextureSets(state, neweaponmodel.Model.AlternateTextures, "300", "300" + runeInfo.ID);
            }
            state.PatchMod.Statics.Set(neweaponmodel);
            state.PatchMod.Weapons.Set(runedweapon);

            // Effects
            runedweapon.Keywords.Add(MagicDisallowEnchanting);
            runedweapon.EnchantmentAmount = 10;
            if (runedweapon.VirtualMachineAdapter == null) runedweapon.VirtualMachineAdapter = new();
            if (runedweapon.Keywords.Contains(WeapTypeBow))
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                runedweapon.ObjectEffect = runeInfo.BowEnchant;
                runedweapon.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTWeaponSpell",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "WeaponSpell",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.BowSpell
                        }
                    }
                });
            }
            else
            {
                runedweapon.ObjectEffect = runeInfo.WeaponEnchant;
                runedweapon.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
                {
                    Name = "AoTWeaponSpell",
                    Flags = ScriptEntry.Flag.Local,
                    Properties = new Noggog.ExtendedList<ScriptProperty>()
                    {
                        new ScriptObjectProperty
                        {
                            Name = "WeaponSpell",
                            Flags = ScriptProperty.Flag.Edited,
                            Object = runeInfo.WeaponSpell
#pragma warning restore CS8601 // Possible null reference assignment.
                        }
                    }
                });
            }
            state.PatchMod.Weapons.Set(runedweapon);

            // Recipes
            CreateTemperRecipe(state, runedweapon, material);
            CreateRunedItemRecipes(state, weapon, runedweapon, runeInfo);

            return runedweapon;
        }

        public static ConstructibleObject CreateTemperRecipe(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IWeaponGetter item, Material material)
        {
            var temperrecipe = new ConstructibleObject(state.PatchMod)
            {
                EditorID = item.EditorID?.Replace("400", "400Temper"),
                CreatedObjectCount = 1,
                CreatedObject = item.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = new FormLink<IItemGetter>(material.Ingot),
                            Count = 1
                        }
                    }
                },
                Conditions = temperConditions,
                WorkbenchKeyword = sharpeningWheel
            };
            state.PatchMod.ConstructibleObjects.Set(temperrecipe);
            return temperrecipe;
        }

        public static ConstructibleObject CreateTemperRecipe(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter item, Material material)
        {
            var temperrecipe = new ConstructibleObject(state.PatchMod)
            {
                EditorID = item.EditorID?.Replace("400", "400Temper"),
                CreatedObjectCount = 1,
                CreatedObject = item.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = new FormLink<IItemGetter>(material.Ingot),
                            Count = 1
                        }
                    }
                },
                Conditions = temperConditions,
                WorkbenchKeyword = armorTable
            };
            state.PatchMod.ConstructibleObjects.Set(temperrecipe);
            return temperrecipe;
        }

        public static List<IWeaponGetter> CreateRunedWeapon(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IWeaponGetter weapon, Material material, List<RuneInfo> runeInfos)
        {
            List<IWeaponGetter> weapons = new();
            foreach (var runeInfo in runeInfos)
            {
                weapons.Add(CreateRunedWeapon(state, weapon, material, runeInfo));
            }
            return weapons;
        }

        public static void CreateRunedItemRecipes(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IConstructibleGetter baseitem, IConstructibleGetter runeditem, RuneInfo runeInfo)
        {
            // Recipe
            var recipe = new ConstructibleObject(state.PatchMod)
            {
                EditorID = runeditem.EditorID?.Replace("400", "400RecipeRune"),
                CreatedObjectCount = 1,
                CreatedObject = (IFormLinkNullable<IConstructibleGetter>)runeditem.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = baseitem.AsNullableLink(),
                            Count = 1
                        }
                    },
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
#pragma warning disable CS8601 // Possible null reference assignment.
                            Item = runeInfo.Rune,
#pragma warning restore CS8601 // Possible null reference assignment.
                            Count = 1
                        }
                    }
                },
                WorkbenchKeyword = craftingMagKey
            };
            state.PatchMod.ConstructibleObjects.Set(recipe);

            // Disenchant
            var disenchant = new ConstructibleObject(state.PatchMod)
            {
                EditorID = runeditem.EditorID?.Replace("400", "400RecipeUnrune"),
                CreatedObjectCount = 1,
#pragma warning disable CS8604 // Possible null reference argument.
                CreatedObject = runeInfo.Rune.AsNullable(),
#pragma warning restore CS8604 // Possible null reference argument.
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = (IFormLink<IItemGetter>)runeditem.AsNullableLink(),
                            Count = 1
                        }
                    }
                },
                Conditions = new Noggog.ExtendedList<Condition>
                {
                    new ConditionFloat
                    {
                        CompareOperator = CompareOperator.GreaterThan,
                        ComparisonValue = 0,
                        Data = new FunctionConditionData()
                        {
                            RunOnType = Condition.RunOnType.Subject,
                            Function = Condition.Function.GetItemCount,
                            ParameterOneRecord = (IFormLink<ISkyrimMajorRecordGetter>)runeditem.AsNullableLink()
                        }
                    },
                },
                WorkbenchKeyword = craftingMagKey
            };
            state.PatchMod.ConstructibleObjects.Set(disenchant);
        }

        public static Weapon AddSilverWeaponPerk(Weapon weapon)
        {
            if (weapon.VirtualMachineAdapter == null) weapon.VirtualMachineAdapter = new();
            weapon.VirtualMachineAdapter.Scripts.Add(new ScriptEntry
            {
                Name = "SilverSwordScript",
                Flags = ScriptEntry.Flag.Local,
                Properties = new Noggog.ExtendedList<ScriptProperty>()
                {
                    new ScriptObjectProperty
                    {
                        Name = "SilverPerk",
                        Flags = ScriptProperty.Flag.Edited,
                        Object = new FormLink<Perk>(FormKey.Factory("10D685:Skyrim.esm"))
                    }
                }
            });
            return weapon;
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            //Your code here!

            foreach (var weaponidk in state.LoadOrder.PriorityOrder.Weapon().WinningContextOverrides())
            {
                var weapon = weaponidk.Record;

                if (weapon.EditorID == null) continue;
                if (weapon.EditorID.Contains("400"))
                {
                    bool generateRunedWeapons = false;
                    Style style;
                    if (weapon.EditorID.Contains("Altmer"))
                    {
                        style = Style.AltmerStyle;
                    }
                    else if (weapon.EditorID.Contains("Akaviri"))
                    {
                        style = Style.AkaviriStyle;
                    }
                    else if (weapon.EditorID.Contains("Ancient"))
                    {
                        style = Style.AncientStyle;
                        generateRunedWeapons = true;
                    }
                    else if (weapon.EditorID.Contains("Breton"))
                    {
                        style = Style.BretonStyle;
                    }
                    else if (weapon.EditorID.Contains("Companions"))
                    {
                        style = Style.CompanionsStyle;
                    }
                    else if (weapon.EditorID.Contains("Dawnguard"))
                    {
                        style = Style.DawnguardStyle;
                    }
                    else if (weapon.EditorID.Contains("Dremora"))
                    {
                        style = Style.DremoraStyle;
                    }
                    else if (weapon.EditorID.Contains("Dunmer"))
                    {
                        style = Style.DunmerStyle;
                    }
                    else if (weapon.EditorID.Contains("Dwemer"))
                    {
                        style = Style.DwemerStyle;
                    }
                    else if (weapon.EditorID.Contains("Hide"))
                    {
                        style = Style.HideStyle;
                    }
                    else if (weapon.EditorID.Contains("Imperial"))
                    {
                        style = Style.ImperialStyle;
                    }
                    else if (weapon.EditorID.Contains("Nordic"))
                    {
                        style = Style.NordStyle;
                    }
                    else if (weapon.EditorID.Contains("Orcish"))
                    {
                        style = Style.OrcishStyle;
                    }
                    else if (weapon.EditorID.Contains("Redguard"))
                    {
                        style = Style.RedguardStyle;
                    }
                    else if (weapon.EditorID.Contains("Skaal"))
                    {
                        style = Style.SkaalStyle;
                    }
                    else if (weapon.EditorID.Contains("Ornate"))
                    {
                        style = Style.OrnateStyle;
                    }
                    else
                    {
                        Console.WriteLine("Could not find Style for Weapon:" + weapon.EditorID);
                        style = Style.BasicStyle;
                    }

                    List<RuneInfo>? runeInfos1 = null;
                    List<RuneInfo>? runeInfos2 = null;
                    List<RuneInfo>? runeInfos3 = null;
                    if (generateRunedWeapons)
                    {
                        runeInfos1 = RuneInfo.runes1;
                        runeInfos2 = RuneInfo.runes2;
                        runeInfos3 = RuneInfo.runes3;
                    }

                    if (weapon.EditorID.Contains("Iron"))
                    {
                        if (generateRunedWeapons)
                        {
                            CreateRunedWeapon(state, weapon, Material.IronWeapon, RuneInfo.runes1);
                        }
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.IronWeapon, Material.DaedricWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Steel"))
                    {
                        if (generateRunedWeapons)
                        {
                            CreateRunedWeapon(state, weapon, Material.SteelWeapon, RuneInfo.runes1);
                        }
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.SteelWeapon, Material.DaedricWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Silver"))
                    {
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DaedricWeapon, style, runeInfos3);
                        state.PatchMod.Weapons.Set(AddSilverWeaponPerk(weapon.DeepCopy()));
                    }
                    else if (weapon.EditorID.Contains("Moonstone"))
                    {
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.DaedricWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Glass"))
                    {
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.GlassWeapon, Material.DaedricWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Orichalcum"))
                    {
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.DaedricWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.EbonyWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Dwarven"))
                    {
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.EbonyWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.DaedricWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Ebony"))
                    {
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.DaedricWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.EbonyWeapon, Material.GlassWeapon, style, runeInfos3);
                    }
                    else if (weapon.EditorID.Contains("Daedric"))
                    {
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.IronWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.SteelWeapon, style, runeInfos1);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.MoonstoneWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.OrichalcumWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.QuickSilverWeapon, style, runeInfos2, true);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.DwarvenWeapon, style, runeInfos2);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.GlassWeapon, style, runeInfos3);
                        CreateWeapon(state, weapon, Material.DaedricWeapon, Material.EbonyWeapon, style, runeInfos3);
                    }
                }
            }

            foreach (var armoridk in state.LoadOrder.PriorityOrder.Armor().WinningContextOverrides())
            {
                var armor = armoridk.Record;
                if (armor.EditorID == null) continue;

                if (armor.EditorID.Contains("400Armor"))
                {
                    bool generateRunedArmor = false;
                    Style style;
                    if (armor.EditorID.Contains("Altmer"))
                    {
                        style = Style.AltmerStyle;
                    }
                    else if (armor.EditorID.Contains("Akaviri"))
                    {
                        style = Style.AkaviriStyle;
                    }
                    else if (armor.EditorID.Contains("Ancient"))
                    {
                        style = Style.AncientStyle;
                        generateRunedArmor = true;
                    }
                    else if (armor.EditorID.Contains("Breton"))
                    {
                        style = Style.BretonStyle;
                    }
                    else if (armor.EditorID.Contains("Companions"))
                    {
                        style = Style.CompanionsStyle;
                    }
                    else if (armor.EditorID.Contains("Dawnguard"))
                    {
                        style = Style.DawnguardStyle;
                    }
                    else if (armor.EditorID.Contains("Dremora"))
                    {
                        style = Style.DremoraStyle;
                    }
                    else if (armor.EditorID.Contains("Dunmer"))
                    {
                        style = Style.DunmerStyle;
                    }
                    else if (armor.EditorID.Contains("Dwemer"))
                    {
                        style = Style.DwemerStyle;
                    }
                    else if (armor.EditorID.Contains("Hide"))
                    {
                        style = Style.HideStyle;
                    }
                    else if (armor.EditorID.Contains("Imperial"))
                    {
                        style = Style.ImperialStyle;
                    }
                    else if (armor.EditorID.Contains("Leather"))
                    {
                        style = Style.LeatherStyle;
                    }
                    else if (armor.EditorID.Contains("Nord"))
                    {
                        style = Style.NordStyle;
                    }
                    else if (armor.EditorID.Contains("Orcish"))
                    {
                        style = Style.OrcishStyle;
                    }
                    else if (armor.EditorID.Contains("Redguard"))
                    {
                        style = Style.RedguardStyle;
                    }
                    else if (armor.EditorID.Contains("Scale"))
                    {
                        style = Style.ScaleStyle;
                    }
                    else if (armor.EditorID.Contains("Skaal"))
                    {
                        style = Style.SkaalStyle;
                    }
                    else if (armor.EditorID.Contains("Ornate"))
                    {
                        style = Style.OrnateStyle;
                    }
                    else
                    {
                        Console.WriteLine("Could not find Style for Armor:" + armor.EditorID);
                        style = Style.BasicStyle;
                    }

                    bool createSWAP = false;
                    if (armor.BodyTemplate == null) throw new Exception();
                    if (armor.BodyTemplate.ArmorType == ArmorType.HeavyArmor)
                    {
                        createSWAP = true;
                    }

                    List<RuneInfo>? runeInfos1 = null;
                    List<RuneInfo>? runeInfos2 = null;
                    List<RuneInfo>? runeInfos3 = null;
                    if (generateRunedArmor)
                    {
                        runeInfos1 = RuneInfo.runes1;
                        runeInfos2 = RuneInfo.runes2;
                        runeInfos3 = RuneInfo.runes3;
                    }
                    if (armor.EditorID.Contains("Iron"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.IronArmor, RuneInfo.runes1);
                        }
                        CreateArmor(state, armor, Material.IronArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.IronArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos1);
                        CreateArmor(state, armor, Material.IronArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.IronArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.IronArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.IronArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.IronArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.IronArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.IronArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.IronArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Steel"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.SteelArmor, RuneInfo.runes1);
                        }
                        CreateArmor(state, armor, Material.SteelArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.SteelArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.SteelArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.SteelArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.SteelArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.SteelArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.SteelArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.SteelArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.SteelArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.SteelArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Moonstone"))
                    {
                        if (armor.EditorID.Contains("CSWAP"))
                        {
                            armor = CreateCSWAPHeavy(state, armor, Material.MoonstoneArmor);
                            createSWAP = true;
                        }
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.MoonstoneArmor, RuneInfo.runes2);
                        }
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.MoonstoneArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Orichalcum"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.OrichalcumArmor, RuneInfo.runes2);
                        }
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.OrichalcumArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Silver"))
                    {
                        if (armor.EditorID.Contains("CSWAP"))
                        {
                            armor = CreateCSWAPHeavy(state, armor, Material.QuickSilverArmor);
                            createSWAP = true;
                        }
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.QuickSilverArmor, RuneInfo.runes2);
                        }
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.QuickSilverArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Dwarven"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.IronArmor, RuneInfo.runes2);
                        }
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.DwarvenArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Glass"))
                    {
                        if (armor.EditorID.Contains("CSWAP"))
                        {
                            armor = CreateCSWAPHeavy(state, armor, Material.GlassArmor);
                            createSWAP = true;
                        }
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.GlassArmor, RuneInfo.runes3);
                        }
                        CreateArmor(state, armor, Material.GlassArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.GlassArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.GlassArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.GlassArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.GlassArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.GlassArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.GlassArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.GlassArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.GlassArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.GlassArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Ebony"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.EbonyArmor, RuneInfo.runes3);
                        }
                        CreateArmor(state, armor, Material.EbonyArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.DaedricArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.EbonyArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                    else if (armor.EditorID.Contains("Daedric"))
                    {
                        if (generateRunedArmor)
                        {
                            CreateRunedArmor(state, armor, Material.DaedricArmor, RuneInfo.runes3);
                        }
                        CreateArmor(state, armor, Material.DaedricArmor, Material.IronArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.SteelArmor, style, false, runeInfos1);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.MoonstoneArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.OrichalcumArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.QuickSilverArmor, style, createSWAP, runeInfos2);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.DwarvenArmor, style, false, runeInfos2);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.GlassArmor, style, createSWAP, runeInfos3);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.EbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.ALTEbonyArmor, style, false, runeInfos3);
                        CreateArmor(state, armor, Material.DaedricArmor, Material.ALTDaedricArmor, style, false, runeInfos3);
                    }
                }
            }
        }
    }
}
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
        public FormKey Ingot;
        public FormKey Keyword;
        public ConditionFloat? PerkRequirement;

        public Material(string name)
        {
            Name = name;
        }

        public Material(string name, FormKey ingot, FormKey keyword)
        {
            Name = name;
            Ingot = ingot;
            Keyword = keyword;
        }

        public Material(string name, FormKey ingot, FormKey keyword, FormKey smithingPerk)
        {
            Name = name;
            Ingot = ingot;
            Keyword = keyword;

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

        //                                               Name                    Ingot                                 Keyword                         Required Smithing Perk
        public static readonly Material IronWeapon = new("Iron", FormKey.Factory("05ACE4:Skyrim.esm"), FormKey.Factory("01E718:Skyrim.esm"));
        public static readonly Material SteelWeapon = new("Steel", FormKey.Factory("05ACE5:Skyrim.esm"), FormKey.Factory("01E719:Skyrim.esm"), FormKey.Factory("0CB40D:Skyrim.esm"));
        public static readonly Material DwarvenWeapon = new("Dwarven", FormKey.Factory("0DB8A2:Skyrim.esm"), FormKey.Factory("01E71A:Skyrim.esm"), FormKey.Factory("0CB40E:Skyrim.esm"));
        public static readonly Material MoonstoneWeapon = new("Moonstone", FormKey.Factory("05AD9F:Skyrim.esm"), FormKey.Factory("01E71B:Skyrim.esm"), FormKey.Factory("0CB40f:Skyrim.esm"));
        public static readonly Material OrichalcumWeapon = new("Orichalcum", FormKey.Factory("05AD99:Skyrim.esm"), FormKey.Factory("01E71C:Skyrim.esm"), FormKey.Factory("0CB410:Skyrim.esm"));
        public static readonly Material GlassWeapon = new("Glass", FormKey.Factory("05ADA1:Skyrim.esm"), FormKey.Factory("01E71D:Skyrim.esm"), FormKey.Factory("0CB411:Skyrim.esm"));
        public static readonly Material EbonyWeapon = new("Ebony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("01E71E:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm"));
        public static readonly Material DaedricWeapon = new("Daedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("01E71F:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"));
        public static readonly Material QuickSilverWeapon = new("Silver", FormKey.Factory("05ADA0:Skyrim.esm"), FormKey.Factory("10AA1A:Skyrim.esm"), FormKey.Factory("014A21:Armoury of Tamriel.esm"));

        public static readonly Material IronArmor = new("Iron", FormKey.Factory("05ACE4:Skyrim.esm"), FormKey.Factory("06BBE3:Skyrim.esm"));
        public static readonly Material SteelArmor = new("Steel", FormKey.Factory("05ACE5:Skyrim.esm"), FormKey.Factory("06BBE6:Skyrim.esm"), FormKey.Factory("0CB40D:Skyrim.esm"));
        public static readonly Material DwarvenArmor = new("Dwarven", FormKey.Factory("0DB8A2:Skyrim.esm"), FormKey.Factory("06BBD7:Skyrim.esm"), FormKey.Factory("0CB40E:Skyrim.esm"));
        public static readonly Material MoonstoneArmor = new("Moonstone", FormKey.Factory("05AD9F:Skyrim.esm"), FormKey.Factory("06BBD9:Skyrim.esm"), FormKey.Factory("0CB40f:Skyrim.esm"));
        public static readonly Material OrichalcumArmor = new("Orichalcum", FormKey.Factory("05AD99:Skyrim.esm"), FormKey.Factory("06BBE5:Skyrim.esm"), FormKey.Factory("0CB410:Skyrim.esm"));
        public static readonly Material GlassArmor = new("Glass", FormKey.Factory("05ADA1:Skyrim.esm"), FormKey.Factory("06BBDC:Skyrim.esm"), FormKey.Factory("0CB411:Skyrim.esm"));
        public static readonly Material EbonyArmor = new("Ebony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD8:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm"));
        public static readonly Material DaedricArmor = new("Daedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD4:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"));
        public static readonly Material QuickSilverArmor = new("Silver", FormKey.Factory("05ADA0:Skyrim.esm"), FormKey.Factory("06BBE2:Skyrim.esm"), FormKey.Factory("014A21:Armoury of Tamriel.esm"));

        public static readonly Material ALTEbonyArmor = new("ALTEbony", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD8:Skyrim.esm"), FormKey.Factory("0CB412:Skyrim.esm")); 
        public static readonly Material ALTDaedricArmor = new("ALTDaedric", FormKey.Factory("05AD9D:Skyrim.esm"), FormKey.Factory("06BBD4:Skyrim.esm"), FormKey.Factory("0CB413:Skyrim.esm"));
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

        public static readonly Style ScaleStyle = new("Scale", FormKey.Factory("02B6E8:Armoury of Tamriel.esm"));

        public static readonly Style CompanionsStyle = new("Companions", FormKey.Factory("02B6EB:Armoury of Tamriel.esm"));
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

        public static readonly FormLink<Keyword> ArmorHeavy = new FormLink<Keyword>(FormKey.Factory("06BBD2:Skyrim.esm"));
        public static readonly FormLink<Keyword> ArmorLight = new FormLink<Keyword>(FormKey.Factory("06BBD3:Skyrim.esm"));


        public static void CreateWeapon(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IWeaponGetter weapon, Material oldMaterial, Material newMaterial, Style style)
        {
            // Item
            var neweapon = state.PatchMod.Weapons.DuplicateInAsNewRecord(weapon);

            if (weapon.EditorID == null) throw new Exception("null editorid");
            if (weapon.Name == null) throw new Exception("null name");
            var oldname = weapon.Name.ToString();
            if (oldname == null) throw new Exception("null name");

            var editorID = weapon.EditorID.Replace(oldMaterial.Name, newMaterial.Name);
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

            // Model

            var oldweaponmodel = weapon.FirstPersonModel.Resolve(state.LinkCache);
            if (oldweaponmodel == null) throw new Exception();

            var neweaponmodel = state.PatchMod.Statics.DuplicateInAsNewRecord(oldweaponmodel);
            neweapon.FirstPersonModel = new FormLinkNullable<IStaticGetter>(neweaponmodel);

            neweaponmodel.EditorID = "1stPerson" + editorID;

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
                EditorID = "Recipe" + editorID,
                CreatedObjectCount = 1,
                CreatedObject = new FormLinkNullable<IConstructibleGetter>(neweapon.FormKey),
                Conditions = recipeConditions,
                WorkbenchKeyword = forge
            };

            state.PatchMod.ConstructibleObjects.Set(newRecipe);

            // Temper
            var newTemper = new ConstructibleObject(state.PatchMod)
            {
                EditorID = "Temper" + editorID,
                CreatedObjectCount = 1,
                CreatedObject = new FormLinkNullable<IConstructibleGetter>(neweapon.FormKey),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = new FormLink<IItemGetter>(newMaterial.Ingot),
                            Count = 1
                        }
                    }
                },
                Conditions = temperConditions,
                WorkbenchKeyword = sharpeningWheel
            };

            state.PatchMod.ConstructibleObjects.Set(newTemper);
        }

        public static void CreateArmor(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material oldMaterial, Material newMaterial, Style style, bool CSWAP = false)
        {
            // Item
            var newarmor = state.PatchMod.Armors.DuplicateInAsNewRecord(armor);

            if (armor.EditorID == null) throw new Exception("null editorid");
            if (armor.Name == null) throw new Exception("null name");
            var oldname = armor.Name.ToString();
            if (oldname == null) throw new Exception("null name");

            var editorID = armor.EditorID.Replace(oldMaterial.Name, newMaterial.Name);
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

            // Armor Addons

            var newarmature = new Noggog.ExtendedList<IFormLinkGetter<IArmorAddonGetter>>();
            foreach (var armoraddon in newarmor.Armature)
            {
                var newarmoraddon = state.PatchMod.ArmorAddons.DuplicateInAsNewRecord(armoraddon.Resolve(state.LinkCache));
                newarmoraddon.EditorID = editorID + "AA";
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
                EditorID = "Recipe" + editorID,
                CreatedObjectCount = 1,
                CreatedObject = new FormLinkNullable<IConstructibleGetter>(newarmor.FormKey),
                Conditions = recipeConditions,
                WorkbenchKeyword = forge
            };

            state.PatchMod.ConstructibleObjects.Set(newRecipe);

            // Temper
            var newTemper = new ConstructibleObject(state.PatchMod)
            {
                EditorID = "Temper" + editorID,
                CreatedObjectCount = 1,
                CreatedObject = newarmor.AsNullableLink(),
                Items = new Noggog.ExtendedList<ContainerEntry>
                {
                    new ContainerEntry()
                    {
                        Item = new ContainerItem()
                        {
                            Item = new FormLink<IItemGetter>(newMaterial.Ingot),
                            Count = 1
                        }
                    }
                },
                Conditions = temperConditions,
                WorkbenchKeyword = armorTable
            };
            state.PatchMod.ConstructibleObjects.Set(newTemper);

            // CSWAP
            if (CSWAP)
            {
                var CSWAParmor = newarmor.Duplicate(state.PatchMod.GetNextFormKey());

                FormLink<IItemGetter> heavyArmor;
                FormLink<IItemGetter> lightArmor;

                // Armor
                if (CSWAParmor.BodyTemplate == null || CSWAParmor.Keywords == null) throw new Exception();
                if (CSWAParmor.BodyTemplate.ArmorType == ArmorType.HeavyArmor)
                {
                    CSWAParmor.Keywords.Remove(ArmorHeavy);
                    CSWAParmor.Keywords.Add(ArmorLight);
                    CSWAParmor.BodyTemplate.ArmorType = ArmorType.LightArmor;
                    heavyArmor = (FormLink<IItemGetter>)newarmor.AsLink();
                    lightArmor = (FormLink<IItemGetter>)CSWAParmor.AsLink();
                } else
                {

                    CSWAParmor.Keywords.Remove(ArmorLight);
                    CSWAParmor.Keywords.Add(ArmorHeavy);
                    CSWAParmor.BodyTemplate.ArmorType = ArmorType.HeavyArmor;
                    heavyArmor = (FormLink<IItemGetter>)CSWAParmor.AsLink();
                    lightArmor = (FormLink<IItemGetter>)newarmor.AsLink();
                }
                state.PatchMod.Armors.Set(CSWAParmor);

                // Temper
                var CSWAPtemper = newTemper.Duplicate(state.PatchMod.GetNextFormKey());
                CSWAPtemper.EditorID = newTemper.EditorID.Replace("400Recipe", "400RecipeCSWAP");
                CSWAPtemper.CreatedObject = CSWAParmor.AsNullableLink();
                state.PatchMod.ConstructibleObjects.Set(CSWAPtemper);

                // Convert Light to Heavy
                var convertHeavy = new ConstructibleObject(state.PatchMod)
                {
                    EditorID = "400RecipeCSWAPLighttoHeavy" + editorID,
                    CreatedObjectCount = 1,
                    CreatedObject = (IFormLinkNullable<IConstructibleGetter>)heavyArmor,
                    Items = new Noggog.ExtendedList<ContainerEntry>
                    {
                        new ContainerEntry()
                        {
                            Item = new ContainerItem()
                            {
                                Item = lightArmor,
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
                                ParameterOneRecord = lightArmor
                            }
                        },
                    },
                    WorkbenchKeyword = armorSwap
                };
                state.PatchMod.ConstructibleObjects.Set(convertHeavy);

                // Convert Heavy to Light
                var convertLight = new ConstructibleObject(state.PatchMod)
                {
                    EditorID = "400RecipeCSWAPHeavytoLight" + editorID,
                    CreatedObjectCount = 1,
                    CreatedObject = (IFormLinkNullable<IConstructibleGetter>)lightArmor,
                    Items = new Noggog.ExtendedList<ContainerEntry>
                    {
                        new ContainerEntry()
                        {
                            Item = new ContainerItem()
                            {
                                Item = heavyArmor,
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
                                ParameterOneRecord = heavyArmor
                            }
                        },
                    },
                    WorkbenchKeyword = armorSwap
                };
                state.PatchMod.ConstructibleObjects.Set(convertLight);
            }
        }
        public static void CreateCSWAP(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IArmorGetter armor, Material material)
        {

        };



        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            //Your code here!

            /*
            var weapons = new List<IWeaponGetter>()
            {
                state.LinkCache.Resolve<IWeaponGetter>("300IronBasicLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300IronAncientLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300SteelNordicLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300SteelImperialLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300SteelSkaalLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300SilverBretonLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300OrichalcumOrcishLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300MoonstoneAltmerLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300DwarvenDwemerLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300GlassOrnateLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300EbonyDunmerLongsword"),
                state.LinkCache.Resolve<IWeaponGetter>("300DaedricDremoraLongsword")



                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005914:Lovely Longswords - Vanilla Version.esp")), //ironbasic
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("00591A:Lovely Longswords - Vanilla Version.esp")), //ironancient
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("00590F:Lovely Longswords - Vanilla Version.esp")), //steelnordic
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005915:Lovely Longswords - Vanilla Version.esp")), //steelimperial
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("00591E:Lovely Longswords - Vanilla Version.esp")), //silverskaal
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005912:Lovely Longswords - Vanilla Version.esp")), //orichalcumorcish
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005917:Lovely Longswords - Vanilla Version.esp")), //moonstonealtmer
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005919:Lovely Longswords - Vanilla Version.esp")), //dwarvendwemer
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005916:Lovely Longswords - Vanilla Version.esp")), //glassornate
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("005918:Lovely Longswords - Vanilla Version.esp")), //ebonydunmer
                state.LinkCache.Resolve<IWeaponGetter>(FormKey.Factory("00591C:Lovely Longswords - Vanilla Version.esp")) //daedricdremora
            };
            */

            foreach (var weaponidk in state.LoadOrder.PriorityOrder.Weapon().WinningContextOverrides())
            {
                var weapon = weaponidk.Record;

                if (weapon.EditorID == null) continue;

                if (weapon.EditorID.Contains("400IronBasic"))
                {
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.SteelWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.QuickSilverWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.OrichalcumWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.MoonstoneWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.DwarvenWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.DaedricWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.EbonyWeapon, Style.BasicStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.GlassWeapon, Style.BasicStyle);
                }
                else if (weapon.EditorID.Contains("400IronAncient"))
                {
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.SteelWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.QuickSilverWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.OrichalcumWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.MoonstoneWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.DwarvenWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.DaedricWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.EbonyWeapon, Style.AncientStyle);
                    CreateWeapon(state, weapon, Material.IronWeapon, Material.GlassWeapon, Style.AncientStyle);
                }
                else if (weapon.EditorID.Contains("400SteelNordic"))
                {
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.IronWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.QuickSilverWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.OrichalcumWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.MoonstoneWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DwarvenWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DaedricWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.EbonyWeapon, Style.NordStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.GlassWeapon, Style.NordStyle);
                }
                else if (weapon.EditorID.Contains("400SteelImperial"))
                {
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.IronWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.QuickSilverWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.OrichalcumWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.MoonstoneWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DwarvenWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DaedricWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.EbonyWeapon, Style.ImperialStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.GlassWeapon, Style.ImperialStyle);
                }
                else if (weapon.EditorID.Contains("400SteelSkaal"))
                {
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.IronWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.QuickSilverWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.OrichalcumWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.MoonstoneWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DwarvenWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DaedricWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.EbonyWeapon, Style.SkaalStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.GlassWeapon, Style.SkaalStyle);
                }
                else if (weapon.EditorID.Contains("400SteelAkaviri"))
                {
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.IronWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.QuickSilverWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.OrichalcumWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.MoonstoneWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DwarvenWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.DaedricWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.EbonyWeapon, Style.AkaviriStyle);
                    CreateWeapon(state, weapon, Material.SteelWeapon, Material.GlassWeapon, Style.AkaviriStyle);
                }
                else if (weapon.EditorID.Contains("400SilverBreton"))
                {
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.IronWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.SteelWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.OrichalcumWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.MoonstoneWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DwarvenWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DaedricWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.EbonyWeapon, Style.BretonStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.GlassWeapon, Style.BretonStyle);
                }
                else if (weapon.EditorID.Contains("400SilverDawnguard"))
                {
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.IronWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.SteelWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.OrichalcumWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.MoonstoneWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DwarvenWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.DaedricWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.EbonyWeapon, Style.DawnguardStyle);
                    CreateWeapon(state, weapon, Material.QuickSilverWeapon, Material.GlassWeapon, Style.DawnguardStyle);
                }
                else if (weapon.EditorID.Contains("400MoonstoneAltmer"))
                {
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.IronWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.SteelWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.OrichalcumWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.QuickSilverWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.DwarvenWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.DaedricWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.EbonyWeapon, Style.AltmerStyle);
                    CreateWeapon(state, weapon, Material.MoonstoneWeapon, Material.GlassWeapon, Style.AltmerStyle);
                }
                else if (weapon.EditorID.Contains("400GlassOrnate"))
                {
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.IronWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.SteelWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.OrichalcumWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.QuickSilverWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.DwarvenWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.DaedricWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.EbonyWeapon, Style.OrnateStyle);
                    CreateWeapon(state, weapon, Material.GlassWeapon, Material.MoonstoneWeapon, Style.OrnateStyle);
                }
                else if (weapon.EditorID.Contains("400OrichalcumOrcish"))
                {
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.IronWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.SteelWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.GlassWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.QuickSilverWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.DwarvenWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.DaedricWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.EbonyWeapon, Style.OrcishStyle);
                    CreateWeapon(state, weapon, Material.OrichalcumWeapon, Material.MoonstoneWeapon, Style.OrcishStyle);
                }
                else if (weapon.EditorID.Contains("400DwarvenDwemer"))
                {
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.IronWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.SteelWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.GlassWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.QuickSilverWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.OrichalcumWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.DaedricWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.EbonyWeapon, Style.DwemerStyle);
                    CreateWeapon(state, weapon, Material.DwarvenWeapon, Material.MoonstoneWeapon, Style.DwemerStyle);
                }
                else if (weapon.EditorID.Contains("400EbonyDunmer"))
                {
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.IronWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.SteelWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.GlassWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.QuickSilverWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.OrichalcumWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.DaedricWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.DwarvenWeapon, Style.DunmerStyle);
                    CreateWeapon(state, weapon, Material.EbonyWeapon, Material.MoonstoneWeapon, Style.DunmerStyle);
                }
                else if (weapon.EditorID.Contains("400DaedricDremora"))
                {
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.IronWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.SteelWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.GlassWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.QuickSilverWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.OrichalcumWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.EbonyWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.DwarvenWeapon, Style.DremoraStyle);
                    CreateWeapon(state, weapon, Material.DaedricWeapon, Material.MoonstoneWeapon, Style.DremoraStyle);
                }
            }

            foreach (var armoridk in state.LoadOrder.PriorityOrder.Armor().WinningContextOverrides())
            {
                var armor = armoridk.Record;
                if (armor.EditorID == null) continue;

                if (armor.EditorID.Contains("400IronCompanions"))
                {
                    CreateArmor(state, armor, Material.IronArmor, Material.SteelArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.QuickSilverArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.OrichalcumArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.MoonstoneArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.DwarvenArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.DaedricArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.EbonyArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.GlassArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.ALTDaedricArmor, Style.CompanionsStyle);
                    CreateArmor(state, armor, Material.IronArmor, Material.ALTEbonyArmor, Style.CompanionsStyle);
                }

                if (armor.EditorID.Contains("400ArmorMoonstoneAltmer"))
                {
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.IronArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.SteelArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.QuickSilverArmor, Style.AltmerStyle, true);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.OrichalcumArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.DwarvenArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.DaedricArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.EbonyArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.GlassArmor, Style.AltmerStyle, true);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.ALTDaedricArmor, Style.AltmerStyle);
                    CreateArmor(state, armor, Material.MoonstoneArmor, Material.ALTEbonyArmor, Style.AltmerStyle);
                }
            }
        }
    }
}

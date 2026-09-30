// Copyright 2024, Aquanox.

using UnrealBuildTool;

public class BCREditor : ModuleRules
{
	// This is to emulate engine installation and verify includes during development
	// Gives effect similar to BuildPlugin with -StrictIncludes
	public bool bStrictIncludesCheck = false;

	public BCREditor(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		if (bStrictIncludesCheck)
		{
			bUseUnity = false;
			PCHUsage = PCHUsageMode.NoPCHs;
			// Enable additional checks used for Engine modules
			bTreatAsEngineModule = true;
		}

		PublicIncludePaths.Add(ModuleDirectory);

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"BCR"
		});

		PrivateDependencyModuleNames.AddRange(new string[] {
			"Engine",
			"Slate",
			"SlateCore",
			"InputCore",
			"UnrealEd",
			"EditorWidgets",
			"PropertyEditor",
			"ApplicationCore",
			"Kismet",
			"BlueprintGraph",
			"EditorStyle"
		});
	}
}

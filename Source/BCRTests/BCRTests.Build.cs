// Copyright 2024, Aquanox.

using UnrealBuildTool;

public class BCRTests : ModuleRules
{
	// This is to emulate engine installation and verify includes during development
	// Gives effect similar to BuildPlugin with -StrictIncludes
	public bool bStrictIncludesCheck = false;

	public BCRTests(ReadOnlyTargetRules Target) : base(Target)
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
		PrivateDefinitions.Add("WITH_CACHED_COMPONENT_REFERENCE_TESTS=1");

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"BCR",
			"BCREditor"
		});
		
		if (Target.Version.MajorVersion >= 5)
		{
			PrivateDependencyModuleNames.AddRange(new string[] {
				"AutomationTest"
			});
		}
	}
}

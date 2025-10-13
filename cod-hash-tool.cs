using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
public class CODHashTool
{ 
	static object writeLock = new object();

	static bool debugEnabled = false;

	static int Main()
	{
		for (; ; )
		{
			Console.WriteLine(@"
			Welcome to the COD Hash Finder! Please select an operation.
			To enter multiple in sequence, seperate your option with a ',':
		
			1 - Animations

				11 - Weapon Animations
					
					111 - VM Weapon Animations (IW9)

					112 - WM Weapon Animations (IW9) (NOT IMPLEMENTED)

					113 - VM Weapon Animations (JUP)

					114 - WM Weapon Animations (JUP) (NOT IMPLEMENTED)

					115 - VM Weapon Animations (T10)

					116 - WM Weapon Animations (T10)

					1161 - Execution Animations (T10)

					117 - VM Weapon Animations (SAT)

					118 - WM Weapon Animations (SAT)

			2 - Animation Packages

				21 - Animation Package Names
	
					211 - Animation Package Names
			
			3 - Images

				31 - Textures from Material Names

					311 - Textures from Material Names (T8/T9)

					312 - Textures from Material Names (IW9/JUP/T10/SAT)

			4 - Materials

				41 - Weapon Materials
	
					411 - Weapon Materials (T8)

					412 - Weapon Materials (T9)

					413 - Weapon Materials (IW9)

					414 - Weapon Materials (JUP)

					415 - Weapon Materials (T10)

					416 - Weapon Materials (SAT)

				42 - Model Name to Material Name

					421 - Model Name to Material Name (T8/T9)

					422 - Model Name to Material Name (IW9/JUP/T10)

				43 - Materials from Texture Names
	
					431 - Materials from Texture Names (T8/T9)

					432 - Materials from Texture Names (IW9/JUP/T10/SAT)
			
				44 - Operator Materials

					441 - Operator Materials (T10/SAT)

				45 - Bullet Materials

					451 - Bullet Materials (IW9/JUP)

					452 - Bullet Materials (T10/SAT)

				49 - Material Endings
					
					491 - Scrape Material Endings

					492 - Material Endings to Materials

			5 - Models

			6 - Sounds

				61 - Weapon Sounds

					611 - Weapon Sounds (IW9)

					612 - Weapon Sounds (JUP)

					613 - Weapon Sounds (T10)

					614 - Weapon Sounds (SAT)
					
			7 - Soundbanks

				71 - Soundbank Names

				72 - Manual Soundbank Naming

				73 - Soundbank Aliases

			8 - Generate Found Names

				81 - Generate Animations

					811 - Generate Animations (T8/T9)

					812 - Generate Animations (IW9/JUP/T10)

				82 - Generate Images

					821 - Generate Images (T8/T9)

					822 - Generate Images (IW9/JUP/T10)

				83 - Generate Materials

					831 - Generate Materials (T8/T9)

					832 - Generate Materials (IW9/JUP/T10)

				84 - Generate Models

					841 - Generate Models (T8/T9)

					842 - Generate Models (IW9/JUP/T10)

				85 - Generate Sounds

					851 - Generate Sounds (T8/T9)

					852 - Generate Sounds (IW9/JUP/T10)

				86 - Generate Soundbanks

				87 - Generate Animation Packages

				88 - Generate Bones

			9 - Miscellanious

				91 - Split AssetLogs

				92 - Asset Exports

				93 - Speaker JSONS

				94 - Grab Sounds

				95 - Sound Guesser

				97 - Find Anims from Bone Name

				98 - Hasher

				99 - Toggle Debug Printing
			");

			Console.WriteLine("\nDebug = " + (debugEnabled.ToString()).ToUpper());

			string? userOption = Console.ReadLine();

			Console.Clear();
			Console.WriteLine("\x1b[3J");

			if (userOption != null)
			{
				if(userOption.ToUpper() == "QUIT")
				{ 
					break;
				}

				string[] userOptions = userOption.Split(',');

				foreach (string option in userOptions)
				{
					switch (option)
					{
						//WEAPON ANIMATIONS
						case "111":
						{
							IW9VMWeaponAnimations();

							break;
						}
						case "113":
						{
							JUPVMWeaponAnimations();

							break;
						}
						case "115":
						{
							T10VMWeaponAnimations();

							break;
						}
						case "116":
						{
							T10WMWeaponAnimations();

							break;
						}
						case "1161":
						{
							T10ExecutionAnimations();

							break;
						}
						case "117":
						{
							SATVMWeaponAnimations();

							break;
						}
						case "118":
						{
							SATWMWeaponAnimations();

							break;
						}
						//ANIM PACKAGES
						case "211":
						{
							AnimPackages();

							break;
						}
						//IMAGES FROM MATERIALS
						case "311":
						{
							TexturesFromMaterialNamesLegacy();

							break;
						}
						case "312":
						{
							TexturesFromMaterialNames();

							break;
						}
						//WEAPON MATERIALS
						case "413":
						{
							IW9WeaponMaterials();

							break;
						}
						case "414":
						{
							JUPWeaponMaterials();

							break;
						}
						case "415":
						{
							T10WeaponMaterials();

							break;
						}
						case "416":
						{
							SATWeaponMaterials();

							break;
						}
						//MODEL NAME TO MATERIAL
						case "421":
						{
							LegacyModelsToMaterials();

							break;
						}
						case "422":
						{
							ModelsToMaterials();

							break;
						}
						//OPERATOR MATERIALS
						case "441":
						{
							OperatorMaterials();

							break;
						}
						//MATERIAL ENDINGS
						case "491":
						{
							ScrapeMaterialEndings();

							break;
						}
						case "492":
						{
							MaterialEndingsToMaterials();

							break;
						}
						//WEAPON SOUNDS
						case "611":
						{
							IW9WeaponSounds();

							break;
						}
						case "612":
						{
							JUPWeaponSounds();

							break;
						}
						case "613":
						{
							T10WeaponSounds();

							break;
						}
						case "614":
						{
							SATWeaponSounds();

							break;
						}
						//SOUNDBANKS
						case "71":
						{
							Soundbanks();

							break;
						}
						//GENERATE FOUND NAMES
						case "811":
						{
							GenerateAnimationsLegacy();

							break;
						}
						case "812":
						{
							GenerateAnimations();

							break;
						}
						case "821":
						{
							GenerateImagesLegacy();

							break;
						}
						case "822":
						{
							GenerateImages();

							break;
						}
						case "831":
						{
							GenerateMaterialsLegacy();

							break;
						}
						case "832":
						{
							GenerateMaterials();

							break;
						}
						case "841":
						{
							GenerateModelsLegacy();

							break;
						}
						case "842":
						{
							GenerateModels();

							break;
						}
						case "851":
						{
							GenerateSoundsLegacy();

							break;
						}
						case "852":
						{
							GenerateSounds();

							break;
						}
						case "86":
						{
							GenerateSoundbanks();

							break;
						}
						case "87":
						{
							GenerateAnimpackages();

							break;
						}
						case "88":
						{
							GenerateBones();

							break;
						}
						//MISCELLANIOUS
						case "91":
						{
							SplitAssetLogs();

							break;
						}
						case "95":
						{
							SoundGuesser();

							break;
						}
						case "97":
						{
							AnimScanner();

							break;
						}
						case "98":
						{
							Hasher();

							break;
						}
						case "Debug":
						case "99":
						{
							debugEnabled = debugEnabled ? debugEnabled = false : debugEnabled = true;

							break;
						}
						default:
						{
							break;
						}
					}
				}
			}
		}

		return 0;
	}

	// For general asset names in IW9/JUP/T10
	static string CalcHash64_v1(string data)
	{
		ulong result = 0x47F5817A5EF961BA;

		for(int i = 0; i < Encoding.UTF8.GetByteCount(data); i++)
		{
			ulong value = data[i];

			if(value == '\\')
			{
				value = '/';
			}

			result = 0x100000001B3 * (value ^ result);
		}

		return String.Format("{0:x}", result & 0x7FFFFFFFFFFFFFFF);
	}

	// For general asset names in T8/T9
	static string CalcHash64_v2(string data)
	{
		ulong result = 0xCBF29CE484222325;
        
		for (int i = 0; i < Encoding.UTF8.GetByteCount(data); i++)
		{
			ulong value = data[i];
			if (value == '\\')
			{
				value = '/';
			}

			result = 0x100000001B3 * (value ^ result);
		}
        
		return String.Format("{0:x}", result & 0x7FFFFFFFFFFFFFFF);
	}

	// For T10 Bone Names
	static string CalcHash64_v3(string data)
	{
		ulong result = 0xCBF29CE484222325;
        
		for (int i = 0; i < Encoding.UTF8.GetByteCount(data); i++)
		{
			ulong value = data[i];
			if (value == '\\')
			{
				value = '/';
			}

			result = 0x100000001B3 * (value ^ result);
		}
        
		return String.Format("{0:x}", result);
	}

	// For IW9/JUP Bone Names
	static string CalcHash32(string data)
	{
		uint result = 0x811C9DC5;

		for (int i = 0; i < Encoding.UTF8.GetByteCount(data); i++)
		{
			uint value = data[i];

			if (value == '\\')
			{
				value = '/';
			}

			result = 0x01000193 * (value ^ result);
		}

		return String.Format("{0:x}", result);
	}

	static string PickGame(int returnType)
    {
        for (; ; )
        {
            Console.WriteLine("T8, T9, IW9, JUP, T10 or SAT?\n");

            string? userResponse = Console.ReadLine();

			if(userResponse != null)
			{
				userResponse = userResponse.ToUpper();

				switch (userResponse)
				{
					case "SAT":
					case "BO7":
					{
						switch(returnType)
						{
							case 0:
							{
								return "SAT";
							}
							case 1:
							{
								return "BO7";
							}
							default:
							{
								break;
							}
						}

						break;
					}
					case "T10":
					case "BO6":
					{
						switch(returnType)
						{
							case 0:
							{
								return "T10";
							}
							case 1:
							{
								return "BO6";
							}
							default:
							{
								break;
							}
						}

						break;
					}
					case "JUP":
					case "MW6":
					{
						switch(returnType)
						{
							case 0:
							{
								return "JUP";
							}
							case 1:
							{
								return "MW6";
							}
							default:
							{
								break;
							}
						}

						break;
					}
					case "IW9":
					case "MW5":
					{
						switch(returnType)
						{
							case 0:
							{
								return "IW9";
							}
							case 1:
							{
								return "MW5";
							}
							default:
							{
								break;
							}
						}

						break;
					}
					case "T8":
					case "BO4":
					{
						switch(returnType)
						{
							case 0:
							{
								return "T8";
							}
							case 1:
							{
								return "BO4";
							}
							default:
							{
								break;
							}
						}

						break;
					}
					case "T9":
					case "BOCW":
					{
						switch(returnType)
						{
							case 0:
							{
								return "T9";
							}
							case 1:
							{
								return "BOCW";
							}
							default:
							{
								break;
							}
						}

						break;
					}
				}
			}
        }
    }

	static void IW9VMWeaponAnimations()
	{
		Console.WriteLine("Generating IW9 VM Weapon Animations:\n");

		string[] IW9AnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Animations.txt");

		string[] IW9VMAnimationNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\VMAnimationNames.txt");
		string[] IW9WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\IW9WeaponNames.txt");

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in IW9WeaponNames)
		{
			using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

			Parallel.ForEach(IW9VMAnimationNames, animationName =>
			{
				string stringedName = "vm_" + weaponName + "_" + animationName;
				string generatedHash = CalcHash64_v1(stringedName);

				if(debugEnabled)
				{
					Console.WriteLine(stringedName);
				}

				Parallel.ForEach(IW9AnimationAssetLog, hash =>
				{
					if(hash == generatedHash)
					{
						string output = generatedHash + "," + stringedName;

						lock(writeLock)
						{
							GeneratedAnimations.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			});

			GeneratedAnimations.Flush();
			GeneratedAnimations.Close();
		}
	}

	static void JUPVMWeaponAnimations()
	{
		Console.WriteLine("Generating JUP VM Weapon Animations:\n");

		string[] JUPAnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Animations.txt");

		string[] JUPVMAnimationNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\VMAnimationNames.txt");
		string[] JUPWeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\JUPWeaponNames.txt");

		string[] namePrefixes = {"vm_","jup_vm_"};
		string[] weaponPlatformPrefixes = {"c","j",""};

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in JUPWeaponNames)
		{
			using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

			Parallel.ForEach(namePrefixes, namePrefix =>
			{
				Parallel.ForEach(weaponPlatformPrefixes, weaponPlatformPrefix =>
				{
					Parallel.ForEach(JUPVMAnimationNames, animationName =>
					{
						string stringedName = namePrefix + weaponPlatformPrefix + weaponName + "_" + animationName;
						string generatedHash = CalcHash64_v1(stringedName);

						if(debugEnabled)
						{
							Console.WriteLine(stringedName);
						}

						Parallel.ForEach(JUPAnimationAssetLog, hash =>
						{
							if(hash == generatedHash)
							{
								string output = generatedHash + "," + stringedName;

								lock(writeLock)
								{
									GeneratedAnimations.WriteLine(output);
									Console.WriteLine(output);
								}
							}
						});
					});
				});
			});

			GeneratedAnimations.Flush();
			GeneratedAnimations.Close();
		}
	}

	static void T10VMWeaponAnimations()
	{
		Console.WriteLine("Generating T10 VM Weapon Animations:\n");

		string[] T10AnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Animations.txt");

		string[] T10VMAnimationNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\VMAnimationNames.txt");
		string[] T10WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\T10WeaponNames.txt");

		string[] namePrefixes = {"vm_","t10_vm_"};

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in T10WeaponNames)
		{
			using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

			Parallel.ForEach(namePrefixes, namePrefix =>
			{
				Parallel.ForEach(T10VMAnimationNames, animationName =>
				{
					string stringedName = namePrefix + weaponName + "_" + animationName;
					string generatedHash = CalcHash64_v1(stringedName);

					if(debugEnabled)
					{
						Console.WriteLine(stringedName);
					}

					Parallel.ForEach(T10AnimationAssetLog, hash =>
					{
						if(hash == generatedHash)
						{
							string output = generatedHash + "," + stringedName;

							lock(writeLock)
							{
								GeneratedAnimations.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
				});
			});

			GeneratedAnimations.Flush();
			GeneratedAnimations.Close();
		}
	}

	static void T10WMWeaponAnimations()
    {
        Console.WriteLine("Generating T10 WM Weapon Animations:\n");

		string[] T10AnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Animations.txt");

		string[] T10WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\T10WeaponNames.txt");
		string[] T10WMNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMNames.txt");
		string[] T10WMAnimations = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMAnimations.txt");
        string[] T10WMDetails = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMDetails.txt");
        string[] T10WMSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMSuffixes.txt");
		

        if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

        foreach (string weaponName in T10WeaponNames)
        {
            using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

            foreach (string prefixName in T10WMNames)
            {
				foreach (string animation in T10WMAnimations)
                {
					foreach (string details in T10WMDetails)
					{
						foreach (string suffixType in T10WMSuffixes)
						{
							string stringedName = prefixName + weaponName + "_" + animation + details + suffixType;
							string generatedHash = CalcHash64_v1(stringedName);

							if (debugEnabled)
							{
								Console.WriteLine(stringedName);
							}

							Parallel.ForEach(T10AnimationAssetLog, hash =>
							{
								if(hash == generatedHash)
								{
									string output = generatedHash + "," + stringedName;

									lock(writeLock)
									{
										GeneratedAnimations.WriteLine(output);
										Console.WriteLine(output);
									}
								}
							});
						}
                    }
                }
            }

            GeneratedAnimations.Flush();
            GeneratedAnimations.Close();
        }
    }

	static void T10ExecutionAnimations()
    {
        Console.WriteLine("Generating T10 Execution Animations:\n");

		string[] T10AnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Animations.txt");

		string[] T10ExecutionNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\ExecutionNames.txt");
		string[] T10ExecutionSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Animations\ExecutionSuffixes.txt");
		string[] T10ExecutionGenders = {"","_fem"};

        if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

        foreach (string executionGender in T10ExecutionGenders)
        {
            using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

            foreach (string executionName in T10ExecutionNames)
            {
				foreach (string executionSuffix in T10ExecutionSuffixes)
                {
					string stringedName = executionName + executionSuffix + executionGender;
					string generatedHash = CalcHash64_v1(stringedName);

					if (debugEnabled)
					{
						Console.WriteLine(stringedName);
					}

					Parallel.ForEach(T10AnimationAssetLog, hash =>
					{
						if(hash == generatedHash)
						{
							string output = generatedHash + "," + stringedName;

							lock(writeLock)
							{
								GeneratedAnimations.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
                }
            }

            GeneratedAnimations.Flush();
            GeneratedAnimations.Close();
        }
    }

	static void SATVMWeaponAnimations()
	{
		Console.WriteLine("Generating SAT VM Weapon Animations:\n");

		string[] SATAnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Animations.txt");

		string[] SATVMAnimationNames = File.ReadAllLines(@"cod-hash-tool-data\Animations\VMAnimationNames.txt");
		string[] SATWeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\SATWeaponNames.txt");

		string[] namePrefixes = {"vm_","sat_vm_"};

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in SATWeaponNames)
		{
			using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

			Parallel.ForEach(namePrefixes, namePrefix =>
			{
				Parallel.ForEach(SATVMAnimationNames, animationName =>
				{
					string stringedName = namePrefix + weaponName + "_" + animationName;
					string generatedHash = CalcHash64_v1(stringedName);

					if(debugEnabled)
					{
						Console.WriteLine(stringedName);
					}

					Parallel.ForEach(SATAnimationAssetLog, hash =>
					{
						if(hash == generatedHash)
						{
							string output = generatedHash + "," + stringedName;

							lock(writeLock)
							{
								GeneratedAnimations.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
				});
			});

			GeneratedAnimations.Flush();
			GeneratedAnimations.Close();
		}
	}

	static void SATWMWeaponAnimations()
    {
        Console.WriteLine("Generating SAT WM Weapon Animations:\n");

		string[] SATAnimationAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Animations.txt");

		string[] SATWeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\SATWeaponNames.txt");
		string[] T10WMAnimations = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMAnimations.txt");
        string[] T10WMDetails = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMDetails.txt");
        string[] T10WMSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Animations\T10WMSuffixes.txt");
		string[] midFixes = File.ReadAllLines(@"cod-hash-tool-data\Animations\SATWMAttachments.txt");
		
        if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string midFix in midFixes)
		{
			foreach (string weaponName in SATWeaponNames)
			{
				using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

				foreach (string animation in T10WMAnimations)
				{
					foreach (string details in T10WMDetails)
					{
						foreach (string suffixType in T10WMSuffixes)
						{
							string stringedName = "sat_wm_" + weaponName + midFix + animation + details + suffixType;
							string generatedHash = CalcHash64_v1(stringedName);

							if (debugEnabled)
							{
								Console.WriteLine(stringedName);
							}

							Parallel.ForEach(SATAnimationAssetLog, hash =>
							{
								if(hash == generatedHash)
								{
									string output = generatedHash + "," + stringedName;

									lock(writeLock)
									{
										GeneratedAnimations.WriteLine(output);
										Console.WriteLine(output);
									}
								}
							});
						}
					}
				}

				GeneratedAnimations.Flush();
				GeneratedAnimations.Close();
			}
		}
    }

	static void AnimPackages()
    {
        string game = PickGame(0);

        Console.WriteLine("Unhashing Animpackage Names:\n");

        string[] Weapons = File.ReadAllLines(@"cod-hash-tool-data\Shared\WeaponNames.txt");
        string[] AnimPackages = Directory.GetFiles(@"cod-hash-tool-data\AnimPackages\" + game);
        string[] AnimPackageVariantNames = File.ReadAllLines(@"cod-hash-tool-data\AnimPackages\AnimPackageVariantNames.txt");

		string[] midfixes = {"_animpackage","_default_animpackage"};
		string[] games = {"sat","t10","iw9","jup"};

        Parallel.ForEach(AnimPackages, animpackage =>
        {
            if (animpackage.Contains(game + @"\0x"))
            {
				string animpackageHashed = animpackage.Substring(animpackage.LastIndexOf('\\') + 1);
				animpackageHashed = animpackageHashed.Replace("0x", "");
				animpackageHashed = animpackageHashed.Replace(".json", "");

                foreach (string weapon in Weapons)
                {
					foreach(string midfix in midfixes)
					{
						Parallel.ForEach(games, gameName =>
						{
							Parallel.ForEach(AnimPackageVariantNames, animpackageSuffix =>
							{
								string stringedName = gameName + "_" + weapon + midfix + animpackageSuffix;

								if (debugEnabled)
								{
									Console.WriteLine(stringedName + " | " + animpackageHashed);
								}

								if (CalcHash64_v1(stringedName) == animpackageHashed)
								{
									if (File.Exists(@"cod-hash-tool-data\AnimPackages\" + game + @"\0x" + animpackageHashed + ".json"))
									{
										Console.WriteLine(animpackageHashed + " | " + stringedName);
										File.Move(@"cod-hash-tool-data\AnimPackages\" + game + @"\0x" + animpackageHashed + ".json", @"cod-hash-tool-data\AnimPackages\" + game + @"\" + stringedName + ".json");
									}
								}
							});
						});
					}
                }
            }
        });
    }

	static void TexturesFromMaterialNamesLegacy()
    {
        Console.WriteLine("Generating Images from Materials:\n");

        string[] ImageAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Images.txt");
		string[] ImageAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Images.txt");

		var ImageAssetLog = ImageAssetLogT8.Union(ImageAssetLogT9).ToArray();

		string[] MaterialNamesT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\UnhashedMaterials.txt");
		string[] MaterialNamesT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\UnhashedMaterials.txt");

		var MaterialNames = MaterialNamesT8.Union(MaterialNamesT9).ToArray();

		string[] TextureTypes = File.ReadAllLines(@"cod-hash-tool-data\Images\TextureTypesLegacy.txt");

		if(!File.Exists("GeneratedImagesLegacy.txt"))
		{
			var file = File.Create("GeneratedImagesLegacy.txt");
			file.Close();
		}

        using StreamWriter GeneratedImagesLegacy = new StreamWriter("GeneratedImagesLegacy.txt", true);

        Parallel.ForEach(MaterialNames, materialName =>
        {
			materialName = materialName.Substring(materialName.IndexOf('/') + 1);
			materialName = materialName.Substring(materialName.IndexOf('\\') + 1);

            Parallel.ForEach(TextureTypes, textureType =>
            {
                string stringedName = materialName + "_" + textureType;
                string generatedHash = CalcHash64_v2(stringedName);

                if(debugEnabled)
                {
                    Console.WriteLine(stringedName);
                }

                Parallel.ForEach(ImageAssetLog, hash =>
                {
                    if(generatedHash == hash)
                    {
                        string output = generatedHash + "," + stringedName;

                        lock(writeLock)
						{
							GeneratedImagesLegacy.WriteLine(output);
							Console.WriteLine(output);
						}
                    }
                });
            });
        });

		GeneratedImagesLegacy.Flush();
		GeneratedImagesLegacy.Close();
    }

	static void TexturesFromMaterialNames()
    {
        Console.WriteLine("Generating Images from Materials:\n");

        string[] ImageAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Images.txt");
		string[] ImageAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Images.txt");
		string[] ImageAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Images.txt");
		string[] ImageAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Images.txt");

		var ImageAssetLog = ImageAssetLogIW9.Union(ImageAssetLogJUP).ToArray();
		ImageAssetLog = ImageAssetLog.Union(ImageAssetLogT10).ToArray();
		ImageAssetLog = ImageAssetLog.Union(ImageAssetLogSAT).ToArray();

		string[] MaterialNamesIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\UnhashedMaterials.txt");
		string[] MaterialNamesJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\UnhashedMaterials.txt");
		string[] MaterialNamesT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\UnhashedMaterials.txt");
		string[] MaterialNamesSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\UnhashedMaterials.txt");

		var MaterialNames = MaterialNamesIW9.Union(MaterialNamesJUP).ToArray();
		MaterialNames = MaterialNames.Union(MaterialNamesT10).ToArray();
		MaterialNames = MaterialNames.Union(MaterialNamesSAT).ToArray();

		string[] TextureTypes = File.ReadAllLines(@"cod-hash-tool-data\Images\TextureTypes.txt");

		if(!File.Exists("GeneratedImages.txt"))
		{
			var file = File.Create("GeneratedImages.txt");
			file.Close();
		}

        using StreamWriter GeneratedImages = new StreamWriter("GeneratedImages.txt", true);

        Parallel.ForEach(MaterialNames, materialName =>
        {
			materialName = materialName.Substring(materialName.IndexOf('/') + 1);
			materialName = materialName.Substring(materialName.IndexOf('\\') + 1);

            Parallel.ForEach(TextureTypes, textureType =>
            {
                string stringedName = materialName + "_" + textureType;
                string generatedHash = CalcHash64_v1(stringedName);

                if(debugEnabled)
                {
                    Console.WriteLine(stringedName);
                }

                Parallel.ForEach(ImageAssetLog, hash =>
                {
                    if(generatedHash == hash)
                    {
                        string output = generatedHash + "," + stringedName;

                        lock(writeLock)
						{
							GeneratedImages.WriteLine(output);
							Console.WriteLine(output);
						}
                    }
                });
            });
        });

		GeneratedImages.Flush();
		GeneratedImages.Close();
    }

	static void IW9WeaponMaterials()
    {
        Console.WriteLine("Generating IW9 Weapon Materials:\n");

		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Materials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Materials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		//string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogIW9.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		//MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

		string[] WeaponMaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\WeaponMaterialFolders.txt");
		string[] IW9WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\IW9WeaponNames.txt");
		string[] MaterialKeywords = File.ReadAllLines(@"cod-hash-tool-data\Materials\Keywords.txt");
		string[] IW9Numbers = File.ReadAllLines(@"cod-hash-tool-data\Materials\IW9Numbers.txt");

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

        foreach(string IW9Number in IW9Numbers)
        {
			using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

            Parallel.ForEach(MaterialKeywords, Keyword =>
            {
                Parallel.ForEach(IW9WeaponNames, IW9WeaponName =>
                {
                    Parallel.ForEach(WeaponMaterialFolders, MaterialFolder =>
                    {
                        string stringedName = MaterialFolder + "wpn_" + IW9WeaponName + "_" + Keyword + IW9Number;
                        string generatedHash = CalcHash64_v1(stringedName);

                        if (debugEnabled)
                        {
                            Console.WriteLine(stringedName);
                        }

                        Parallel.ForEach(MaterialAssetLog, hashedAsset =>
                        {
                            if (generatedHash == hashedAsset)
                            {
                                string output = generatedHash + "," + stringedName;

                                lock(writeLock)
								{
									GeneratedMaterials.WriteLine(output);
									Console.WriteLine(output);
								}
                            }
                        });
                    });
                });
            });

			GeneratedMaterials.Flush();
			GeneratedMaterials.Close();
        }
    }

	static void JUPWeaponMaterials()
    {
        Console.WriteLine("Generating JUP Weapon Materials:\n");

		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Materials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Materials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		//string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogIW9.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		//MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

		string[] WeaponMaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\WeaponMaterialFolders.txt");
		string[] JUPWeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\JUPWeaponNames.txt");
		string[] MaterialKeywords = File.ReadAllLines(@"cod-hash-tool-data\Materials\Keywords.txt");
		string[] JUPNumbers = File.ReadAllLines(@"cod-hash-tool-data\Materials\JUPNumbers.txt");
		string[] weaponPlatformPrefixes = {"c","j",""};

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

        foreach(string JUPNumber in JUPNumbers)
        {
			using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

            Parallel.ForEach(MaterialKeywords, Keyword =>
            {
                Parallel.ForEach(JUPWeaponNames, JUPWeaponName =>
                {
                    Parallel.ForEach(WeaponMaterialFolders, MaterialFolder =>
                    {
						foreach(string weaponPlatformPrefix in weaponPlatformPrefixes)
						{
							string stringedName = MaterialFolder + "mtl_jup_" + weaponPlatformPrefix + JUPWeaponName + "_" + Keyword + JUPNumber;
							string generatedHash = CalcHash64_v1(stringedName);

							if (debugEnabled)
							{
								Console.WriteLine(stringedName);
							}

							Parallel.ForEach(MaterialAssetLog, hashedAsset =>
							{
								if (generatedHash == hashedAsset)
								{
									string output = generatedHash + "," + stringedName;

									lock(writeLock)
									{
										GeneratedMaterials.WriteLine(output);
										Console.WriteLine(output);
									}
								}
							});
						}
                    });
                });
            });

			GeneratedMaterials.Flush();
			GeneratedMaterials.Close();
        }
    }

	static void T10WeaponMaterials()
    {
        Console.WriteLine("Generating T10 Weapon Materials:\n");

		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		//string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		//var MaterialAssetLog = MaterialAssetLogT10.Union(MaterialAssetLogSAT).ToArray();

		string[] WeaponMaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\WeaponMaterialFolders.txt");
		string[] T10WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\T10WeaponNames.txt");
		string[] MaterialKeywords = File.ReadAllLines(@"cod-hash-tool-data\Materials\Keywords.txt");
		string[] T10BlueprintNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\T10BlueprintNames.txt");
		string[] weaponMaterialPrefixes = {"mtl_att_t10_","mtl_wpn_t10_"};

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

        foreach(string T10BlueprintName in T10BlueprintNames)
        {
			using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

            Parallel.ForEach(MaterialKeywords, Keyword =>
            {
                Parallel.ForEach(T10WeaponNames, T10WeaponName =>
                {
                    Parallel.ForEach(WeaponMaterialFolders, MaterialFolder =>
                    {
						foreach(string weaponMaterialPrefix in weaponMaterialPrefixes)
						{
							string stringedName = MaterialFolder + weaponMaterialPrefix + T10WeaponName + "_" + Keyword + T10BlueprintName;
							string generatedHash = CalcHash64_v1(stringedName);

							if (debugEnabled)
							{
								Console.WriteLine(stringedName);
							}

							Parallel.ForEach(MaterialAssetLogT10, hashedAsset =>
							{
								if (generatedHash == hashedAsset)
								{
									string output = generatedHash + "," + stringedName;

									lock(writeLock)
									{
										GeneratedMaterials.WriteLine(output);
										Console.WriteLine(output);
									}
								}
							});
						}
                    });
                });
            });

			GeneratedMaterials.Flush();
			GeneratedMaterials.Close();
        }
    }

	static void SATWeaponMaterials()
    {
        Console.WriteLine("Generating SAT Weapon Materials:\n");

		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");

		string[] WeaponMaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\WeaponMaterialFolders.txt");
		string[] T10WeaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\SATWeaponNames.txt");
		string[] MaterialKeywords = File.ReadAllLines(@"cod-hash-tool-data\Materials\Keywords.txt");
		string[] SATBlueprintNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\SATBlueprintNames.txt");

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

		using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

        Parallel.ForEach(MaterialKeywords, Keyword =>
        {
            Parallel.ForEach(T10WeaponNames, T10WeaponName =>
            {
				Parallel.ForEach(SATBlueprintNames, Blueprint =>
                {
					Parallel.ForEach(WeaponMaterialFolders, MaterialFolder =>
					{
						string stringedName = MaterialFolder + "mtl_sat_" + T10WeaponName + "_" + Keyword + Blueprint;
						string generatedHash = CalcHash64_v1(stringedName);

						if (debugEnabled)
						{
							Console.WriteLine(stringedName);
						}

						Parallel.ForEach(MaterialAssetLogSAT, hashedAsset =>
						{
							if (generatedHash == hashedAsset)
							{
								string output = generatedHash + "," + stringedName;

								lock(writeLock)
								{
									GeneratedMaterials.WriteLine(output);
									Console.WriteLine(output);
								}
							}
						});
					});
				});
            });
        });

		GeneratedMaterials.Flush();
		GeneratedMaterials.Close();
	}

	static void LegacyModelsToMaterials()
    {
        Console.WriteLine("Generating Legacy Model Names to Materials:\n");

		string[] MaterialAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Materials.txt");
		string[] MaterialAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogT8.Union(MaterialAssetLogT9).ToArray();

		string[] ModelsT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\UnhashedModels.txt");
		string[] ModelsT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\UnhashedModels.txt");
		var Models = ModelsT8.Union(ModelsT9).ToArray();

		string[] Prefixes = {"mtl_",""};

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

		using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

        Parallel.ForEach(Prefixes, Prefix =>
        {
            Parallel.ForEach(Models, Model =>
            {
				string stringedName = Prefix + Model;
				string generatedHash = CalcHash64_v2(stringedName);

				if (debugEnabled)
				{
					Console.WriteLine(stringedName);
				}

				Parallel.ForEach(MaterialAssetLog, hashedAsset =>
				{
					if (generatedHash == hashedAsset)
					{
						string output = generatedHash + "," + stringedName;

						lock(writeLock)
						{
							GeneratedMaterials.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
            });
        });

		GeneratedMaterials.Flush();
		GeneratedMaterials.Close();
    }

	static void ModelsToMaterials()
    {
        Console.WriteLine("Generating Model Names to Materials:\n");

		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Materials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Materials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogIW9.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

		string[] ModelsIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\UnhashedModels.txt");
		string[] ModelsJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\UnhashedModels.txt");
		string[] ModelsT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\UnhashedModels.txt");
		string[] ModelsSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\UnhashedModels.txt");
		var Models = ModelsIW9.Union(ModelsJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(ModelsT10).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(ModelsSAT).ToArray();

		string[] Prefixes = {"mtl_",""};

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

		using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

        Parallel.ForEach(Prefixes, Prefix =>
        {
            Parallel.ForEach(Models, Model =>
            {
				string stringedName = Prefix + Model;
				string generatedHash = CalcHash64_v1(stringedName);

				if (debugEnabled)
				{
					Console.WriteLine(stringedName);
				}

				Parallel.ForEach(MaterialAssetLog, hashedAsset =>
				{
					if (generatedHash == hashedAsset)
					{
						string output = generatedHash + "," + stringedName;

						lock(writeLock)
						{
							GeneratedMaterials.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
            });
        });

		GeneratedMaterials.Flush();
		GeneratedMaterials.Close();
    }

	static void OperatorMaterials()
    {
        Console.WriteLine("Generating Operator Materials:\n");

		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogSAT.Union(MaterialAssetLogT10).ToArray();

		string[] MaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\MaterialFolderNames.txt");
		string[] MaterialKeywords = File.ReadAllLines(@"cod-hash-tool-data\Materials\OperatorKeywords.txt");

		string[] OperatorNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\OperatorNames.txt");

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

		using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

        Parallel.ForEach(MaterialKeywords, Keyword =>
        {
            Parallel.ForEach(OperatorNames, Operator =>
            {
				Parallel.ForEach(MaterialFolders, MaterialFolder =>
				{
					string stringedName = MaterialFolder + "c_" + Operator + "_" + Keyword;
					string generatedHash = CalcHash64_v1(stringedName);

					if (debugEnabled)
					{
						Console.WriteLine(stringedName);
					}

					Parallel.ForEach(MaterialAssetLog, hashedAsset =>
					{
						if (generatedHash == hashedAsset)
						{
							string output = generatedHash + "," + stringedName;

							lock(writeLock)
							{
								GeneratedMaterials.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
				});
            });
        });

		GeneratedMaterials.Flush();
		GeneratedMaterials.Close();
    }

	static void ScrapeMaterialEndings()
    {
        Console.WriteLine("Generating Material Endings:\n");

		string[] ModelAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\UnhashedModels.txt");
		string[] ModelAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\UnhashedModels.txt");
        string[] ModelAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\UnhashedModels.txt");
		string[] ModelAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\UnhashedModels.txt");
		string[] ModelAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\UnhashedModels.txt");
		string[] ModelAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\UnhashedModels.txt");

		var ModelAssetLog = ModelAssetLogT8.Union(ModelAssetLogT9).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogIW9).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogJUP).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogT10).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogSAT).ToArray();

		string[] MaterialAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\UnhashedMaterials.txt");
		string[] MaterialAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\UnhashedMaterials.txt");
		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\UnhashedMaterials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\UnhashedMaterials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\UnhashedMaterials.txt");
		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\UnhashedMaterials.txt");

		var MaterialAssetLog = MaterialAssetLogT8.Union(MaterialAssetLogT9).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogIW9).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

        if (!File.Exists(@"cod-hash-tool-data\Materials\MaterialEndings.txt"))
        {
            var file = File.Create(@"cod-hash-tool-data\Materials\MaterialEndings.txt");
            file.Close();
        }

        using StreamWriter GeneratedHashesMaterials = new StreamWriter(@"cod-hash-tool-data\Materials\MaterialEndings.txt", true);

        Parallel.ForEach(ModelAssetLog, model =>
        {
            Parallel.ForEach(MaterialAssetLog, material =>
            {
                if (material.Contains("/" + model + "_"))
                {
                    string stringedName = material;

                    if (material.Contains('/'))
                    {
                        stringedName = material.Substring(material.IndexOf('/') + 1);
                    }

					if (model.Contains('/'))
                    {
                        model = model.Substring(model.IndexOf('/') + 1);
                    }

					if (model.Contains("::"))
                    {
                        model = model.Substring(model.IndexOf("::") + 1);
                    }

                    string output = stringedName.Substring(model.Length);
                    output = output.Replace(model, "");
					output = output.Substring(1);

					if(debugEnabled)
					{
						Console.WriteLine(output);
					}

					lock(writeLock)
					{
						GeneratedHashesMaterials.WriteLine(output);
					}
                }
            });
        });

		GeneratedHashesMaterials.Flush();
		GeneratedHashesMaterials.Close();
    }

	static void MaterialEndingsToMaterials()
	{
		Console.WriteLine("Generating Model hashes from Material Endings:\n");

        string[] ModelAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\UnhashedModels.txt");
		string[] ModelAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\UnhashedModels.txt");
		string[] ModelAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\UnhashedModels.txt");
		string[] ModelAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\UnhashedModels.txt");

		var ModelAssetLog = ModelAssetLogIW9.Union(ModelAssetLogJUP).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogT10).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogSAT).ToArray();

		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Materials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Materials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");

		var MaterialAssetLog = MaterialAssetLogIW9.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

        string[] MaterialEndings = File.ReadAllLines(@"cod-hash-tool-data\Materials\MaterialEndings.txt");
        //string[] MaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\MaterialFolderNames.txt");
		string[] MaterialFolders = {"m/","mc/","mo/"};

		if (!File.Exists("GeneratedMaterials.txt"))
        {
            var file = File.Create("GeneratedMaterials.txt");
            file.Close();
        }

        foreach (string materialEnding in MaterialEndings)
        {
			Console.WriteLine(materialEnding);

            using StreamWriter GeneratedHashesMaterials = new StreamWriter("GeneratedMaterials.txt", true);

			Parallel.ForEach(MaterialFolders, materialFolder =>
			{
				Parallel.ForEach(ModelAssetLog, model =>
				{
					if (model.Contains('/'))
					{
						model = model.Substring(model.IndexOf('/') + 1);
					}

					if (model.Contains("::"))
					{
						model = model.Substring(model.IndexOf("::") + 1);
					}

					string stringedName = materialFolder + "mtl_" + model + "_" + materialEnding;
					string generatedHash = CalcHash64_v1(stringedName);

					if (debugEnabled)
					{
						Console.WriteLine(stringedName);
					}

					Parallel.ForEach(MaterialAssetLog, hashedAsset =>
					{
						if (generatedHash == hashedAsset)
						{
							string output = generatedHash + "," + stringedName;

							lock(writeLock)
							{
								GeneratedHashesMaterials.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
				});
			});

            GeneratedHashesMaterials.Flush();
            GeneratedHashesMaterials.Close();
		}
	}

	static void IW9WeaponSounds()
    {
        Console.WriteLine("Generating IW9 Weapon Sounds:\n");

        if (File.Exists("GeneratedSounds.txt") != true)
        {
            var file = File.Create("GeneratedSounds.txt");
            file.Close();
        }

        string[] SoundAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Sounds.txt");

        string[] WeaponSoundFolderPaths = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundFolderPathsIW9JUP.txt");
        string[] WeaponSoundCategories = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundCategoriesIW9JUP.txt");
        string[] WeaponSoundNames = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundNamesIW9JUP.txt");
        string[] WeaponSoundSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundSuffixesIW9.txt");

        foreach (string soundFolder in WeaponSoundFolderPaths)
        {
            if (soundFolder.Contains('*') == false)
            {
				using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

                Console.WriteLine("Current Folder: " + soundFolder);

                Parallel.ForEach(WeaponSoundCategories, soundCategory =>
                {
                    if (soundCategory.Contains('*') == false)
                    {
                        Parallel.ForEach(WeaponSoundNames, soundName =>
                        {
                            Parallel.ForEach(WeaponSoundSuffixes, weaponSoundSuffix =>
                            {
                                string stringedName = soundFolder + soundCategory + soundName;
                                string generatedHash = CalcHash64_v1(stringedName + weaponSoundSuffix);

                                if (debugEnabled)
                                {
                                    Console.WriteLine(stringedName + weaponSoundSuffix + " | " + generatedHash);
                                }

                                Parallel.ForEach(SoundAssetLog, hashedSound =>
                                {
                                    if (hashedSound == generatedHash)
                                    {
                                        stringedName = stringedName.Replace('.', '\\');

                                        string output = generatedHash + "," + stringedName + weaponSoundSuffix;

										lock(writeLock)
										{
											GeneratedSounds.WriteLine(output);
											Console.WriteLine(output);
										}
                                    }
                                });
                            });
                        });
                    }
                });

				GeneratedSounds.Flush();
				GeneratedSounds.Close();
            }
        }

    }

	static void JUPWeaponSounds()
    {
        Console.WriteLine("Generating JUP Weapon Sounds:\n");

        if (File.Exists("GeneratedSounds.txt") != true)
        {
            var file = File.Create("GeneratedSounds.txt");
            file.Close();
        }

        string[] SoundAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Sounds.txt");

        string[] WeaponSoundFolderPaths = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundFolderPathsIW9JUP.txt");
        string[] WeaponSoundCategories = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundCategoriesIW9JUP.txt");
        string[] WeaponSoundNames = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundNamesIW9JUP.txt");
        string[] WeaponSoundSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundSuffixesJUPT10SAT.txt");

        foreach (string soundFolder in WeaponSoundFolderPaths)
        {
            if (soundFolder.Contains('*') == false)
            {
				using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

                Console.WriteLine("Current Folder: " + soundFolder);

                Parallel.ForEach(WeaponSoundCategories, soundCategory =>
                {
                    if (soundCategory.Contains('*') == false)
                    {
                        Parallel.ForEach(WeaponSoundNames, soundName =>
                        {
                            Parallel.ForEach(WeaponSoundSuffixes, weaponSoundSuffix =>
                            {
                                string stringedName = soundFolder + soundCategory + soundName;
                                string generatedHash = CalcHash64_v1(stringedName + weaponSoundSuffix);

                                if (debugEnabled)
                                {
                                    Console.WriteLine(stringedName + weaponSoundSuffix + " | " + generatedHash);
                                }

                                Parallel.ForEach(SoundAssetLog, hashedSound =>
                                {
                                    if (hashedSound == generatedHash)
                                    {
                                        stringedName = stringedName.Replace('.', '\\');

                                        string output = generatedHash + "," + stringedName + weaponSoundSuffix;

										lock(writeLock)
										{
											GeneratedSounds.WriteLine(output);
											Console.WriteLine(output);
										}
                                    }
                                });
                            });
                        });
                    }
                });

				GeneratedSounds.Flush();
				GeneratedSounds.Close();
            }
        }

    }

	static void T10WeaponSounds()
    {
        Console.WriteLine("Generating T10 Weapon Sounds:\n");

        if (File.Exists("GeneratedSounds.txt") != true)
        {
            var file = File.Create("GeneratedSounds.txt");
            file.Close();
        }

        string[] SoundAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Sounds.txt");

        string[] WeaponSoundFolderPaths = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundFolderPathsT10.txt");
        string[] WeaponSoundCategories = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundCategoriesT10SAT.txt");
        string[] WeaponSoundNames = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundNamesT10SAT.txt");
        string[] WeaponSoundSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundSuffixesJUPT10SAT.txt");

        foreach (string soundFolder in WeaponSoundFolderPaths)
        {
            if (soundFolder.Contains('*') == false)
            {
				using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

                Console.WriteLine("Current Folder: " + soundFolder);

                Parallel.ForEach(WeaponSoundCategories, soundCategory =>
                {
                    if (soundCategory.Contains('*') == false)
                    {
                        Parallel.ForEach(WeaponSoundNames, soundName =>
                        {
                            Parallel.ForEach(WeaponSoundSuffixes, weaponSoundSuffix =>
                            {
                                string stringedName = soundFolder + soundCategory + soundName;
                                string generatedHash = CalcHash64_v1(stringedName + weaponSoundSuffix);

                                if (debugEnabled)
                                {
                                    Console.WriteLine(stringedName + weaponSoundSuffix + " | " + generatedHash);
                                }

                                Parallel.ForEach(SoundAssetLog, hashedSound =>
                                {
                                    if (hashedSound == generatedHash)
                                    {
                                        stringedName = stringedName.Replace('/', '\\');

                                        string output = generatedHash + "," + stringedName + weaponSoundSuffix;

										lock(writeLock)
										{
											GeneratedSounds.WriteLine(output);
											Console.WriteLine(output);
										}
                                    }
                                });
                            });
                        });
                    }
                });

				GeneratedSounds.Flush();
				GeneratedSounds.Close();
            }
        }

    }

	static void SATWeaponSounds()
    {
        Console.WriteLine("Generating SAT Weapon Sounds:\n");

        if (File.Exists("GeneratedSounds.txt") != true)
        {
            var file = File.Create("GeneratedSounds.txt");
            file.Close();
        }

        string[] SoundAssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Sounds.txt");

        string[] WeaponSoundFolderPaths = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundFolderPathsSAT.txt");
        string[] WeaponSoundCategories = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundCategoriesT10SAT.txt");
        string[] WeaponSoundNames = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundNamesT10SAT.txt");
        string[] WeaponSoundSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\WeaponSoundSuffixesJUPT10SAT.txt");

        foreach (string soundFolder in WeaponSoundFolderPaths)
        {
            if (soundFolder.Contains('*') == false)
            {
				using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

                Console.WriteLine("Current Folder: " + soundFolder);

                Parallel.ForEach(WeaponSoundCategories, soundCategory =>
                {
                    if (soundCategory.Contains('*') == false)
                    {
                        Parallel.ForEach(WeaponSoundNames, soundName =>
                        {
                            foreach(string weaponSoundSuffix in WeaponSoundSuffixes)
                            {
								if (weaponSoundSuffix.Contains('*') == false)
								{
									string stringedName = soundFolder + soundCategory + soundName;
									string generatedHash = CalcHash64_v1(stringedName + weaponSoundSuffix);

									if (debugEnabled)
									{
										Console.WriteLine(stringedName + weaponSoundSuffix + " | " + generatedHash);
									}

									Parallel.ForEach(SoundAssetLog, hashedSound =>
									{
										if (hashedSound == generatedHash)
										{
											stringedName = stringedName.Replace('/', '\\');

											string output = generatedHash + "," + stringedName + weaponSoundSuffix;

											lock(writeLock)
											{
												GeneratedSounds.WriteLine(output);
												Console.WriteLine(output);
											}
										}
									});
								}
                            }
                        });
                    }
                });

				GeneratedSounds.Flush();
				GeneratedSounds.Close();
            }
        }
    }

	static void Soundbanks()
    {
		string game = PickGame(0);
		game = game.ToLower();

        Console.WriteLine("Generating Soundbanks:\n");

		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\T10SndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\T10SndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\SATSndBank");
        
		string[] IW9Soundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Resident");
        string[] IW9SoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Transient");
        string[] JUPSoundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Resident");
        string[] JUPSoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Transient");
        string[] T10Soundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\T10SndBank\Resident");
        string[] T10SoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\T10SndBank\Transient");
		string[] SATSoundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\SATSndBank");

		var Soundbanks = IW9Soundbanks.Union(IW9SoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(JUPSoundbanks).ToArray();
		Soundbanks = Soundbanks.Union(JUPSoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(T10Soundbanks).ToArray();
		Soundbanks = Soundbanks.Union(T10SoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(SATSoundbanks).ToArray();
		 
		string[] SoundbankSuffixes = File.ReadAllLines(@"cod-hash-tool-data\SoundBanks\SoundbankSuffixes.txt");
		string[] weaponNames = File.ReadAllLines(@"cod-hash-tool-data\Shared\" + game + "WeaponNames.txt");

		if(!File.Exists("GeneratedSoundbanks.txt"))
		{
			var file = File.Create("GeneratedSoundbanks.txt");
			file.Close();
		}

		foreach(string weapon in weaponNames)
        {
			using StreamWriter GeneratedSoundbanks = new StreamWriter("GeneratedSoundbanks.txt", true);

            Parallel.ForEach(Soundbanks, soundbank =>
            {
                if(soundbank.Contains("0x"))
                {
                    Parallel.ForEach(SoundbankSuffixes, soundBankSuffix =>
                    {
						string soundbankPath = soundbank.Substring(0, soundbank.LastIndexOf('\\') + 1);

                        string soundbankHashed = soundbank.Substring(soundbank.LastIndexOf('\\') + 1);
                        soundbankHashed = soundbankHashed.Replace("0x","");
                        soundbankHashed = soundbankHashed.Replace(".json","");
                        string stringedName = "weapon_" + game + "_" + weapon + soundBankSuffix;

                        if(debugEnabled)
                        {
                            Console.WriteLine(stringedName + " | " + soundbankHashed);
                        }

                        if(CalcHash64_v1(stringedName) == soundbankHashed)
                        {
                            if(File.Exists(soundbankPath + "\\0x" + soundbankHashed + ".json"))
                            {
                                Console.WriteLine(soundbankHashed + " | " + stringedName);
                                File.Move(soundbankPath + "\\0x" + soundbankHashed + ".json", soundbankPath + "\\" + stringedName + ".json");

								string output = soundbankHashed + "," + stringedName;

								lock(writeLock)
								{
									GeneratedSoundbanks.WriteLine(output);
									Console.WriteLine(output);
								}
                            }
                        }
                    });
                }
            });

			GeneratedSoundbanks.Flush();
			GeneratedSoundbanks.Close();
        }
    }

	static void GenerateAnimationsLegacy()
    {
        Console.WriteLine("Generating Animations:\n");

		string[] AnimationAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Animations.txt");
		string[] AnimationAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Animations.txt");

		var AnimationAssetLog = AnimationAssetLogT8.Union(AnimationAssetLogT9).ToArray();

        string[] Animations = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Animations.txt");
		
		if(!File.Exists("GeneratedAnimationsLegacy.txt"))
        {
            var file = File.Create("GeneratedAnimationsLegacy.txt");
            file.Close();
        }

		using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimationsLegacy.txt", true);

        foreach(string animationName in Animations)
        {
            string generatedHash = CalcHash64_v2(animationName);

            Parallel.ForEach(AnimationAssetLog, hashedAnim =>
            {
                if(generatedHash == hashedAnim)
                {
                    string output = hashedAnim + "," + animationName;
                    
					lock(writeLock)
					{
						GeneratedAnimations.WriteLine(output);
						Console.WriteLine(output);
					}
                }
            });
        }

		GeneratedAnimations.Flush();
		GeneratedAnimations.Close();
    }

	static void GenerateAnimations()
    {
        Console.WriteLine("Generating Animations:\n");

		string[] AnimationAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Animations.txt");
		string[] AnimationAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Animations.txt");
		string[] AnimationAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Animations.txt");
		string[] AnimationAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Animations.txt");

		var AnimationAssetLog = AnimationAssetLogIW9.Union(AnimationAssetLogJUP).ToArray();
		AnimationAssetLog = AnimationAssetLog.Union(AnimationAssetLogT10).ToArray();
		AnimationAssetLog = AnimationAssetLog.Union(AnimationAssetLogSAT).ToArray();

        string[] Animations = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Animations.txt");
		
		if(!File.Exists("GeneratedAnimations.txt"))
        {
            var file = File.Create("GeneratedAnimations.txt");
            file.Close();
        }

		using StreamWriter GeneratedAnimations = new StreamWriter("GeneratedAnimations.txt", true);

        foreach(string animationName in Animations)
        {
            string generatedHash = CalcHash64_v1(animationName);

            Parallel.ForEach(AnimationAssetLog, hashedAnim =>
            {
                if(generatedHash == hashedAnim)
                {
                    string output = hashedAnim + "," + animationName;
                    
					lock(writeLock)
					{
						GeneratedAnimations.WriteLine(output);
						Console.WriteLine(output);
					}
                }
            });
        }

		GeneratedAnimations.Flush();
		GeneratedAnimations.Close();
    }

	static void GenerateImagesLegacy()
    {
        Console.WriteLine("Generating Images:\n");

		string[] ImageAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Images.txt");
		string[] ImageAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Images.txt");

		var ImageAssetLog = ImageAssetLogT8.Union(ImageAssetLogT9).ToArray();

        string[] Images = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Images.txt");
		
		if(!File.Exists("GeneratedImagesLegacy.txt"))
        {
            var file = File.Create("GeneratedImagesLegacy.txt");
            file.Close();
        }

		using StreamWriter GeneratedImages = new StreamWriter("GeneratedImagesLegacy.txt", true);

        foreach(string imageName in Images)
        {
            string generatedHash = CalcHash64_v2(imageName);

            Parallel.ForEach(ImageAssetLog, hashedAnim =>
            {
                if(generatedHash == hashedAnim)
                {
                    string output = hashedAnim + "," + imageName;
                    
					lock(writeLock)
					{
						GeneratedImages.WriteLine(output);
						Console.WriteLine(output);
					}
                }
            });
        }

		GeneratedImages.Flush();
		GeneratedImages.Close();
    }

	static void GenerateImages()
	{
		Console.WriteLine("Generating Images:\n");

		string[] ImageAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Images.txt");
		string[] ImageAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Images.txt");
		string[] ImageAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Images.txt");
		string[] ImageAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Images.txt");

		var ImageAssetLog = ImageAssetLogIW9.Union(ImageAssetLogJUP).ToArray();
		ImageAssetLog = ImageAssetLog.Union(ImageAssetLogT10).ToArray();
		ImageAssetLog = ImageAssetLog.Union(ImageAssetLogSAT).ToArray();

		string[] Images = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Images.txt");
	
		if(!File.Exists("GeneratedImages.txt"))
		{
			var file = File.Create("GeneratedImages.txt");
			file.Close();
		}

		using StreamWriter GeneratedImages = new StreamWriter("GeneratedImages.txt", true);

		foreach(string imageName in Images)
		{
			string generatedHash = CalcHash64_v1(imageName);

			Parallel.ForEach(ImageAssetLog, hashedAnim =>
			{
				if(generatedHash == hashedAnim)
				{
					string output = hashedAnim + "," + imageName;
                
					lock(writeLock)
					{
						GeneratedImages.WriteLine(output);
						Console.WriteLine(output);
					}
				}
			});
		}

		GeneratedImages.Flush();
		GeneratedImages.Close();
	}

	static void GenerateMaterialsLegacy()
	{
		Console.WriteLine("Generating Materials:\n");

		string[] MaterialAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Materials.txt");
		string[] MaterialAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogT8.Union(MaterialAssetLogT9).ToArray();

		string[] MaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\MaterialFolderNames.txt");
		string[] Materials = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Materials.txt");
	
		if(!File.Exists("GeneratedMaterialsLegacy.txt"))
		{
			var file = File.Create("GeneratedMaterialsLegacy.txt");
			file.Close();
		}

		foreach(string materialFolder in MaterialFolders)
		{
			using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterialsLegacy.txt", true);

			foreach(string materialName in Materials)
			{
				string stringedName = materialFolder + materialName;
				string generatedHash = CalcHash64_v2(stringedName);

				Parallel.ForEach(MaterialAssetLog, hashedAnim =>
				{
					if(generatedHash == hashedAnim)
					{
						string output = hashedAnim + "," + stringedName;
                
						lock(writeLock)
						{
							GeneratedMaterials.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			}

			GeneratedMaterials.Flush();
			GeneratedMaterials.Close();
		}
	}

	static void GenerateMaterials()
	{
		Console.WriteLine("Generating Materials:\n");

		string[] MaterialAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Materials.txt");
		string[] MaterialAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Materials.txt");
		string[] MaterialAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Materials.txt");
		string[] MaterialAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Materials.txt");
		var MaterialAssetLog = MaterialAssetLogIW9.Union(MaterialAssetLogJUP).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogT10).ToArray();
		MaterialAssetLog = MaterialAssetLog.Union(MaterialAssetLogSAT).ToArray();

		string[] MaterialFolders = File.ReadAllLines(@"cod-hash-tool-data\Materials\MaterialFolderNames.txt");
		string[] Materials = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Materials.txt");

		if(!File.Exists("GeneratedMaterials.txt"))
		{
			var file = File.Create("GeneratedMaterials.txt");
			file.Close();
		}

		foreach(string materialFolder in MaterialFolders)
		{
			using StreamWriter GeneratedMaterials = new StreamWriter("GeneratedMaterials.txt", true);

			foreach(string materialName in Materials)
			{
				string stringedName = materialFolder + materialName;
				string generatedHash = CalcHash64_v1(stringedName);

				Parallel.ForEach(MaterialAssetLog, hashedAnim =>
				{
					if(generatedHash == hashedAnim)
					{
						string output = hashedAnim + "," + stringedName;
            
						lock(writeLock)
						{
							GeneratedMaterials.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			}

			GeneratedMaterials.Flush();
			GeneratedMaterials.Close();
		}
	}

	static void GenerateModelsLegacy()
	{
		Console.WriteLine("Generating Models:\n");

		string[] ModelAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Models.txt");
		string[] ModelAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Models.txt");

		var ModelAssetLog = ModelAssetLogT8.Union(ModelAssetLogT9).ToArray();

		string[] Models = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Models.txt");
	
		if(!File.Exists("GeneratedModelsLegacy.txt"))
		{
			var file = File.Create("GeneratedModelsLegacy.txt");
			file.Close();
		}

		using StreamWriter GeneratedModels = new StreamWriter("GeneratedModelsLegacy.txt", true);

		foreach(string modelName in Models)
		{
			string generatedHash = CalcHash64_v2(modelName);

			Parallel.ForEach(ModelAssetLog, hashedAnim =>
			{
				if(generatedHash == hashedAnim)
				{
					string output = hashedAnim + "," + modelName;
                
					lock(writeLock)
					{
						GeneratedModels.WriteLine(output);
						Console.WriteLine(output);
					}
				}
			});
		}

		GeneratedModels.Flush();
		GeneratedModels.Close();
	}

	static void GenerateModels()
	{
		Console.WriteLine("Generating Models:\n");

		string[] ModelAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Models.txt");
		string[] ModelAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Models.txt");
		string[] ModelAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Models.txt");
		string[] ModelAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Models.txt");

		var ModelAssetLog = ModelAssetLogIW9.Union(ModelAssetLogJUP).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogT10).ToArray();
		ModelAssetLog = ModelAssetLog.Union(ModelAssetLogSAT).ToArray();

		string[] Models = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Models.txt");

		if(!File.Exists("GeneratedModels.txt"))
		{
			var file = File.Create("GeneratedModels.txt");
			file.Close();
		}

		using StreamWriter GeneratedModels = new StreamWriter("GeneratedModels.txt", true);

		foreach(string modelName in Models)
		{
			string generatedHash = CalcHash64_v1(modelName);

			Parallel.ForEach(ModelAssetLog, hashedAnim =>
			{
				if(generatedHash == hashedAnim)
				{
					string output = hashedAnim + "," + modelName;
            
					lock(writeLock)
					{
						GeneratedModels.WriteLine(output);
						Console.WriteLine(output);
					}
				}
			});
		}

		GeneratedModels.Flush();
		GeneratedModels.Close();
	}

	static void GenerateSoundsLegacy()
	{
		Console.WriteLine("Generating Sounds:\n");

		string[] SoundAssetLogT8 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T8\Sounds.txt");
		string[] SoundAssetLogT9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T9\Sounds.txt");

		var SoundAssetLog = SoundAssetLogT8.Union(SoundAssetLogT9).ToArray();

		string[] Sounds = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Sounds.txt");
		string[] Suffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\SoundSuffixes.txt");
	
		if(!File.Exists("GeneratedSoundsLegacy.txt"))
		{
			var file = File.Create("GeneratedSoundsLegacy.txt");
			file.Close();
		}

		using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSoundsLegacy.txt", true);

		foreach(string soundName in Sounds)
		{
			foreach(string soundSuffix in Suffixes)
			{
				string stringedName = soundName + soundSuffix;
				string generatedHash = CalcHash64_v2(stringedName);

				Parallel.ForEach(SoundAssetLog, hashedAnim =>
				{
					if(generatedHash == hashedAnim)
					{
						string output = hashedAnim + "," + stringedName;
            
						lock(writeLock)
						{
							GeneratedSounds.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			}
		}

		GeneratedSounds.Flush();
		GeneratedSounds.Close();
	}

	static void GenerateSounds()
	{
		Console.WriteLine("Generating Sounds:\n");

		string[] SoundAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Sounds.txt");
		string[] SoundAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Sounds.txt");
		string[] SoundAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Sounds.txt");
		string[] SoundAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Sounds.txt");

		var SoundAssetLog = SoundAssetLogIW9.Union(SoundAssetLogJUP).ToArray();
		SoundAssetLog = SoundAssetLog.Union(SoundAssetLogT10).ToArray();
		SoundAssetLog = SoundAssetLog.Union(SoundAssetLogSAT).ToArray();

		string[] Sounds = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Sounds.txt");
		string[] Suffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\SoundSuffixes.txt");

		if(!File.Exists("GeneratedSounds.txt"))
		{
			var file = File.Create("GeneratedSounds.txt");
			file.Close();
		}

		using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

		foreach(string soundName in Sounds)
		{
			foreach(string soundSuffix in Suffixes)
			{
				string stringedName = soundName + soundSuffix;
				string generatedHash = CalcHash64_v1(stringedName);

				Parallel.ForEach(SoundAssetLog, hashedAnim =>
				{
					if(generatedHash == hashedAnim)
					{
						string output = hashedAnim + "," + stringedName;
            
						lock(writeLock)
						{
							GeneratedSounds.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			}
		}

		GeneratedSounds.Flush();
		GeneratedSounds.Close();
	}

	static void GenerateSoundbanks()
    {
        Console.WriteLine("Generating Soundbanks:\n");

		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\T10SndBank\Resident");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\T10SndBank\Transient");
		Directory.CreateDirectory(@"cod-hash-tool-data\SoundBanks\SATSndBank");
        
		string[] IW9Soundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Resident");
        string[] IW9SoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\IW9SndBank\Transient");
        string[] JUPSoundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Resident");
        string[] JUPSoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\JUPSndBank\Transient");
        string[] T10Soundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\T10SndBank\Resident");
        string[] T10SoundbanksTR = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\T10SndBank\Transient");
		string[] SATSoundbanks = Directory.GetFiles(@"cod-hash-tool-data\SoundBanks\SATSndBank");

		var Soundbanks = IW9Soundbanks.Union(IW9SoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(JUPSoundbanks).ToArray();
		Soundbanks = Soundbanks.Union(JUPSoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(T10Soundbanks).ToArray();
		Soundbanks = Soundbanks.Union(T10SoundbanksTR).ToArray();
		Soundbanks = Soundbanks.Union(SATSoundbanks).ToArray();
		 
        string[] SoundbankNames = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Soundbanks.txt");
		string[] SoundbankSuffixes = File.ReadAllLines(@"cod-hash-tool-data\SoundBanks\SoundbankSuffixes.txt");

		if(!File.Exists("GeneratedSoundbanks.txt"))
		{
			var file = File.Create("GeneratedSoundbanks.txt");
			file.Close();
		}

		foreach(string soundbankName in SoundbankNames)
        {
			using StreamWriter GeneratedSoundbanks = new StreamWriter("GeneratedSoundbanks.txt", true);

            Parallel.ForEach(Soundbanks, soundbank =>
            {
                if(soundbank.Contains("ent\\0x"))
                {
                    Parallel.ForEach(SoundbankSuffixes, soundBankSuffix =>
                    {
						string soundbankPath = soundbank.Substring(0, soundbank.LastIndexOf('\\') + 1);

                        string soundbankHashed = soundbank.Substring(soundbank.LastIndexOf('\\') + 1);
                        soundbankHashed = soundbankHashed.Replace("0x","");
                        soundbankHashed = soundbankHashed.Replace(".csv","");
                        string stringedName = soundbankName + soundBankSuffix;

                        if(debugEnabled)
                        {
                            Console.WriteLine(stringedName + " | " + soundbankHashed);
                        }

                        if(CalcHash64_v1(stringedName) == soundbankHashed)
                        {
                            if(File.Exists(soundbankPath + "\\0x" + soundbankHashed + ".csv"))
                            {
                                Console.WriteLine(soundbankHashed + " | " + stringedName);
                                File.Move(soundbankPath + "\\0x" + soundbankHashed + ".csv", soundbankPath + "\\" + stringedName + ".csv");

								string output = soundbankHashed + "," + stringedName;

								lock(writeLock)
								{
									GeneratedSoundbanks.WriteLine(output);
									Console.WriteLine(output);
								}
                            }
                        }
                    });
                }
            });

			GeneratedSoundbanks.Flush();
			GeneratedSoundbanks.Close();
        }
    }

	static void GenerateAnimpackages()
    {
        Console.WriteLine("Generating Anim Packages:\n");

		Directory.CreateDirectory(@"cod-hash-tool-data\AnimPackages\IW9AnimPkg");
		Directory.CreateDirectory(@"cod-hash-tool-data\AnimPackages\JUPAnimPkg");
		Directory.CreateDirectory(@"cod-hash-tool-data\AnimPackages\T10AnimPkg");

		string[] IW9AnimPackages = Directory.GetFiles(@"cod-hash-tool-data\AnimPackages\IW9AnimPkg");
        string[] JUPAnimPackages = Directory.GetFiles(@"cod-hash-tool-data\AnimPackages\JUPAnimPkg");
        string[] T10AnimPackages = Directory.GetFiles(@"cod-hash-tool-data\AnimPackages\T10AnimPkg");

		var AnimPackages = IW9AnimPackages.Union(JUPAnimPackages).ToArray();
		AnimPackages = AnimPackages.Union(T10AnimPackages).ToArray();

        string[] AnimPackageNames = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\AnimPackages.txt");

		if(!File.Exists("GeneratedAnimpackages.txt"))
		{
			var file = File.Create("GeneratedAnimpackages.txt");
			file.Close();
		}

        foreach(string animpackageName in AnimPackageNames)
        {
			using StreamWriter GeneratedAnimpackages = new StreamWriter("GeneratedAnimpackages.txt", true);

            Parallel.ForEach(AnimPackages, animpackage =>
            {
                if(animpackage.Contains("AnimPkg\\0x"))
                {
					string animpackagePath = animpackage.Substring(0, animpackage.LastIndexOf('\\') + 1);

                    string animpackageHashed =  animpackage.Substring(animpackage.LastIndexOf('\\') + 1);
                    animpackageHashed = animpackageHashed.Replace("0x","");
                    animpackageHashed = animpackageHashed.Replace(".json","");

                    if(debugEnabled)
                    {
                        Console.WriteLine(animpackageName + " | " + animpackageHashed);
                    }

                    if(CalcHash64_v1(animpackageName) == animpackageHashed)
                    {
                        if(File.Exists(animpackagePath + "\\0x" + animpackageHashed + ".json"))
                        {
                            Console.WriteLine(animpackageHashed + " | " + animpackageName);
                            File.Move(animpackagePath + "\\0x" + animpackageHashed + ".json", animpackagePath + "\\" + animpackageName + ".json");

							string output = animpackageHashed + "," + animpackageName;

							lock(writeLock)
							{
								GeneratedAnimpackages.WriteLine(output);
								Console.WriteLine(output);
							}
                        }
                    }
                }
            });

			GeneratedAnimpackages.Flush();
			GeneratedAnimpackages.Close();
        }
    }

	static void GenerateBones()
    {
        Console.WriteLine("Generating Bones:\n");

		string[] SATBones = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Bones.txt");
        string[] BoneNames = File.ReadAllLines(@"cod-hash-tool-data\FoundAssetNames\Bones.txt");

		if(!File.Exists("GeneratedBones.txt"))
		{
			var file = File.Create("GeneratedBones.txt");
			file.Close();
		}

        foreach(string boneName in BoneNames)
        {
			using StreamWriter GeneratedBones = new StreamWriter("GeneratedBones.txt", true);

			Parallel.ForEach(SATBones, SATBone =>
			{
				string stringedName = boneName.Replace("bone_","");

				if(debugEnabled)
				{
					Console.WriteLine(SATBone + " | " + stringedName);
				}

				if(CalcHash64_v3(stringedName) == SATBone)
				{
					string output = SATBone + "," + stringedName;

					lock(writeLock)
					{
						GeneratedBones.WriteLine(output);
						Console.WriteLine(output);
					}
				}
			});

			GeneratedBones.Flush();
			GeneratedBones.Close();
        }
    }

	static void SplitAssetLogs()
    {
        string game = PickGame(0);

        string[] AssetLog = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\" + game + "\\AssetsLog.txt");

		AssetLog = AssetLog.Distinct().ToArray();

        using StreamWriter AnimationAssetLog = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\Animations.txt");
        using StreamWriter AnimationAssetLogUnhashed = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\UnhashedAnimations.txt");

        using StreamWriter ImageAssetLog = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\Images.txt");
        using StreamWriter ImageAssetLogUnhashed = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\UnhashedImages.txt");

        using StreamWriter MaterialAssetLog = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\Materials.txt");
        using StreamWriter MaterialAssetLogUnhashed = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\UnhashedMaterials.txt");

        using StreamWriter ModelAssetLog = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\Models.txt");
        using StreamWriter ModelAssetLogUnhashed = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\UnhashedModels.txt");

        using StreamWriter SoundAssetLog = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\Sounds.txt");
        using StreamWriter SoundAssetLogUnhashed = new StreamWriter(@"cod-hash-tool-data\AssetLogs\" + game + "\\UnhashedSounds.txt");

        foreach(string hash in AssetLog)
        {
            string assetType = hash.Substring(0, hash.IndexOf(','));
            string result = "";

            switch (assetType)
            {
                case "Animation":
                {
                    if (hash.Contains("Animation,anim_"))
                    {
                        //Hashed Animations
                        result = hash.Replace("Animation,anim_", "");
                        AnimationAssetLog.WriteLine(result);
                    }
                    else
                    {
                        //Unhashed Animations
                        result = hash.Replace("Animation,", "");
                        AnimationAssetLogUnhashed.WriteLine(result);
                    }

                    break;
                }
                case "Image":
                {
                    if (hash.Contains("Image,image_"))
                    {
                        //Hashed Images
                        result = hash.Replace("Image,image_", "");
                        ImageAssetLog.WriteLine(result);
                    }
                    else
                    {
                        //Unhashed Images
                        result = hash.Replace("Image,", "");
                        ImageAssetLogUnhashed.WriteLine(result);
                    }

                    break;
                }
                case "Material":
                {
                    if (hash.Contains("Material,material_"))
                    {
                        //Hashed Materials
                        result = hash.Replace("Material,material_", "");
                        MaterialAssetLog.WriteLine(result);
                    }
                    else
                    {
                        //Unhashed Materials
                        result = hash.Replace("Material,", "");
                        MaterialAssetLogUnhashed.WriteLine(result);
                    }

                    break;
                }
                case "Model":
                {
                    if (hash.Contains("Model,model_"))
                    {
                        //Hashed Models
                        result = hash.Replace("Model,model_", "");
                        ModelAssetLog.WriteLine(result);
                    }
                    else
                    {
                        //Unhashed Models
                        result = hash.Replace("Model,", "");
                        ModelAssetLogUnhashed.WriteLine(result);
                    }

                    break;
                }
                case "Sound":
                {
                    if (hash.Contains("Sound,sound_"))
                    {
                        //Hashed Sounds
                        result = hash.Replace("Sound,sound_", "");
                        SoundAssetLog.WriteLine(result);
                    }
                    else
                    {
                        //Unhashed Sounds
                        result = hash.Replace("Sound,", "");
                        SoundAssetLogUnhashed.WriteLine(result);
                    }

                    break;
                }
			}
        }
    }

	 static void SoundGuesser()
    {
        Console.WriteLine("Enter a sound path up to the suffix to guess a sound name, type 'Quit' to exit:\n");

		string[] SoundAssetLogIW9 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\IW9\Sounds.txt");
		string[] SoundAssetLogJUP = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\JUP\Sounds.txt");
		string[] SoundAssetLogT10 = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\T10\Sounds.txt");
		string[] SoundAssetLogSAT = File.ReadAllLines(@"cod-hash-tool-data\AssetLogs\SAT\Sounds.txt");

		var SoundAssetLog = SoundAssetLogIW9.Union(SoundAssetLogJUP).ToArray();
		SoundAssetLog = SoundAssetLog.Union(SoundAssetLogT10).ToArray();
		SoundAssetLog = SoundAssetLog.Union(SoundAssetLogSAT).ToArray();

		string[] SoundSuffixes = File.ReadAllLines(@"cod-hash-tool-data\Sounds\SoundSuffixes.txt");

        if(File.Exists("GeneratedSounds.txt") != true)
        {
            var file = File.Create("GeneratedSounds.txt");
            file.Close();
        }

        for(;;)
        {
            string? userResponse = Console.ReadLine();

            using StreamWriter GeneratedSounds = new StreamWriter("GeneratedSounds.txt", true);

            if(userResponse != null && userResponse.ToLower() == "quit")
            {
                break;
            }
            else if(userResponse != null)
            {
                Parallel.ForEach(SoundSuffixes, suffix =>
                {
                    string stringedName = userResponse + suffix;
                    string generatedHash = CalcHash64_v1(stringedName);

                    Parallel.ForEach(SoundAssetLog, hashedSound =>
                    {
                        if(hashedSound == generatedHash)
                        {
                            string swappedSybmols = userResponse.Replace('.','\\');
                            string output = generatedHash + "," + swappedSybmols + suffix;

                            lock(writeLock)
							{
								GeneratedSounds.WriteLine(output);
								Console.WriteLine(output);
							}
                        }
                    });
                });
            }

            GeneratedSounds.Flush();
			GeneratedSounds.Close();
        }
    }

	static void AnimScanner()
	{
		Directory.CreateDirectory(@"cod-hash-tool-data\Animations\AnimScanner\AnimationsToScan");
		Directory.CreateDirectory(@"cod-hash-tool-data\Animations\AnimScanner\FoundAnimations");

		string[] animsToScan = Directory.GetFiles(@"cod-hash-tool-data\Animations\AnimScanner\AnimationsToScan");
		string[] bonesToFind = File.ReadAllLines(@"cod-hash-tool-data\Animations\AnimScanner\BoneNames.txt");

		foreach(string bone in bonesToFind)
		{
			Parallel.ForEach(animsToScan, anim =>
			{
				string text = File.ReadAllText(anim);

				if(text.Contains(bone))
				{
					string animName = anim.Substring(anim.LastIndexOf('\\') + 1);
					
					lock(writeLock)
					{
						if(File.Exists(anim))
						{
							File.Copy(anim, @"cod-hash-tool-data\Animations\AnimScanner\FoundAnimations\" + animName);
						}
					}
				}
			});
		}
	}

	static void Hasher()
	{
		for(;;)
		{
			Console.WriteLine("Enter an asset name to hash, enter 'Quit' to exit: ");
			
			string? userInput = Console.ReadLine();

			if(userInput != null)
			{
				if(userInput.ToLower() == "quit")
				{
					break;
				}

				Console.Write(userInput + " | Legacy = " + CalcHash64_v2(userInput) + "\n");
				Console.Write(userInput + " | Current = " + CalcHash64_v1(userInput) + "\n");
				Console.Write(userInput + " | Legacy Bone = " + CalcHash32(userInput) + "\n");
				Console.Write(userInput + " | Current Bone = " + CalcHash64_v3(userInput) + "\n");
			}
		}
	}
}
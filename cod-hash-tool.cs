using System;
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

					112 - WM Weapon Animations (IW9)

					113 - VM Weapon Animations (JUP)

					114 - WM Weapon Animations (JUP)

					115 - VM Weapon Animations (T10)

					116 - WM Weapon Animations (T10)

				12 - FXAnims from Model Names

					121 - 32bit Hash Games (T8/T9)

					122 - 64bit Hash Games (IW9/JUP/T10/SAT)

			2 - Animation Packages

				21 - Animation Package Names
	
					211 - Animation Package Names (IW9/JUP)

					212 - Animation Package Names (T10)
			
			3 - Images

				31 - Textures from Material Names

					311 - Textures from Material Names (T8/T9)

					312 - Textures from Material Names (IW9/JUP/T10)

			4 - Materials

				41 - Weapon Materials
	
					411 - Weapon Materials (T8)

					412 - Weapon Materials (T9)

					413 - Weapon Materials (IW9)

					414 - Weapon Materials (JUP)

					415 - Weapon Materials (T10)

				42 - Model Name to Material Name

					421 - Model Name to Material Name (T8/T9)

					422 - Model Name to Material Name (IW9/JUP/T10)

				48 - Scrape Material Endings

				49 - Get Model Materials from Material Endings

			5 - Models

			6 - Sounds

				61 - Weapon Sounds

					611 - Weapon Sounds (IW9)

					612 - Weapon Sounds (JUP)

					613 - Weapon Sounds (T10)

			7 - Soundbanks

				71 - Soundbank Names

				72 - Manual Soundbank Naming

				73 - Soundbank Aliases

			8 - Generate Found Hashes

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

				84 - Generate Sounds

					841 - Generate Sounds (T8/T9)

					842 - Generate Sounds (IW9/JUP/T10)

				86 - Generate Soundbanks

				87 - Generate Animation Packages

				88 - Generate Bones

			9 - Miscellanious

				91 - Split AssetLogs

				92 - Asset Exports

				93 - Speaker JSONS

				94 - Grab Sounds

				98 - Hasher

				99 - Toggle Debug Printing
			");

			Console.WriteLine("\nDebug = " + (debugEnabled.ToString()).ToUpper());

			string? userOption = Console.ReadLine();

			if (userOption != null)
			{
				if(userOption.ToUpper() == "QUIT")
				{ 
					break;
				}

				string[] userOptions = userOption.Split(',');

				Console.Clear();

				foreach (string option in userOptions)
				{
					switch (option)
					{
						case "111":
						{
							IW9VMWeaponAnimations();

							break;
						}
						case "112":
						{
							JUPVMWeaponAnimations();

							break;
						}
						case "113":
						{
							T10VMWeaponAnimations();

							break;
						}
						case "114":
						{
							T10WMWeaponAnimations();

							break;
						}
						case "91":
						{
							SplitAssetLogs();

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
            Console.WriteLine("Legacy, IW9, JUP or T10?\n");

            string? userResponse = Console.ReadLine();

			if(userResponse != null)
			{
				userResponse = userResponse.ToUpper();

				switch (userResponse)
				{
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
					case "LEGACY":
					case "BO4":
					case "BOCW":
					case "T8":
					case "T9":
					{
						return "LEGACY";
					}
				}
			}
        }
    }

	static void IW9VMWeaponAnimations()
	{
		Console.WriteLine("Generating IW9 VM Weapon Animations:\n");

		string[] IW9AnimationAssetLog = File.ReadAllLines(@"Data\AssetLogs\IW9\Animations.txt");

		string[] IW9VMAnimationNames = File.ReadAllLines(@"Data\Animations\VMAnimationNames.txt");
		string[] IW9WeaponNames = File.ReadAllLines(@"Data\Shared\IW9WeaponNames.txt");

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in IW9WeaponNames)
		{
			using StreamWriter GeneratedHashesAnimations = new StreamWriter("GeneratedAnimations.txt", true);

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
							GeneratedHashesAnimations.WriteLine(output);
							Console.WriteLine(output);
						}
					}
				});
			});

			GeneratedHashesAnimations.Flush();
			GeneratedHashesAnimations.Close();
		}
	}

	static void JUPVMWeaponAnimations()
	{
		Console.WriteLine("Generating JUP VM Weapon Animations:\n");

		string[] JUPAnimationAssetLog = File.ReadAllLines(@"Data\AssetLogs\JUP\Animations.txt");

		string[] JUPVMAnimationNames = File.ReadAllLines(@"Data\Animations\VMAnimationNames.txt");
		string[] JUPWeaponNames = File.ReadAllLines(@"Data\Shared\JUPWeaponNames.txt");

		string[] namePrefixes = {"vm_","jup_vm_"};
		string[] weaponPlatformPrefixes = {"c","j",""};

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in JUPWeaponNames)
		{
			using StreamWriter GeneratedHashesAnimations = new StreamWriter("GeneratedAnimations.txt", true);

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
									GeneratedHashesAnimations.WriteLine(output);
									Console.WriteLine(output);
								}
							}
						});
					});
				});
			});

			GeneratedHashesAnimations.Flush();
			GeneratedHashesAnimations.Close();
		}
	}

	static void T10VMWeaponAnimations()
	{
		Console.WriteLine("Generating T10 VM Weapon Animations:\n");

		string[] T10AnimationAssetLog = File.ReadAllLines(@"Data\AssetLogs\T10\Animations.txt");

		string[] T10VMAnimationNames = File.ReadAllLines(@"Data\Animations\VMAnimationNames.txt");
		string[] T10WeaponNames = File.ReadAllLines(@"Data\Shared\T10WeaponNames.txt");

		string[] namePrefixes = {"vm_","t10_vm_"};
		string[] weaponPlatformPrefixes = {"c","j",""};

		if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

		foreach(string weaponName in T10WeaponNames)
		{
			using StreamWriter GeneratedHashesAnimations = new StreamWriter("GeneratedAnimations.txt", true);

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
								GeneratedHashesAnimations.WriteLine(output);
								Console.WriteLine(output);
							}
						}
					});
				});
			});

			GeneratedHashesAnimations.Flush();
			GeneratedHashesAnimations.Close();
		}
	}

	static void T10WMWeaponAnimations()
    {
        Console.WriteLine("Generating T10 WM Weapon Animations:\n");

		string[] T10AnimationAssetLog = File.ReadAllLines(@"Data\AssetLogs\T10\Animations.txt");

		string[] T10WeaponNames = File.ReadAllLines(@"Data\Shared\T10WeaponNames.txt");
		string[] T10WMNames = File.ReadAllLines(@"Data\Animations\T10WMNames.txt");
		string[] T10WMAnimations = File.ReadAllLines(@"Data\Animations\T10WMAnimations.txt");
        string[] T10WMDetails = File.ReadAllLines(@"Data\Animations\T10WMDetails.txt");
        string[] T10WMSuffixes = File.ReadAllLines(@"Data\Animations\T10WMSuffixes.txt");
		

        if(!File.Exists("GeneratedAnimations.txt"))
		{
			var file = File.Create("GeneratedAnimations.txt");
			file.Close();
		}

        foreach (string weaponName in T10WeaponNames)
        {
            using StreamWriter GeneratedHashesAnimations = new StreamWriter("GeneratedAnimations.txt", true);

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
										GeneratedHashesAnimations.WriteLine(output);
										Console.WriteLine(output);
									}
								}
							});
						}
                    }
                }
            }

            GeneratedHashesAnimations.Flush();
            GeneratedHashesAnimations.Close();
        }
    }

	static void SplitAssetLogs()
    {
        string game = PickGame(0);

        string[] AssetLog = File.ReadAllLines(@"Data\AssetLogs\" + game + "\\AssetsLog.txt");

        using StreamWriter AnimationAssetLog = new StreamWriter(@"Data\AssetLogs\" + game + "\\Animations.txt");
        using StreamWriter AnimationAssetLogUnhashed = new StreamWriter(@"Data\AssetLogs\" + game + "\\UnhashedAnimations.txt");

        using StreamWriter ImageAssetLog = new StreamWriter(@"Data\AssetLogs\" + game + "\\Images.txt");
        using StreamWriter ImageAssetLogUnhashed = new StreamWriter(@"Data\AssetLogs\" + game + "\\UnhashedImages.txt");

        using StreamWriter MaterialAssetLog = new StreamWriter(@"Data\AssetLogs\" + game + "\\Materials.txt");
        using StreamWriter MaterialAssetLogUnhashed = new StreamWriter(@"Data\AssetLogs\" + game + "\\UnhashedMaterials.txt");

        using StreamWriter ModelAssetLog = new StreamWriter(@"Data\AssetLogs\" + game + "\\Models.txt");
        using StreamWriter ModelAssetLogUnhashed = new StreamWriter(@"Data\AssetLogs\" + game + "\\UnhashedModels.txt");

        using StreamWriter SoundAssetLog = new StreamWriter(@"Data\AssetLogs\" + game + "\\Sounds.txt");
        using StreamWriter SoundAssetLogUnhashed = new StreamWriter(@"Data\AssetLogs\" + game + "\\UnhashedSounds.txt");

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
}
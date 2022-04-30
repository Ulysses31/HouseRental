using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
	public static class ApplicationDbContextSeed
	{
		public static async Task SeedDefaultUserAsync(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager
		)
		{
			var administratorRole = new IdentityRole("Administrator");

			if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
			{
				await roleManager.CreateAsync(administratorRole);
			}

			var administrator = new ApplicationUser
			{
				UserName = "administrator@localhost",
				Email = "administrator@localhost",
			};

			if (userManager.Users.All(u => u.UserName != administrator.UserName))
			{
				await userManager.CreateAsync(administrator, "Administrator1!");
				await userManager.AddToRolesAsync(
					administrator,
					new[] {
						administratorRole.Name
					}
				);
			}
		}

		public static async Task SeedSampleDataAsync(ApplicationDbContext context)
		{
			// Seed, if necessary
			if (!context.Classifieds.Any())
			{
				// Classified Purpose
				context.ClassifiedPurposes.AddRange(
					new ClassifiedPurpose()
					{
						Title = "Πώληση",
						Description = "Προς πώληση"
					},
					new ClassifiedPurpose()
					{
						Title = "Ενοικίαση",
						Description = "Προς ενοικίαση"
					}
				);

				// Classified Type
				context.ClassifiedTypes.AddRange(
					new ClassifiedType()
					{
						Title = "Κατοικία",
						Description = "Κατοικία"
					},
					new ClassifiedType()
					{
						Title = "Επαγγελματικός χόρος",
						Description = "Επαγγελματικός χόρος"
					},
					new ClassifiedType()
					{
						Title = "Γη",
						Description = "Γη"
					},
					new ClassifiedType()
					{
						Title = "Νεόδμητη κατοικία",
						Description = "Νεόδμητη κατοικία"
					},
					new ClassifiedType()
					{
						Title = "Φοιτητικά",
						Description = "Φοιτητικά"
					}
				);

				// Energy Class
				context.EnergyClasses.AddRange(
					new EnergyClass()
					{
						EnergyClassValue = "Α <33%",
						Description = "Ενεργιακή κλάση Α <33%"
					},
					new EnergyClass()
					{
						EnergyClassValue = "Β 75%-100%",
						Description = "Ενεργιακή κλάση Β 75%-100%"
					},
					new EnergyClass()
					{
						EnergyClassValue = "Γ 100%-141%",
						Description = "Ενεργιακή κλάση Γ 100%-141%"
					},
					new EnergyClass()
					{
						EnergyClassValue = "Δ 141%-182%",
						Description = "Ενεργιακή κλάση Δ 141%-182%"
					},
					new EnergyClass()
					{
						EnergyClassValue = "Το ΠΕΑ είναι υπό έκδοση",
						Description = "Ενεργιακή κλάση το ΠΕΑ είναι υπό έκδοση"
					}
				);

				// Floor Number
				context.FloorNos.AddRange(
					new FloorNo()
					{
						FloorNoValue = "ΥΠ",
						Description = "Υπόγειο"
					},
					new FloorNo()
					{
						FloorNoValue = "HM-ΥΠ",
						Description = "Ημιυπόγειο"
					},
					new FloorNo()
					{
						FloorNoValue = "ΙΣ",
						Description = "Ισόγειο"
					},
					new FloorNo()
					{
						FloorNoValue = "ΗΜ",
						Description = "Ημιόροφος"
					},
					new FloorNo()
					{
						FloorNoValue = "1ος",
						Description = "1ος όροφος"
					},
					new FloorNo()
					{
						FloorNoValue = "2ος",
						Description = "2ος όροφος"
					},
					new FloorNo()
					{
						FloorNoValue = "3ος",
						Description = "3ος όροφος"
					},
					new FloorNo()
					{
						FloorNoValue = "4ος",
						Description = "4ος όροφος"
					},
					new FloorNo()
					{
						FloorNoValue = "5ος",
						Description = "5ος όροφος"
					}
				);

				// Floor Type
				context.FloorTypes.AddRange(
					new FloorType()
					{
						Title = "Ξύλινο",
						Description = "Ξύλινο δάπεδο"
					},
					new FloorType()
					{
						Title = "Μαρμάρινο",
						Description = "Μαρμάρινο δάπεδο"
					},
					new FloorType()
					{
						Title = "Γρανίτη",
						Description = "Δάπεδο με γρανίτη"
					},
					new FloorType()
					{
						Title = "Πλακάκια",
						Description = "Δάπεδο με πλακάκια"
					},
					new FloorType()
					{
						Title = "Laminate",
						Description = "Δάπεδο Laminate"
					},
					new FloorType()
					{
						Title = "Μοκέτα",
						Description = "Δάπεδο με μοκέτα"
					}
				);

				// Frame Type
				context.FrameTypes.AddRange(
					new FrameType()
					{
						Title = "Αλουμινίου",
						Description = "Κουφώματα αλουμινίου"
					},
					new FrameType()
					{
						Title = "Συνθετικά",
						Description = "Κουφώματα συνθετικά ή PVC"
					},
					new FrameType()
					{
						Title = "Ξύλινα",
						Description = "Ξύλινα κουφώματα"
					}
				);

				// Power Type
				context.PowerTypes.AddRange(
					new PowerType()
					{
						Title = "Μονοφασικό",
						Description = "Μονοφασικό ρεύμα"
					},
					new PowerType()
					{
						Title = "Τριφασικό",
						Description = "Τριφασικό ρεύμα"
					}
				);

				// Heating Type
				context.HeatingTypes.AddRange(
					new HeatingType()
					{
						HeatingTypeValue = "Αδιάφορο",
						Description = "Χωρίς κριτήρια"
					},
					new HeatingType()
					{
						HeatingTypeValue = "Αυτόνομη θέρμανση",
						Description = "Θέρμανση με αυτόνομη θέρμανση"
					},
					new HeatingType()
					{
						HeatingTypeValue = "Κεντρική Θέρμανση",
						Description = "Θέρμανση με κεντρική θέρμανση"
					},
					new HeatingType()
					{
						HeatingTypeValue = "Χωρίς θέρμανση",
						Description = "Χωρίς θέρμανση"
					}
				);

				// Heating System
				context.HeatingSystems.AddRange(
					new HeatingSystem()
					{
						HeatingSystemValue = "Αδιάφορο",
						Description = "Χωρίς κριτήρια"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Πετρέλαιο",
						Description = "Μέσο θέρμανσης με πετρέλαιο"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Φυσικό αέριο",
						Description = "Μέσο θέρμανσης με φυσικό αέριο"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Υγραέριο",
						Description = "Μέσο θέρμανσης με υγραέριο"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Ρεύμα",
						Description = "Μέσο θέρμανσης με ρεύμα"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Θερμοσυσσωρευτές",
						Description = "Μέσο θέρμανσης με θερμοσυσσωρευτές"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Σόμπα",
						Description = "Μέσο θέρμανσης με σόμπα"
					},
					new HeatingSystem()
					{
						HeatingSystemValue = "Pellet",
						Description = "Μέσο θέρμανσης με pellet"
					}
				);

				await context.SaveChangesAsync();

				// Classifieds
				context.Classifieds.Add(
					new Classified()
					{
						IsEnabled = true,
						PurposeID = 2,
						TypeID = 1,
						FloorNoID = 6,
						ClassifiedTitle = "Διαμέρισμα, 75τ.μ.",
						ClassifiedDesription = "Ενοικιάζεται ΑΝΑΚΑΙΝΙΣΜΕΝΟ διαμέρισμα 75 τ.μ. στον ημιόροφο 1Δ.ΣΚ.ΜΠ.στην Χαριλάου.Ατομική θέρμανση φυσικού αερίου,θωρακισμένη πόρτα, θερμοηχομονωτικά κουφώματα με διπλά τζάμια και ανάκλειση, συναγερμό, ανακαινισμένη κουζίνα και μπάνιο, κλιματιστικό.",
						SuitableFor = new SuitableFor()
						{
							StudentUse = false,
							HolidayHomeUse = false,
							ProfessionalUse = false,
							InvestmentUse = false,
							TouristRentalUse = false,
							Description = "Κατάλληλο για χρήση"
						},
						ClassifiedConstruction = new ClassifiedConstruction()
						{
							PentHouse = false,
							NewlyBuilt = false,
							Renovated = true,
							NeedsToBeRenovated = false,
							NeoClassical = false,
							Preserved = false,
							Description = "Κατασκευή"
						},
						ClassifiedCharacteristics = new ClassifiedCharacteristics()
						{
							Price = 490,
							PricePerTm = 6.53,
							AreaTm = 75,
							Region = "Τούμπα, Άνω Τούμπα",
							Cuisines = 1,
							Bathrooms = 1,
							Bedrooms = 2,
							HeatingTypeID = 2,
							HeatingSystemID = 3,
							EnergyClassID = 5,
							ContructionYear = 2004,
							Lounges = 1,
							MonthlyShared = 35,
							YearOfRenovation = 2020,
							SystemCode = "11738366",
							PropertyCode = "1-48432",
							AvailableFrom = new System.DateTime(2022, 05, 01),
							PublicationOfAdvert = System.DateTime.Now,
							Description = "Διαμέρισμα, 75τ.μ."
						},
						ExteriorFeature = new ExteriorFeature()
						{
							PropertyView = true,
							Facade = true,
							Orientation = "Ανατολικό",
							ResidentialZone = true,
							ParkingSpot = true,
							Awnings = true,
							Garden = false,
							DisabledAccess = true,
							Pool = false,
							Corner = false,
							Veranda = true,
							WithinCityPlan = true,
							Description = "Εξωτερικά χαρακτηριστικά"
						},
						InteriorFeature = new InteriorFeature()
						{
							Elevator = true,
							InternalStaircase = false,
							AirConditioning = true,
							Warehouse = true,
							PetsWelcome = true,
							SecurityDoor = true,
							DoubleGlazing = true,
							Furnished = false,
							Fireplace = false,
							UnderfloorHeating = false,
							SolarHeating = false,
							NightCurrent = false,
							Garret = false,
							Playroom = false,
							SatelliteAntenna = false,
							Alarm = false,
							DoorScreens = false,
							Airy = true,
							Painted = true,
							WithEquipment = false,
							CableTV = false,
							Wiring = false,
							LoadingUnloadingElevator = false,
							SuspendedCeiling = false,
							FloorTypeID = 2,
							FrameTypeID = 1,
							PowerTypeID = 1,
							Description = "Εσωτερικός εξοπλισμός"
						},
						GoogleMapPlace = new GoogleMapPlace()
						{
							Area = "Τούμπα, Κάτω Τούμπα",
							Latitude = "0.0000",
							Longitude = "0.0000",
							Description = "Το ακίνητο στο Google maps"
						},
						AdvertiserInfo = new AdvertiserInfo()
						{
							Code = "Olymp",
							Name = "OLYMPUS real estate agency",
							Address = "ΜΙΚΡΑΣ ΑΣΙΑΣ 13-15, Κέντρο Θεσσαλονίκης",
							Email = "info@olympus.gr",
							Telephone = "2310-999888",
							Responsible = "Πολυμεράς Βαγγέλης",
							Website = "http://www.olympusrealestate.gr/"
						}
					}
				);

				await context.SaveChangesAsync();
			}
		}
	}
}
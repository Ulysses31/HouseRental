using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.EnsureSchema(
					name: "dbo");

			migrationBuilder.CreateTable(
					name: "AdvertiserInfo",
					schema: "dbo",
					columns: table => new
					{
						AdvertiserInfoID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
						Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						Responsible = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
						Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
						Website = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AdvertiserInfo", x => x.AdvertiserInfoID);
					});

			migrationBuilder.CreateTable(
					name: "AspNetRoles",
					columns: table => new
					{
						Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
						Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetRoles", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "AspNetUsers",
					columns: table => new
					{
						Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
						UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
						EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
						PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
						SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
						ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
						PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
						PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
						TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
						LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
						LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
						AccessFailedCount = table.Column<int>(type: "int", nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetUsers", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "ClassifiedConstruction",
					schema: "dbo",
					columns: table => new
					{
						ClassifiedConstructionID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						PentHouse = table.Column<bool>(type: "bit", nullable: false),
						NewlyBuilt = table.Column<bool>(type: "bit", nullable: false),
						Renovated = table.Column<bool>(type: "bit", nullable: false),
						NeedsToBeRenovated = table.Column<bool>(type: "bit", nullable: false),
						NeoClassical = table.Column<bool>(type: "bit", nullable: false),
						Preserved = table.Column<bool>(type: "bit", nullable: false),
						Incomplete = table.Column<bool>(type: "bit", nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ClassifiedConstruction", x => x.ClassifiedConstructionID);
					});

			migrationBuilder.CreateTable(
					name: "ClassifiedPurpose",
					schema: "dbo",
					columns: table => new
					{
						PurposeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ClassifiedPurpose", x => x.PurposeID);
					});

			migrationBuilder.CreateTable(
					name: "ClassifiedType",
					schema: "dbo",
					columns: table => new
					{
						TypeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ClassifiedType", x => x.TypeID);
					});

			migrationBuilder.CreateTable(
					name: "DeviceCodes",
					columns: table => new
					{
						UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
						DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
						SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
						SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
						ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
						Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
						CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
						Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
						Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
					});

			migrationBuilder.CreateTable(
					name: "EnergyClass",
					schema: "dbo",
					columns: table => new
					{
						EnergyClassID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						EnergyClassValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_EnergyClass", x => x.EnergyClassID);
					});

			migrationBuilder.CreateTable(
					name: "ExteriorFeature",
					schema: "dbo",
					columns: table => new
					{
						ExteriorFeaturesID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						PropertyView = table.Column<bool>(type: "bit", nullable: false),
						Facade = table.Column<bool>(type: "bit", nullable: false),
						Orientation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						AccessFrom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Άσφαλτο"),
						ResidentialZone = table.Column<bool>(type: "bit", nullable: false),
						ParkingSpot = table.Column<bool>(type: "bit", nullable: false),
						Awnings = table.Column<bool>(type: "bit", nullable: false),
						Garden = table.Column<bool>(type: "bit", nullable: false),
						DisabledAccess = table.Column<bool>(type: "bit", nullable: false),
						Pool = table.Column<bool>(type: "bit", nullable: false),
						Corner = table.Column<bool>(type: "bit", nullable: false),
						Veranda = table.Column<bool>(type: "bit", nullable: false),
						ShowcaseGlassLength = table.Column<int>(type: "int", nullable: true),
						UnloadingRamp = table.Column<bool>(type: "bit", nullable: true),
						WithinCityPlan = table.Column<bool>(type: "bit", nullable: false),
						StructureFactor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ExteriorFeature", x => x.ExteriorFeaturesID);
					});

			migrationBuilder.CreateTable(
					name: "FloorNo",
					schema: "dbo",
					columns: table => new
					{
						FloorNoID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						FloorNoValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FloorNo", x => x.FloorNoID);
					});

			migrationBuilder.CreateTable(
					name: "FloorType",
					schema: "dbo",
					columns: table => new
					{
						FloorTypeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FloorType", x => x.FloorTypeID);
					});

			migrationBuilder.CreateTable(
					name: "FrameType",
					schema: "dbo",
					columns: table => new
					{
						FrameTypeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_FrameType", x => x.FrameTypeID);
					});

			migrationBuilder.CreateTable(
					name: "GoogleMapPlace",
					schema: "dbo",
					columns: table => new
					{
						GoogleMapPlaceID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Area = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
						Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_GoogleMapPlace", x => x.GoogleMapPlaceID);
					});

			migrationBuilder.CreateTable(
					name: "HeatingSystem",
					schema: "dbo",
					columns: table => new
					{
						HeatingSystemID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						HeatingSystemValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_HeatingSystem", x => x.HeatingSystemID);
					});

			migrationBuilder.CreateTable(
					name: "HeatingType",
					schema: "dbo",
					columns: table => new
					{
						HeatingTypeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						HeatingTypeValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_HeatingType", x => x.HeatingTypeID);
					});

			migrationBuilder.CreateTable(
					name: "PersistedGrants",
					columns: table => new
					{
						Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
						Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
						SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
						SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
						ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
						Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
						CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
						Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
						ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
						Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_PersistedGrants", x => x.Key);
					});

			migrationBuilder.CreateTable(
					name: "PowerSupplyType",
					schema: "dbo",
					columns: table => new
					{
						PowerTypeID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_PowerSupplyType", x => x.PowerTypeID);
					});

			migrationBuilder.CreateTable(
					name: "SuitableFor",
					schema: "dbo",
					columns: table => new
					{
						SuitableForID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						StudentUse = table.Column<bool>(type: "bit", nullable: false),
						HolidayHomeUse = table.Column<bool>(type: "bit", nullable: false),
						ProfessionalUse = table.Column<bool>(type: "bit", nullable: false),
						InvestmentUse = table.Column<bool>(type: "bit", nullable: false),
						TouristRentalUse = table.Column<bool>(type: "bit", nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_SuitableFor", x => x.SuitableForID);
					});

			migrationBuilder.CreateTable(
					name: "AspNetRoleClaims",
					columns: table => new
					{
						Id = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
						ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
						ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
						table.ForeignKey(
											name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
											column: x => x.RoleId,
											principalTable: "AspNetRoles",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "AspNetUserClaims",
					columns: table => new
					{
						Id = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
						ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
						ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
						table.ForeignKey(
											name: "FK_AspNetUserClaims_AspNetUsers_UserId",
											column: x => x.UserId,
											principalTable: "AspNetUsers",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "AspNetUserLogins",
					columns: table => new
					{
						LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
						ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
						ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
						UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
						table.ForeignKey(
											name: "FK_AspNetUserLogins_AspNetUsers_UserId",
											column: x => x.UserId,
											principalTable: "AspNetUsers",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "AspNetUserRoles",
					columns: table => new
					{
						UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
						RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
						table.ForeignKey(
											name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
											column: x => x.RoleId,
											principalTable: "AspNetRoles",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_AspNetUserRoles_AspNetUsers_UserId",
											column: x => x.UserId,
											principalTable: "AspNetUsers",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "AspNetUserTokens",
					columns: table => new
					{
						UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
						LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
						Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
						Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
						table.ForeignKey(
											name: "FK_AspNetUserTokens_AspNetUsers_UserId",
											column: x => x.UserId,
											principalTable: "AspNetUsers",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "ClassifiedCharacteristics",
					schema: "dbo",
					columns: table => new
					{
						CharacteristicsID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
						PricePerTm = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
						AreaTm = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						LandAreaTm = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Levels = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Square = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						Cuisines = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Bathrooms = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Bedrooms = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						HeatingTypeID = table.Column<int>(type: "int", nullable: false),
						HeatingSystemID = table.Column<int>(type: "int", nullable: false),
						EnergyClassID = table.Column<int>(type: "int", nullable: false),
						ContructionYear = table.Column<int>(type: "int", nullable: false),
						LandArea = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						Lounges = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						MonthlyShared = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						DistanceFromSea = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						YearOfRenovation = table.Column<int>(type: "int", nullable: false),
						BuildingCoefficient = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
						SystemCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						PropertyCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						AvailableFrom = table.Column<DateTime>(type: "datetime", nullable: true),
						PublicationOfAdvert = table.Column<DateTime>(type: "datetime", nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ClassifiedCharacteristics", x => x.CharacteristicsID);
						table.ForeignKey(
											name: "FK_ClassifiedCharacteristics_EnergyClass_EnergyClassID",
											column: x => x.EnergyClassID,
											principalSchema: "dbo",
											principalTable: "EnergyClass",
											principalColumn: "EnergyClassID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_ClassifiedCharacteristics_HeatingSystem_HeatingSystemID",
											column: x => x.HeatingSystemID,
											principalSchema: "dbo",
											principalTable: "HeatingSystem",
											principalColumn: "HeatingSystemID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_ClassifiedCharacteristics_HeatingType_HeatingTypeID",
											column: x => x.HeatingTypeID,
											principalSchema: "dbo",
											principalTable: "HeatingType",
											principalColumn: "HeatingTypeID",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "InteriorFeature",
					schema: "dbo",
					columns: table => new
					{
						InteriorFeaturesID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Elevator = table.Column<bool>(type: "bit", nullable: false),
						InternalStaircase = table.Column<bool>(type: "bit", nullable: false),
						AirConditioning = table.Column<bool>(type: "bit", nullable: false),
						Warehouse = table.Column<bool>(type: "bit", nullable: false),
						FloorTypeID = table.Column<int>(type: "int", nullable: false),
						PetsWelcome = table.Column<bool>(type: "bit", nullable: false),
						SecurityDoor = table.Column<bool>(type: "bit", nullable: false),
						FrameTypeID = table.Column<int>(type: "int", nullable: false),
						PowerTypeID = table.Column<int>(type: "int", nullable: false),
						DoubleGlazing = table.Column<bool>(type: "bit", nullable: false),
						Furnished = table.Column<bool>(type: "bit", nullable: false),
						Fireplace = table.Column<bool>(type: "bit", nullable: false),
						UnderfloorHeating = table.Column<bool>(type: "bit", nullable: false),
						SolarHeating = table.Column<bool>(type: "bit", nullable: false),
						NightCurrent = table.Column<bool>(type: "bit", nullable: false),
						Garret = table.Column<bool>(type: "bit", nullable: false),
						Playroom = table.Column<bool>(type: "bit", nullable: false),
						SatelliteAntenna = table.Column<bool>(type: "bit", nullable: false),
						Alarm = table.Column<bool>(type: "bit", nullable: false),
						DoorScreens = table.Column<bool>(type: "bit", nullable: false),
						Airy = table.Column<bool>(type: "bit", nullable: false),
						Painted = table.Column<bool>(type: "bit", nullable: false),
						WithEquipment = table.Column<bool>(type: "bit", nullable: false),
						CableTV = table.Column<bool>(type: "bit", nullable: false),
						Wiring = table.Column<bool>(type: "bit", nullable: false),
						LoadingUnloadingElevator = table.Column<bool>(type: "bit", nullable: false),
						SuspendedCeiling = table.Column<bool>(type: "bit", nullable: false),
						Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_InteriorFeature", x => x.InteriorFeaturesID);
						table.ForeignKey(
											name: "FK_InteriorFeature_FloorType_FloorTypeID",
											column: x => x.FloorTypeID,
											principalSchema: "dbo",
											principalTable: "FloorType",
											principalColumn: "FloorTypeID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_InteriorFeature_FrameType_FrameTypeID",
											column: x => x.FrameTypeID,
											principalSchema: "dbo",
											principalTable: "FrameType",
											principalColumn: "FrameTypeID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_InteriorFeature_PowerSupplyType_PowerTypeID",
											column: x => x.PowerTypeID,
											principalSchema: "dbo",
											principalTable: "PowerSupplyType",
											principalColumn: "PowerTypeID",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "Classified",
					schema: "dbo",
					columns: table => new
					{
						ClassifiedID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						PurposeID = table.Column<int>(type: "int", nullable: false),
						TypeID = table.Column<int>(type: "int", nullable: false),
						GoogleMapPlaceID = table.Column<int>(type: "int", nullable: false),
						AdvertiserInfoID = table.Column<int>(type: "int", nullable: false),
						SuitableForID = table.Column<int>(type: "int", nullable: false),
						ClassifiedConstructionID = table.Column<int>(type: "int", nullable: false),
						ExteriorFeaturesID = table.Column<int>(type: "int", nullable: false),
						InteriorFeaturesID = table.Column<int>(type: "int", nullable: false),
						FloorNoID = table.Column<int>(type: "int", nullable: false),
						CharacteristicsID = table.Column<int>(type: "int", nullable: false),
						ClassifiedTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						ClassifiedDesription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Classified", x => x.ClassifiedID);
						table.ForeignKey(
											name: "FK_Classified_AdvertiserInfo_AdvertiserInfoID",
											column: x => x.AdvertiserInfoID,
											principalSchema: "dbo",
											principalTable: "AdvertiserInfo",
											principalColumn: "AdvertiserInfoID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_ClassifiedCharacteristics_CharacteristicsID",
											column: x => x.CharacteristicsID,
											principalSchema: "dbo",
											principalTable: "ClassifiedCharacteristics",
											principalColumn: "CharacteristicsID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_ClassifiedConstruction_ClassifiedConstructionID",
											column: x => x.ClassifiedConstructionID,
											principalSchema: "dbo",
											principalTable: "ClassifiedConstruction",
											principalColumn: "ClassifiedConstructionID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_ClassifiedPurpose_PurposeID",
											column: x => x.PurposeID,
											principalSchema: "dbo",
											principalTable: "ClassifiedPurpose",
											principalColumn: "PurposeID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_ClassifiedType_TypeID",
											column: x => x.TypeID,
											principalSchema: "dbo",
											principalTable: "ClassifiedType",
											principalColumn: "TypeID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_ExteriorFeature_ExteriorFeaturesID",
											column: x => x.ExteriorFeaturesID,
											principalSchema: "dbo",
											principalTable: "ExteriorFeature",
											principalColumn: "ExteriorFeaturesID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_FloorNo_FloorNoID",
											column: x => x.FloorNoID,
											principalSchema: "dbo",
											principalTable: "FloorNo",
											principalColumn: "FloorNoID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_GoogleMapPlace_GoogleMapPlaceID",
											column: x => x.GoogleMapPlaceID,
											principalSchema: "dbo",
											principalTable: "GoogleMapPlace",
											principalColumn: "GoogleMapPlaceID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_InteriorFeature_InteriorFeaturesID",
											column: x => x.InteriorFeaturesID,
											principalSchema: "dbo",
											principalTable: "InteriorFeature",
											principalColumn: "InteriorFeaturesID",
											onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
											name: "FK_Classified_SuitableFor_SuitableForID",
											column: x => x.SuitableForID,
											principalSchema: "dbo",
											principalTable: "SuitableFor",
											principalColumn: "SuitableForID",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "Photos",
					schema: "dbo",
					columns: table => new
					{
						PhotoID = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						ClassifiedID = table.Column<int>(type: "int", nullable: false),
						FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
						FileSize = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
						FileContent = table.Column<byte[]>(type: "varbinary", nullable: false),
						IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
						IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
						Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
						Created = table.Column<DateTime>(type: "datetime", nullable: false),
						CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
						LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
						LastModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Photos", x => x.PhotoID);
						table.ForeignKey(
											name: "FK_Photos_Classified_ClassifiedID",
											column: x => x.ClassifiedID,
											principalSchema: "dbo",
											principalTable: "Classified",
											principalColumn: "ClassifiedID",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateIndex(
					name: "IX_AspNetRoleClaims_RoleId",
					table: "AspNetRoleClaims",
					column: "RoleId");

			migrationBuilder.CreateIndex(
					name: "RoleNameIndex",
					table: "AspNetRoles",
					column: "NormalizedName",
					unique: true,
					filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_AspNetUserClaims_UserId",
					table: "AspNetUserClaims",
					column: "UserId");

			migrationBuilder.CreateIndex(
					name: "IX_AspNetUserLogins_UserId",
					table: "AspNetUserLogins",
					column: "UserId");

			migrationBuilder.CreateIndex(
					name: "IX_AspNetUserRoles_RoleId",
					table: "AspNetUserRoles",
					column: "RoleId");

			migrationBuilder.CreateIndex(
					name: "EmailIndex",
					table: "AspNetUsers",
					column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
					name: "UserNameIndex",
					table: "AspNetUsers",
					column: "NormalizedUserName",
					unique: true,
					filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
					name: "IX_Classified_AdvertiserInfoID",
					schema: "dbo",
					table: "Classified",
					column: "AdvertiserInfoID");

			migrationBuilder.CreateIndex(
					name: "IX_Classified_CharacteristicsID",
					schema: "dbo",
					table: "Classified",
					column: "CharacteristicsID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_ClassifiedConstructionID",
					schema: "dbo",
					table: "Classified",
					column: "ClassifiedConstructionID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_ExteriorFeaturesID",
					schema: "dbo",
					table: "Classified",
					column: "ExteriorFeaturesID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_FloorNoID",
					schema: "dbo",
					table: "Classified",
					column: "FloorNoID");

			migrationBuilder.CreateIndex(
					name: "IX_Classified_GoogleMapPlaceID",
					schema: "dbo",
					table: "Classified",
					column: "GoogleMapPlaceID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_InteriorFeaturesID",
					schema: "dbo",
					table: "Classified",
					column: "InteriorFeaturesID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_PurposeID",
					schema: "dbo",
					table: "Classified",
					column: "PurposeID");

			migrationBuilder.CreateIndex(
					name: "IX_Classified_SuitableForID",
					schema: "dbo",
					table: "Classified",
					column: "SuitableForID",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Classified_TypeID",
					schema: "dbo",
					table: "Classified",
					column: "TypeID");

			migrationBuilder.CreateIndex(
					name: "IX_ClassifiedCharacteristics_EnergyClassID",
					schema: "dbo",
					table: "ClassifiedCharacteristics",
					column: "EnergyClassID");

			migrationBuilder.CreateIndex(
					name: "IX_ClassifiedCharacteristics_HeatingSystemID",
					schema: "dbo",
					table: "ClassifiedCharacteristics",
					column: "HeatingSystemID");

			migrationBuilder.CreateIndex(
					name: "IX_ClassifiedCharacteristics_HeatingTypeID",
					schema: "dbo",
					table: "ClassifiedCharacteristics",
					column: "HeatingTypeID");

			migrationBuilder.CreateIndex(
					name: "IX_DeviceCodes_DeviceCode",
					table: "DeviceCodes",
					column: "DeviceCode",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_DeviceCodes_Expiration",
					table: "DeviceCodes",
					column: "Expiration");

			migrationBuilder.CreateIndex(
					name: "IX_InteriorFeature_FloorTypeID",
					schema: "dbo",
					table: "InteriorFeature",
					column: "FloorTypeID");

			migrationBuilder.CreateIndex(
					name: "IX_InteriorFeature_FrameTypeID",
					schema: "dbo",
					table: "InteriorFeature",
					column: "FrameTypeID");

			migrationBuilder.CreateIndex(
					name: "IX_InteriorFeature_PowerTypeID",
					schema: "dbo",
					table: "InteriorFeature",
					column: "PowerTypeID");

			migrationBuilder.CreateIndex(
					name: "IX_PersistedGrants_Expiration",
					table: "PersistedGrants",
					column: "Expiration");

			migrationBuilder.CreateIndex(
					name: "IX_PersistedGrants_SubjectId_ClientId_Type",
					table: "PersistedGrants",
					columns: new[] { "SubjectId", "ClientId", "Type" });

			migrationBuilder.CreateIndex(
					name: "IX_PersistedGrants_SubjectId_SessionId_Type",
					table: "PersistedGrants",
					columns: new[] { "SubjectId", "SessionId", "Type" });

			migrationBuilder.CreateIndex(
					name: "IX_Photos_ClassifiedID",
					schema: "dbo",
					table: "Photos",
					column: "ClassifiedID");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
					name: "AspNetUserClaims");

			migrationBuilder.DropTable(
					name: "AspNetUserLogins");

			migrationBuilder.DropTable(
					name: "AspNetUserRoles");

			migrationBuilder.DropTable(
					name: "AspNetUserTokens");

			migrationBuilder.DropTable(
					name: "DeviceCodes");

			migrationBuilder.DropTable(
					name: "PersistedGrants");

			migrationBuilder.DropTable(
					name: "Photos",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "AspNetRoles");

			migrationBuilder.DropTable(
					name: "AspNetUsers");

			migrationBuilder.DropTable(
					name: "Classified",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "AdvertiserInfo",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "ClassifiedCharacteristics",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "ClassifiedConstruction",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "ClassifiedPurpose",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "ClassifiedType",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "ExteriorFeature",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "FloorNo",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "GoogleMapPlace",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "InteriorFeature",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "SuitableFor",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "EnergyClass",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "HeatingSystem",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "HeatingType",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "FloorType",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "FrameType",
					schema: "dbo");

			migrationBuilder.DropTable(
					name: "PowerSupplyType",
					schema: "dbo");
		}
	}
}
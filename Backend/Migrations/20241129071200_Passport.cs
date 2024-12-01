using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PassportWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Passport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantDetails",
                columns: table => new
                {
                    ApplicntDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicantLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAliases = table.Column<bool>(type: "bit", nullable: false),
                    AliasName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsChangedName = table.Column<bool>(type: "bit", nullable: false),
                    PreviousName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    PancardNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VoterIdNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AadharcardNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    EmployementType = table.Column<int>(type: "int", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsParentOrSpouceGovermentServent = table.Column<bool>(type: "bit", nullable: false),
                    EducationQualification = table.Column<int>(type: "int", nullable: false),
                    Citizenship = table.Column<int>(type: "int", nullable: false),
                    IsNonEcrEligible = table.Column<bool>(type: "bit", nullable: false),
                    DistinguishMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousPassportNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDetails", x => x.ApplicntDetailsId);
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
                name: "Documents",
                columns: table => new
                {
                    DocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAcceptTermsAndCondition = table.Column<bool>(type: "bit", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAppApplied = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentsId);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyDetails",
                columns: table => new
                {
                    EmergencyDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmergencyContactAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmergencyContactMobileNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmergencyContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyDetails", x => x.EmergencyDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    FamilyDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeagalGuardianFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeagalGuardianSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpouceFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpouceSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.FamilyDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "OtherDetails",
                columns: table => new
                {
                    OtherDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCriminalProceedings = table.Column<bool>(type: "bit", nullable: false),
                    IsWarrantSummons = table.Column<bool>(type: "bit", nullable: false),
                    IArrestWarrant = table.Column<bool>(type: "bit", nullable: false),
                    IsDepartureOrder = table.Column<bool>(type: "bit", nullable: false),
                    IConviction = table.Column<bool>(type: "bit", nullable: false),
                    IsPassportRefusal = table.Column<bool>(type: "bit", nullable: false),
                    IsPassportImpounded = table.Column<bool>(type: "bit", nullable: false),
                    IspassportRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IsForeignCitizenship = table.Column<bool>(type: "bit", nullable: false),
                    IsotherPassport = table.Column<bool>(type: "bit", nullable: false),
                    IsSurrenderedPassport = table.Column<bool>(type: "bit", nullable: false),
                    IsRenunciation = table.Column<bool>(type: "bit", nullable: false),
                    IsEmergencyCertificate = table.Column<bool>(type: "bit", nullable: false),
                    IsDeported = table.Column<bool>(type: "bit", nullable: false),
                    IsRepatriated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDetails", x => x.OtherDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialDetails",
                columns: table => new
                {
                    ResidentialDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNoAndName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLane1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLane2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageOrCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TelephoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialDetails", x => x.ResidentialDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRquireds",
                columns: table => new
                {
                    ServiceRequiredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationType = table.Column<int>(type: "int", nullable: false),
                    PagesRequried = table.Column<int>(type: "int", nullable: false),
                    ValidityRequired = table.Column<int>(type: "int", nullable: false),
                    ReasonforRenewal = table.Column<int>(type: "int", nullable: false),
                    ChangeInAppearance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRquireds", x => x.ServiceRequiredId);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_PassportUserId",
                        column: x => x.PassportUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FeedbackType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterDetails",
                columns: table => new
                {
                    MasterDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    PassportType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequiredId = table.Column<int>(type: "int", nullable: false),
                    ServiceRquiredServiceRequiredId = table.Column<int>(type: "int", nullable: true),
                    ApplicntDetailsId = table.Column<int>(type: "int", nullable: false),
                    ApplicantDetailsApplicntDetailsId = table.Column<int>(type: "int", nullable: true),
                    FamilyDetailsId = table.Column<int>(type: "int", nullable: false),
                    ResidentialDetailsId = table.Column<int>(type: "int", nullable: false),
                    EmergencyDetailsId = table.Column<int>(type: "int", nullable: false),
                    OtherDetailsId = table.Column<int>(type: "int", nullable: false),
                    DocumentsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDetails", x => x.MasterDetailsId);
                    table.ForeignKey(
                        name: "FK_MasterDetails_ApplicantDetails_ApplicantDetailsApplicntDetailsId",
                        column: x => x.ApplicantDetailsApplicntDetailsId,
                        principalTable: "ApplicantDetails",
                        principalColumn: "ApplicntDetailsId");
                    table.ForeignKey(
                        name: "FK_MasterDetails_Documents_DocumentsId",
                        column: x => x.DocumentsId,
                        principalTable: "Documents",
                        principalColumn: "DocumentsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetails_EmergencyDetails_EmergencyDetailsId",
                        column: x => x.EmergencyDetailsId,
                        principalTable: "EmergencyDetails",
                        principalColumn: "EmergencyDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetails_FamilyDetails_FamilyDetailsId",
                        column: x => x.FamilyDetailsId,
                        principalTable: "FamilyDetails",
                        principalColumn: "FamilyDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetails_OtherDetails_OtherDetailsId",
                        column: x => x.OtherDetailsId,
                        principalTable: "OtherDetails",
                        principalColumn: "OtherDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetails_ResidentialDetails_ResidentialDetailsId",
                        column: x => x.ResidentialDetailsId,
                        principalTable: "ResidentialDetails",
                        principalColumn: "ResidentialDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetails_ServiceRquireds_ServiceRquiredServiceRequiredId",
                        column: x => x.ServiceRquiredServiceRequiredId,
                        principalTable: "ServiceRquireds",
                        principalColumn: "ServiceRequiredId");
                    table.ForeignKey(
                        name: "FK_MasterDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d6a6739-6950-4c0e-93eb-3f3d11e8b5ca", null, "User", "USER" },
                    { "ba27665c-00c7-4541-83a2-c63698d7c316", null, "Admin", "ADMIN" }
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
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_ApplicantDetailsApplicntDetailsId",
                table: "MasterDetails",
                column: "ApplicantDetailsApplicntDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_DocumentsId",
                table: "MasterDetails",
                column: "DocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_EmergencyDetailsId",
                table: "MasterDetails",
                column: "EmergencyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_FamilyDetailsId",
                table: "MasterDetails",
                column: "FamilyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_OtherDetailsId",
                table: "MasterDetails",
                column: "OtherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_ResidentialDetailsId",
                table: "MasterDetails",
                column: "ResidentialDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_ServiceRquiredServiceRequiredId",
                table: "MasterDetails",
                column: "ServiceRquiredServiceRequiredId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetails_UserId",
                table: "MasterDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PassportUserId",
                table: "Users",
                column: "PassportUserId");
        }

        /// <inheritdoc />
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
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MasterDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ApplicantDetails");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EmergencyDetails");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "OtherDetails");

            migrationBuilder.DropTable(
                name: "ResidentialDetails");

            migrationBuilder.DropTable(
                name: "ServiceRquireds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

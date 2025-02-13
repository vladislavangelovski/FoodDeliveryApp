using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations.PawPrintDbcontextMigrations
{
    /// <inheritdoc />
    public partial class initialpawprints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:approval_status", "approved,denied,pending")
                .Annotation("Npgsql:Enum:user_role", "consumer,admin");

            migrationBuilder.CreateTable(
                name: "adoption_statuses",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adoption_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "health_statuses",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_health_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pet_genders",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pet_sizes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pet_types",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shelters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    IsNoKill = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "surrender_reasons",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surrender_reasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastAnme = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    HasChildren = table.Column<bool>(type: "boolean", nullable: false),
                    HasOtherPets = table.Column<bool>(type: "boolean", nullable: false),
                    HomeType = table.Column<string>(type: "text", nullable: false),
                    UserRole = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "veterinarians",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ClinicName = table.Column<string>(type: "text", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    breed = table.Column<string>(type: "text", nullable: false),
                    avatar_img = table.Column<string>(type: "text", nullable: false),
                    image_showcase = table.Column<List<string>>(type: "text[]", nullable: false),
                    age_years = table.Column<int>(type: "integer", nullable: false),
                    type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    gender_id = table.Column<Guid>(type: "uuid", nullable: false),
                    size_id = table.Column<Guid>(type: "uuid", nullable: false),
                    adoption_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    health_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    good_with_children = table.Column<bool>(type: "boolean", nullable: false),
                    good_with_dogs = table.Column<bool>(type: "boolean", nullable: false),
                    good_with_cats = table.Column<bool>(type: "boolean", nullable: false),
                    energy_level = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    special_requirements = table.Column<string>(type: "text", nullable: true),
                    behaviorial_notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.Id);
                    table.CheckConstraint("CK_Pet_EnergyLevel", "\"EnergyLevel\" BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_pets_adoption_statuses_adoption_status_id",
                        column: x => x.adoption_status_id,
                        principalSchema: "public",
                        principalTable: "adoption_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_health_statuses_health_status_id",
                        column: x => x.health_status_id,
                        principalSchema: "public",
                        principalTable: "health_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_pet_genders_gender_id",
                        column: x => x.gender_id,
                        principalSchema: "public",
                        principalTable: "pet_genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_pet_sizes_size_id",
                        column: x => x.size_id,
                        principalSchema: "public",
                        principalTable: "pet_sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pets_pet_types_type_id",
                        column: x => x.type_id,
                        principalSchema: "public",
                        principalTable: "pet_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adopter_pet_gender_preferences",
                schema: "public",
                columns: table => new
                {
                    AdopterId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopter_pet_gender_preferences", x => new { x.AdopterId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_adopter_pet_gender_preferences_pet_genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "public",
                        principalTable: "pet_genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adopter_pet_gender_preferences_users_AdopterId",
                        column: x => x.AdopterId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adopter_pet_sizes_preferences",
                schema: "public",
                columns: table => new
                {
                    AdopterId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopter_pet_sizes_preferences", x => new { x.AdopterId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_adopter_pet_sizes_preferences_pet_sizes_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "public",
                        principalTable: "pet_sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adopter_pet_sizes_preferences_users_AdopterId",
                        column: x => x.AdopterId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adopter_pet_type_preferences",
                schema: "public",
                columns: table => new
                {
                    AdopterId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopter_pet_type_preferences", x => new { x.AdopterId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_adopter_pet_type_preferences_pet_types_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "public",
                        principalTable: "pet_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adopter_pet_type_preferences_users_AdopterId",
                        column: x => x.AdopterId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_records",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VetId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpayNeuterStatus = table.Column<bool>(type: "boolean", nullable: false),
                    LastMedicalCheckup = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MicrochipNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medical_records_veterinarians_VetId",
                        column: x => x.VetId,
                        principalSchema: "public",
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vet_specializations",
                schema: "public",
                columns: table => new
                {
                    VetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vet_specializations", x => new { x.VetId, x.Specialization });
                    table.ForeignKey(
                        name: "FK_vet_specializations_veterinarians_VetId",
                        column: x => x.VetId,
                        principalSchema: "public",
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adoptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdopterId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdoptionFee = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CounselorNotes = table.Column<string>(type: "text", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adoptions_pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "public",
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adoptions_users_AdopterId",
                        column: x => x.AdopterId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owner_pet_listings",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdopterId = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Approved = table.Column<string>(type: "text", nullable: false),
                    SurrenderReasonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner_pet_listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owner_pet_listings_pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "public",
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_owner_pet_listings_surrender_reasons_SurrenderReasonId",
                        column: x => x.SurrenderReasonId,
                        principalSchema: "public",
                        principalTable: "surrender_reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_owner_pet_listings_users_AdopterId",
                        column: x => x.AdopterId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_conditions",
                schema: "public",
                columns: table => new
                {
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConditionName = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_conditions", x => new { x.MedicalRecordId, x.ConditionName });
                    table.ForeignKey(
                        name: "FK_medical_conditions_medical_records_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "public",
                        principalTable: "medical_records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shelter_pet_listing",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: true),
                    Approved = table.Column<string>(type: "text", nullable: false),
                    IntakeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelter_pet_listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shelter_pet_listing_medical_records_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "public",
                        principalTable: "medical_records",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_shelter_pet_listing_pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "public",
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shelter_pet_listing_shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "public",
                        principalTable: "shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaccinations",
                schema: "public",
                columns: table => new
                {
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineName = table.Column<string>(type: "text", nullable: false),
                    VaccinationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinations", x => new { x.MedicalRecordId, x.VaccineName, x.VaccinationDate });
                    table.ForeignKey(
                        name: "FK_vaccinations_medical_records_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "public",
                        principalTable: "medical_records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owner_pet_listing_documents",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ListingId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentUrl = table.Column<string>(type: "text", nullable: false),
                    DocumentType = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner_pet_listing_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owner_pet_listing_documents_owner_pet_listings_ListingId",
                        column: x => x.ListingId,
                        principalSchema: "public",
                        principalTable: "owner_pet_listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adopter_pet_gender_preferences_GenderId",
                schema: "public",
                table: "adopter_pet_gender_preferences",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_adopter_pet_sizes_preferences_SizeId",
                schema: "public",
                table: "adopter_pet_sizes_preferences",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_adopter_pet_type_preferences_TypeId",
                schema: "public",
                table: "adopter_pet_type_preferences",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_adoptions_AdopterId",
                schema: "public",
                table: "adoptions",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_adoptions_PetId",
                schema: "public",
                table: "adoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_records_VetId",
                schema: "public",
                table: "medical_records",
                column: "VetId");

            migrationBuilder.CreateIndex(
                name: "IX_owner_pet_listing_documents_ListingId",
                schema: "public",
                table: "owner_pet_listing_documents",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_owner_pet_listings_AdopterId",
                schema: "public",
                table: "owner_pet_listings",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_owner_pet_listings_PetId",
                schema: "public",
                table: "owner_pet_listings",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_owner_pet_listings_SurrenderReasonId",
                schema: "public",
                table: "owner_pet_listings",
                column: "SurrenderReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_adoption_status_id",
                schema: "public",
                table: "pets",
                column: "adoption_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_gender_id",
                schema: "public",
                table: "pets",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_health_status_id",
                schema: "public",
                table: "pets",
                column: "health_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_size_id",
                schema: "public",
                table: "pets",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_type_id",
                schema: "public",
                table: "pets",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_shelter_pet_listing_MedicalRecordId",
                schema: "public",
                table: "shelter_pet_listing",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_shelter_pet_listing_PetId",
                schema: "public",
                table: "shelter_pet_listing",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_shelter_pet_listing_ShelterId",
                schema: "public",
                table: "shelter_pet_listing",
                column: "ShelterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adopter_pet_gender_preferences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "adopter_pet_sizes_preferences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "adopter_pet_type_preferences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "adoptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "medical_conditions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "owner_pet_listing_documents",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shelter_pet_listing",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vaccinations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vet_specializations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "owner_pet_listings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shelters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "medical_records",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pets",
                schema: "public");

            migrationBuilder.DropTable(
                name: "surrender_reasons",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "veterinarians",
                schema: "public");

            migrationBuilder.DropTable(
                name: "adoption_statuses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "health_statuses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pet_genders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pet_sizes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pet_types",
                schema: "public");
        }
    }
}

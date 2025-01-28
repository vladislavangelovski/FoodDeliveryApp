using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FoodDelivery.Domain.DomainModels.PawPrintModels;

//public enum ApprovalStatus
//{
//    APPROVED,
//    DENIED,
//    PENDING
//}

//public enum UserRole
//{
//    CONSUMER,
//    ADMIN
//}

public class PawPrintDbcontext : DbContext
{
    public PawPrintDbcontext(DbContextOptions<PawPrintDbcontext> options) : base(options) { }

    // Define all DbSets
    public DbSet<PetType> PetTypes { get; set; }
    public DbSet<PetSize> PetSizes { get; set; }
    public DbSet<PetGender> PetGenders { get; set; }
    public DbSet<HealthStatus> HealthStatuses { get; set; }
    public DbSet<AdoptionStatus> AdoptionStatuses { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<VetSpecialization> VetSpecializations { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<MedicalCondition> MedicalConditions { get; set; }
    public DbSet<Vaccination> Vaccinations { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<ShelterPetListing> ShelterPetListings { get; set; }
    public DbSet<OwnerPetListing> OwnerPetListings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AdopterPetTypePreference> AdopterPetTypePreferences { get; set; }
    public DbSet<AdopterPetSizePreference> AdopterPetSizePreferences { get; set; }
    public DbSet<AdopterPetGenderPreference> AdopterPetGenderPreferences { get; set; }
    public DbSet<Adoption> Adoptions { get; set; }
    public DbSet<SurrenderReason> SurrenderReasons { get; set; }
    public DbSet<OwnerPetListingDocument> OwnerPetListingDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure enums for PostgreSQL
        modelBuilder.HasPostgresEnum<ApprovalStatus>();
        modelBuilder.HasPostgresEnum<UserRole>();

        // Configure composite keys
        modelBuilder.Entity<PetType>()
        .ToTable("pet_types", "public");

        modelBuilder.Entity<PetSize>()
            .ToTable("pet_sizes", "public");

        modelBuilder.Entity<PetGender>()
            .ToTable("pet_genders", "public");

        modelBuilder.Entity<HealthStatus>()
            .ToTable("health_statuses", "public");

        modelBuilder.Entity<AdoptionStatus>()
            .ToTable("adoption_statuses", "public");

        modelBuilder.Entity<Shelter>()
            .ToTable("shelters", "public");

        modelBuilder.Entity<Veterinarian>()
            .ToTable("veterinarians", "public");

        modelBuilder.Entity<VetSpecialization>()
            .ToTable("vet_specializations", "public")
            .HasKey(vs => new { vs.VetId, vs.Specialization });

        modelBuilder.Entity<MedicalRecord>()
            .ToTable("medical_records", "public");

        modelBuilder.Entity<MedicalCondition>()
            .ToTable("medical_conditions", "public")
            .HasKey(mc => new { mc.MedicalRecordId, mc.ConditionName });

        modelBuilder.Entity<Vaccination>()
            .ToTable("vaccinations", "public")
            .HasKey(v => new { v.MedicalRecordId, v.VaccineName, v.VaccinationDate });

        modelBuilder.Entity<Pet>()
            .ToTable("pets", "public")  // If you also have array property config:
            .Property(p => p.ImageShowcase)
            .HasColumnType("text[]");

        modelBuilder.Entity<ShelterPetListing>()
            .ToTable("shelter_pet_listing", "public");

        modelBuilder.Entity<OwnerPetListing>()
            .ToTable("owner_pet_listings", "public");

        modelBuilder.Entity<User>()
            .ToTable("users", "public");

        modelBuilder.Entity<AdopterPetTypePreference>()
            .ToTable("adopter_pet_type_preferences", "public")
            .HasKey(ap => new { ap.AdopterId, ap.TypeId });

        modelBuilder.Entity<AdopterPetSizePreference>()
            .ToTable("adopter_pet_sizes_preferences", "public")
            .HasKey(ap => new { ap.AdopterId, ap.SizeId });

        modelBuilder.Entity<AdopterPetGenderPreference>()
            .ToTable("adopter_pet_gender_preferences", "public")
            .HasKey(ap => new { ap.AdopterId, ap.GenderId });

        modelBuilder.Entity<Adoption>()
            .ToTable("adoptions", "public");

        modelBuilder.Entity<SurrenderReason>()
            .ToTable("surrender_reasons", "public");

        modelBuilder.Entity<OwnerPetListingDocument>()
            .ToTable("owner_pet_listing_documents", "public");

        // Configure relationships
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Type)
            .WithMany()
            .HasForeignKey(p => p.TypeId);

        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Gender)
            .WithMany()
            .HasForeignKey(p => p.GenderId);

        modelBuilder.Entity<ShelterPetListing>()
            .HasOne(spl => spl.Shelter)
            .WithMany()
            .HasForeignKey(spl => spl.ShelterId);

        // Configure enums in entities
        modelBuilder.Entity<ShelterPetListing>()
            .Property(spl => spl.Approved)
            .HasConversion<string>();

        modelBuilder.Entity<OwnerPetListing>()
            .Property(opl => opl.Approved)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .Property(u => u.UserRole)
            .HasConversion<string>();

        // Configure check constraints
        modelBuilder.Entity<Pet>(entity =>
        {
            // Tells EF to use "pets" table in schema "public"
            entity.ToTable("pets", "public");

            // Map each property to your actual PostgreSQL column name:
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Breed).HasColumnName("breed");
            entity.Property(e => e.AvatarImg).HasColumnName("avatar_img");

            // "image_showcase" is a text[] array column
            entity.Property(e => e.ImageShowcase)
                  .HasColumnName("image_showcase")
                  .HasColumnType("text[]");

            entity.Property(e => e.AgeYears).HasColumnName("age_years");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.AdoptionStatusId).HasColumnName("adoption_status_id");
            entity.Property(e => e.HealthStatusId).HasColumnName("health_status_id");
            entity.Property(e => e.GoodWithChildren).HasColumnName("good_with_children");
            entity.Property(e => e.GoodWithDogs).HasColumnName("good_with_dogs");
            entity.Property(e => e.GoodWithCats).HasColumnName("good_with_cats");
            entity.Property(e => e.EnergyLevel).HasColumnName("energy_level");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.SpecialRequirements).HasColumnName("special_requirements");
            entity.Property(e => e.BehavioralNotes).HasColumnName("behaviorial_notes");

            // Keep your check constraint
            entity.HasCheckConstraint("CK_Pet_EnergyLevel", "\"EnergyLevel\" BETWEEN 1 AND 5");
        });
    

        // Similarly for PetGender:
        modelBuilder.Entity<PetGender>(entity =>
        {
            entity.ToTable("pet_genders", "public");
            entity.Property(pg => pg.Id).HasColumnName("Id");
            entity.Property(pg => pg.Name).HasColumnName("name");
        });

        // PetSize:
        modelBuilder.Entity<PetSize>(entity =>
        {
            entity.ToTable("pet_sizes", "public");
            entity.Property(ps => ps.Id).HasColumnName("Id");
            entity.Property(ps => ps.Name).HasColumnName("name");
        });

        // AdoptionStatus, HealthStatus, etc. all similarly:
        modelBuilder.Entity<AdoptionStatus>(entity =>
        {
            entity.ToTable("adoption_statuses", "public");
            entity.Property(a => a.Id).HasColumnName("Id");
            entity.Property(a => a.Name).HasColumnName("name");
        });

        modelBuilder.Entity<HealthStatus>(entity =>
        {
            entity.ToTable("health_statuses", "public");
            entity.Property(a => a.Id).HasColumnName("Id");
            entity.Property(a => a.Name).HasColumnName("name");
        });


        // Configure array type for PostgreSQL
        modelBuilder.Entity<Pet>()
            .Property(p => p.ImageShowcase)
            .HasColumnType("text[]");
    }
}
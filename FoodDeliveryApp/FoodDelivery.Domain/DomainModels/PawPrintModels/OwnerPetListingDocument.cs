using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class OwnerPetListingDocument : BaseEntity
    {
        [Required]
        public Guid ListingId { get; set; }
        [Required]
        public string DocumentUrl { get; set; }
        [Required]
        public string DocumentType { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("ListingId")]
        public OwnerPetListing OwnerPetListing { get; set; }
    }
}

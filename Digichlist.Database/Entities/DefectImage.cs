using System.ComponentModel.DataAnnotations.Schema;

namespace Digichlist.Database.Entities
{
    /// <summary>
    /// Represents images for specified defects.
    /// </summary>
    public class DefectImage
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The related defect identifier.
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// More info about the defect.
        /// </summary>
        public Defect Defect { get; set; }

        /// <summary>
        /// The image path.
        /// </summary>

        [Column(TypeName = "varchar(MAX)")]
        public string Path { get; set; }
    }
}

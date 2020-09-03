using ProMS.CORE.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.Project
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("project_name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Column("project_height")]
        [DataType(DataType.Text)]
        public int Height { get; set; }

        [Required]
        [Column("project_width")]
        [DataType(DataType.Text)]
        public int Width { get; set; }

        [Required]
        [Column("project_depth")]
        [DataType(DataType.Text)]
        public int Depth { get; set; }

        [Required]
        [Column("project_create_date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("project_last_modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Required]
        [Column("project_folder")]
        [DataType(DataType.Text)]
        public string Folder { get; set; }

        [Required]
        [Column("project_orderer")]
        [DataType(DataType.Text)]
        public string Orderer { get; set; }

        [Required]
        [Column("project_comment")]
        [DataType(DataType.Text)]
        public string Comment { get; set; }

        [Required]
        [Column("project_image_path")]
        [DataType(DataType.Text)]
        public string Image { get; set; }

        [Required]
        public virtual UserModel Author { get; set; }
    }
}

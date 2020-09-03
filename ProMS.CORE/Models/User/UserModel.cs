using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ProMS.CORE.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.User
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Column("firstname")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required]
        [Column("lastname")]
        [StringLength(25)]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required]
        [Column("email")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Column("phone_num")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }

        [Column("skype_contact")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string SkypeContact { get; set; }

        [Required]
        [Column("birth_date")]
        [DataType(DataType.Date)]
        public string DoB { get; set; }

        [Required]
        [Column("role")]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string RoleMember { get; set; }

        public virtual IList<ProjectModel> Projects { get; set; }

    }
}

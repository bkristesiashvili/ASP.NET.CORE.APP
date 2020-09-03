using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.User
{
    public enum PmsUserRoles
    {
        /// <summary>
        /// Access all functions
        /// </summary>
        ///
        [Display(Name ="admin")]
        Admin = 0x0001,

        /// <summary>
        /// Access edit functions
        /// </summary>
        /// 
        [Display(Name ="manager")]
        Manager = 0x0002,

        /// <summary>
        /// Only View
        /// </summary>
        /// 
        [Display(Name ="client")]
        Client = 0x0003
    }
}

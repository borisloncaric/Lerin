using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lerin.Models
{
    public class UserViewModel
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("username")]
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; } = "";


        [Column("passwordHash")]
        [Required(ErrorMessage = "Password is required")]
        public string passwordHash { get; set; } = "";

     
    }
}

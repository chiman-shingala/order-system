using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OrderSystem.UserModel
{
    public class ItemMasterDto
    {
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        [Required]
        public string? ItemName { get; set; }
        [Required]
        public string? ItemCode { get; set; }
        [Required]
        public decimal? ItemRate { get; set; }
        public decimal? Mrp { get; set; }
        [Required]
        public string? ItemDescription { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public int AcYear { get; set; }
        public string? ItemImage { get; set; }
        public int UserId { get; set; }
    }
}

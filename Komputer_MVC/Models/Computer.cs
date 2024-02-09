using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Komputer_MVC.Models
{
    public class Computer
    {
        [HiddenInput]
        public int ComputerId { get; set; }

        [Display(Name = "Nazwa komputera")]
        [Required(ErrorMessage = "Proszę podać nazwę komputera!")]
        [MinLength(length: 10, ErrorMessage = "Nazwa komputera musi zawierać minimum 10 znaków!")]
        public string Name { get; set; }

        [Display(Name = "Procesor")]
        [Required(ErrorMessage = "Proszę podać nazwę procesora!")]
        [MinLength(length: 7, ErrorMessage = "Nazwa procesora musi zawierać minimum 7 znaków!")]
        public string Processor { get; set; }

        [Display(Name = "Pamięć")]
        [Required(ErrorMessage = "Proszę podać nazwę pamięci RAM oraz jej wielkość!")]
        [MinLength(length: 7, ErrorMessage = "Nazwa pamięci RAM musi zawierać minimum 7 znaków!")]
        public string Memory { get; set; }

        [Display(Name = "Dysk twardy")]
        [Required(ErrorMessage = "Proszę podać nazwę dysku twardego i jego pojemność!")]
        [MinLength(length: 10, ErrorMessage = "Nazwa dysku twardego musi zawierać minimum 10 znaków!")]
        public string HardDrive { get; set; }

        [Display(Name = "Karta graficzna")]
        [Required(ErrorMessage = "Proszę podać nazwę karty graficznej!")]
        [MinLength(length: 10, ErrorMessage = "Nazwa karty graficznej musi zawierać minimum 10 znaków!")]
        public string GraphicsCard { get; set; }

        [Display(Name = "Data produkcji")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public int TypeId { get; set; }
        public TypeEntity? Type { get; set; }

        public int ProducerId { get; set; }
        public ProducerEntity? Producer { get; set; }
    }
}

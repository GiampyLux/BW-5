﻿using System.ComponentModel.DataAnnotations;

namespace clinica.Models
{
    public class Armadio
    {

        [Key]
        public int Id { get; set; }
        public bool Disponibilita { get; set; }
        public string Name { get; set; }

        public List<Cassetto> Cassetti { get; set; } = [];
        public List<Prodotto> Prodotti { get; set; } = [];
    }
}

﻿using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjetId { get; set; }
        public string NomTache { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime Date { get; set; }

    }
}

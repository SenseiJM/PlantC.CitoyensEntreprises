﻿using PlantC.CitoyensEntreprise.DAL.Enums;
using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjetId { get; set; }
        public string NomTache { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime Date { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class Treatment
    {
        public int TreatId { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
        public double Charge { get; set; }

        public override string ToString()
        {
            return $"{TreatId}: {Service} on {Date.ToString("dd-MM-yyyy HH':'mm':'ss")} costs {Charge}";
        }
    }
}

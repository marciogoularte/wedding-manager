﻿using System;

namespace WeddingManager.Core.Data
{
    public class Payment
    {
        public Payment(int id, decimal amount, PaymentMethod method, DateTime dateReceived, string notes)
        {
            Id = id;

            Amount = amount;

            Method = method;

            DateReceived = dateReceived;

            Notes = notes;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public DateTime DateReceived { get; set; }

        public string Notes { get; set; }
    }
}
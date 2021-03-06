﻿using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public int CreatePayment(int serviceId, Payment payment)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = entity.Services.FirstOrDefault(s => s.Id == serviceId &&
                                                                    s.DateSuppressed == null &&
                                                                    s.Customer.DateSuppressed == null &&
                                                                    s.Customer.Company.DateSuppressed == null);

                var dbPayment = new DB.Payment
                {
                    Service = dbService,
                    Amount = payment.Amount,
                    PaymentMethodId = (int)payment.Method,
                    DateReceived = payment.DateReceived,
                    Notes = payment.Notes
                };

                entity.Payments.Add(dbPayment);

                entity.SaveChanges();

                return dbPayment.Id;
            }
        }

        public IEnumerable<Payment> RetrievePayments(int serviceId)
        {
            var output = new List<Payment>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbPayments = entity.Payments.Where(p => p.ServiceId == serviceId &&
                                                          p.DateSuppressed == null &&
                                                          p.Service.DateSuppressed == null &&
                                                          p.Service.Customer.DateSuppressed == null &&
                                                          p.Service.Customer.Company.DateSuppressed == null);

                foreach(var dbPayment in dbPayments)
                {
                    output.Add(new Payment(dbPayment.Id, dbPayment.Amount, (PaymentMethod)dbPayment.PaymentMethodId, dbPayment.DateReceived, dbPayment.Notes));
                }
            }

            return output;
        }

        public void UpdatePayment(Payment payment)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbPayment = entity.Payments.FirstOrDefault(p => p.Id == payment.Id &&
                                                                    p.DateSuppressed == null &&
                                                                    p.Service.DateSuppressed == null &&
                                                                    p.Service.Customer.DateSuppressed == null &&
                                                                    p.Service.Customer.Company.DateSuppressed == null);

                if(dbPayment != null)
                {
                    dbPayment.Amount = payment.Amount;

                    dbPayment.PaymentMethodId = (int)payment.Method;

                    dbPayment.DateReceived = payment.DateReceived;

                    dbPayment.Notes = payment.Notes;
                }

                entity.SaveChanges();
            }
        }

        public void DeletePayment(int paymentId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbPayment = entity.Payments.FirstOrDefault(p => p.Id == paymentId &&
                                                                    p.DateSuppressed == null &&
                                                                    p.Service.DateSuppressed == null &&
                                                                    p.Service.Customer.DateSuppressed == null &&
                                                                    p.Service.Customer.Company.DateSuppressed == null);

                dbPayment.DateSuppressed = DateTime.Now;

                entity.SaveChanges();
            }
        }
    }
}
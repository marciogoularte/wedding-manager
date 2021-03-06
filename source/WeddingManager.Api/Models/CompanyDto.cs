﻿using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(Company company)
        {
            Id = company.Id;

            Name = company.Name;
        }

        public Company ToCompany()
        {
            return new Company(Id, Name);
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
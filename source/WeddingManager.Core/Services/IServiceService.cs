﻿using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface IServiceService
    {
        int CreateService(int customerId, Service service);

        void UpdateService(Service service);

        IEnumerable<Service> RetrieveServices(int customerId);

        void DeleteService(int serviceId);
    }
}
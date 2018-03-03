using System;

namespace EFMultiThread.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }

    }
}
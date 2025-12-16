using System;

namespace TSN_HR_Web.Models.Entities
{
    public abstract class BaseEntity
    {
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public bool is_active { get; set; }
    }
}
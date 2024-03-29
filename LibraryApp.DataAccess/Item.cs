﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LibraryApp.DataAccess
{
    public partial class Item
    {
        public Item()
        {
            ItemHistories = new HashSet<ItemHistory>();
        }

        public int Id { get; set; }
        public int ItemTypeId { get; set; }
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string DeweyDecimal { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<ItemHistory> ItemHistories { get; set; }
    }
}
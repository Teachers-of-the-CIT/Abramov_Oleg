using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Practics.DemoExam.Enums;
using Practics.DemoExam.Models.Base;

namespace Practics.DemoExam.Models
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime ReceivingDate { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
        
        public int ReceivingPointId { get; set; }
        public ReceivingPoint ReceivingPoint { get; set; }
        
        public List<OrderProduct> Products { get; set; }
        
        public int ReceivingCode { get; set; }
        
        public OrderStatus Status { get; set; }
    }
}
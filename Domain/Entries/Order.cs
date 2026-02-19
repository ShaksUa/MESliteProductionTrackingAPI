using Domain.Entries.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entries
{
    public class Order
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
         public int StationId { get; private set; }
        public int OperatorId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; } = null;

        public Status OrderStatus { get; private set; }

        public Order(string title, string? description, int stationId, int operatorId)
        {
            if (String.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            if (stationId <= 0) throw new ArgumentOutOfRangeException(nameof(stationId), "StationId must be greater than zero.");
            if (operatorId <= 0) throw new ArgumentOutOfRangeException(nameof(operatorId), "OperatorId must be greater than zero.");
            Title = title;
            Description = description;
            OrderStatus = Status.New;
            CreatedAt = DateTime.UtcNow;
            StationId = stationId;
            OperatorId = operatorId;
        }

        private Order() { } // For EF Core
        private Order(int id, string title, string? description, int stationId, int operatorId, DateTime createdAt, DateTime? closedAt, Status orderStatus)
        {
            Id = id;
            Title = title;
            Description = description;
            StationId = stationId;
            OperatorId = operatorId;
            CreatedAt = createdAt;
            ClosedAt = closedAt;
            OrderStatus = orderStatus;
        }
        public static Order Create(string title, string? description, int stationId, int operatorId)
        {
            return new Order(title, description, stationId, operatorId);
        }

        public void StartOrder()
        {
            if (OrderStatus != Status.New)     
            {
                throw new InvalidOperationException("Only new orders can be started.");
            }
            OrderStatus = Status.InProgress;
        }

        public void CompleteOrder()
        {
            if (OrderStatus != Status.InProgress)
            {
                throw new InvalidOperationException("Only orders in progress can be completed.");
            }
            OrderStatus = Status.Completed;
            ClosedAt = DateTime.UtcNow;
        }

        public void CancelOrder()
        {
            if (OrderStatus == Status.Completed)
            {
                throw new InvalidOperationException("Completed orders cannot be cancelled.");
            }
            OrderStatus = Status.Cancelled;
            ClosedAt = DateTime.UtcNow;
        }

        public void UpdateStation(int newStationId)
        {
            if (Status.Cancelled.Equals(OrderStatus) && Status.Completed.Equals(OrderStatus)) { 
                throw new InvalidOperationException("Cannot update station for cancelled or completed orders.");
            }
            if (newStationId <= 0) throw new ArgumentOutOfRangeException(nameof(newStationId), "StationId must be greater than zero.");
            StationId = newStationId;
        }

        public void UpdateOperator(int newOperatorId)
        {
            if (Status.Cancelled.Equals(OrderStatus) && Status.Completed.Equals(OrderStatus))
            {
                throw new InvalidOperationException("Cannot update station for cancelled or completed orders.");
            }
            if (newOperatorId <= 0) throw new ArgumentOutOfRangeException(nameof(newOperatorId), "OperatorId must be greater than zero.");
            OperatorId = newOperatorId;
        }
        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }

    }
}

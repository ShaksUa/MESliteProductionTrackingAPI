using Application.DTO;
using Domain.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PositionService
    {
        private int _nextId = 0;
        private readonly List<Position> _positions = new();

        public Position Create(CreatePositionRequests createPositionRequests)
        {
            _nextId++;
            var position = new Position(
                _nextId,
                createPositionRequests.Name,
                createPositionRequests.Description,
                createPositionRequests.DepartmentId,
                createPositionRequests.IsRemote
                );
            _positions.Add(position);
            return position;
        }

        public Position GetById(int id)
        {
            return _positions.FirstOrDefault(p => p.Id == id);
        }
        public bool Delete(int id)
        {
            return _positions.Remove(GetById(id));
        }

        public List<Position> GetAll()
        {
            return _positions;
        }

        public Position UpdateById(int id, UpdatePositionRequest updatePositionRequest)
        {
            var pos = GetById(id);
            if (pos != null)
            {
                pos.Update(
                    updatePositionRequest.Name,
                    updatePositionRequest.Description,
                    updatePositionRequest.DepartmentId,
                    updatePositionRequest.CreatedAt,
                    updatePositionRequest.IsRemote);
                return pos;
            }
            return default;
        }
    }
}
